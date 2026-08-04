using RetroBatGameListComparator.Forms;
using RetroBatGameListComparator.Models;
using RetroBatGameListComparator.Services;
using System.Diagnostics;
using RetroBatGameListComparator.Helpers;
using System.Threading;

namespace RetroBatGameListComparator;

public partial class MainForm : Form
{
    private readonly ExtensionService _extensionService = new();
    private readonly FolderScannerService _folderScannerService = new();
    private readonly XmlReaderService _xmlReaderService = new();
    private readonly ComparisonService _comparisonService = new();
    private readonly ExportService _exportService = new();

    private readonly UpdateService _updateService = new();

    private ComparisonResult? _lastResult;

    private List<RomEntry> _missingFromXml = new();
    private List<RomEntry> _missingFromDisk = new();

    private readonly ListViewSorter _xmlSorter = new();
    private readonly ListViewSorter _diskSorter = new();

    private readonly Color _dropBackColor = Color.FromArgb(240, 248, 255);

    private List<string> _allExtensions = new();

    public MainForm()
    {
        InitializeComponent();

        AllowDrop = true;

        DragEnter += MainForm_DragEnter;
        DragLeave += MainForm_DragLeave;
        DragDrop += MainForm_DragDrop;

        ActiveControl = btnCompare;

        txtSearchXml.Enabled = false;
        txtSearchDisk.Enabled = false;

        lvMissingFromXml.ListViewItemSorter = _xmlSorter;
        lvMissingFromDisk.ListViewItemSorter = _diskSorter;

        lvMissingFromXml.ColumnClick += LvMissingFromXml_ColumnClick;
        lvMissingFromDisk.ColumnClick += LvMissingFromDisk_ColumnClick;

        ListViewContextMenuHelper.Attach(lvMissingFromXml);
        ListViewContextMenuHelper.Attach(lvMissingFromDisk);

        // Configuration du ComboBox des extensions
        cmbExtension.DropDownStyle = ComboBoxStyle.DropDown;
        cmbExtension.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cmbExtension.AutoCompleteSource = AutoCompleteSource.ListItems;

        ReloadExtensions();

        btnExportTxt.Enabled = false;
        btnExportCsv.Enabled = false;

        txtRomFolder.TextChanged += (_, _) =>
        {
            UpdateCompareButtonState();
        };

        txtGameList.TextChanged += (_, _) =>
        {
            UpdateCompareButtonState();
        };

        cmbExtension.TextChanged += (_, _) =>
        {
            UpdateCompareButtonState();
        };

        // Recherche instantanée
        txtSearchXml.TextChanged += (_, _) =>
        {
            RefreshMissingXml();
        };

        txtSearchDisk.TextChanged += (_, _) =>
        {
            RefreshMissingDisk();
        };

        // ESC efface la recherche
        txtSearchXml.KeyDown += SearchBox_KeyDown;
        txtSearchDisk.KeyDown += SearchBox_KeyDown;

        UpdateCompareButtonState();

        // Vérifie les mises à jour après l'affichage de la fenêtre
        Shown += async (_, _) => await CheckForUpdatesAsync();
    }

    private void SearchBox_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Escape)
            return;

        if (sender is TextBox textBox)
        {
            textBox.Clear();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

    }
    private void RefreshMissingXml()
    {
        lvMissingFromXml.BeginUpdate();

        lvMissingFromXml.Items.Clear();

        IEnumerable<RomEntry> roms = _missingFromXml;

        string filter = txtSearchXml.Text.Trim();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            roms = roms.Where(r =>
                r.FileName.Contains(
                    filter,
                    StringComparison.OrdinalIgnoreCase));
        }

        if (!roms.Any())
        {
            ListViewItem item =
                new("✓ Aucune ROM absente du XML");

            // Pas de Tag volontairement.
            // Cette ligne est informative uniquement.

            lvMissingFromXml.Items.Add(item);
        }
        else
        {
            foreach (RomEntry rom in roms)
            {
                ListViewItem item = new(rom.FileName);

                string folder =
                    Path.GetDirectoryName(rom.RelativePath);

                if (string.IsNullOrWhiteSpace(folder))
                    folder = "[racine]";

                item.SubItems.Add(folder);

                item.Tag = rom;

                lvMissingFromXml.Items.Add(item);
            }
        }

        _xmlSorter.Column = 0;
        _xmlSorter.Order = SortOrder.Ascending;

        lvMissingFromXml.Sort();

        UpdateColumnHeaders(
            lvMissingFromXml,
            0,
            SortOrder.Ascending);

        foreach (ColumnHeader column in lvMissingFromXml.Columns)
            column.Width = -2;

        lvMissingFromXml.EndUpdate();
    }

    private void RefreshMissingDisk()
    {
        lvMissingFromDisk.BeginUpdate();

        lvMissingFromDisk.Items.Clear();

        IEnumerable<RomEntry> roms = _missingFromDisk;

        string filter = txtSearchDisk.Text.Trim();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            roms = roms.Where(r =>
                r.FileName.Contains(
                    filter,
                    StringComparison.OrdinalIgnoreCase));
        }

        if (!roms.Any())
        {
            ListViewItem item =
    new("✓ Aucune ROM absente du disque");

            // Pas de Tag volontairement.
            // Cette ligne est informative uniquement.

            lvMissingFromDisk.Items.Add(item);
        }
        else
        {
            foreach (RomEntry rom in roms)
            {
                ListViewItem item = new(rom.FileName);

                string folder =
                    Path.GetDirectoryName(rom.RelativePath);

                if (string.IsNullOrWhiteSpace(folder))
                    folder = "[racine]";

                item.SubItems.Add(folder);

                item.Tag = rom;

                lvMissingFromDisk.Items.Add(item);
            }
        }

        _diskSorter.Column = 0;
        _diskSorter.Order = SortOrder.Ascending;

        lvMissingFromDisk.Sort();

        UpdateColumnHeaders(
            lvMissingFromDisk,
            0,
            SortOrder.Ascending);

        foreach (ColumnHeader column in lvMissingFromDisk.Columns)
            column.Width = -2;

        lvMissingFromDisk.EndUpdate();
    }
    class ListViewItemComparer : System.Collections.IComparer
    {
        private readonly int _column;
        private readonly bool _ascending;

        public ListViewItemComparer(int column, bool ascending)
        {
            _column = column;
            _ascending = ascending;
        }

        public int Compare(object? x, object? y)
        {
            var item1 = (ListViewItem)x!;
            var item2 = (ListViewItem)y!;

            int result = string.Compare(
                item1.SubItems[_column].Text,
                item2.SubItems[_column].Text,
                StringComparison.CurrentCultureIgnoreCase);

            return _ascending ? result : -result;
        }
    }

    private void UpdateCompareButtonState()
    {
        bool romFolderValid =
            Directory.Exists(txtRomFolder.Text);

        bool gameListValid =
            File.Exists(txtGameList.Text);

        bool extensionsValid =
            !string.IsNullOrWhiteSpace(cmbExtension.Text);

        btnCompare.Enabled =
            romFolderValid &&
            gameListValid &&
            extensionsValid;
    }

    private void MainForm_DragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
        {
            e.Effect = DragDropEffects.Copy;

            txtRomFolder.BackColor = Color.FromArgb(235, 245, 255);
            txtGameList.BackColor = Color.FromArgb(235, 245, 255);

            btnCompare.BackColor = Color.FromArgb(235, 245, 255);

            txtRomFolder.PlaceholderText =
                "📁 Relâchez pour déposer votre dossier...";

            txtGameList.PlaceholderText =
                "📄 Le GameList.xml sera détecté automatiquement.";
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }

    private void MainForm_DragLeave(object? sender, EventArgs e)
    {
        txtRomFolder.BackColor = SystemColors.Window;
        txtGameList.BackColor = SystemColors.Window;

        btnCompare.UseVisualStyleBackColor = true;

        txtRomFolder.PlaceholderText =
            "📁 Glissez ici un dossier de ROMs... Ou sélectionnez un dossier";

        txtGameList.PlaceholderText =
            "📄 Glissez ici un fichier gamelist.xml... ou sélectionnez un fichier";
    }

    private void MainForm_DragDrop(object? sender, DragEventArgs e)
    {
        // Restaure l'apparence normale
        txtRomFolder.BackColor = SystemColors.Window;
        txtGameList.BackColor = SystemColors.Window;

        btnCompare.UseVisualStyleBackColor = true;

        txtRomFolder.PlaceholderText =
            "📁 Glissez ici un dossier de ROMs... Ou sélectionnez un dossier";

        txtGameList.PlaceholderText =
            "📄 Glissez ici un fichier gamelist.xml... ou sélectionnez un fichier";

        // Vérifie que l'utilisateur a bien déposé quelque chose
        if (e.Data?.GetData(DataFormats.FileDrop) is not string[] files ||
            files.Length == 0)
            return;

        string path = files[0];

        // Dépôt d'un dossier
        if (Directory.Exists(path))
        {
            txtRomFolder.Text = path;

            string gameList = Path.Combine(path, "gamelist.xml");

            if (File.Exists(gameList))
                txtGameList.Text = gameList;
        }
        // Dépôt d'un fichier gamelist.xml
        else if (File.Exists(path) &&
                 Path.GetFileName(path).Equals(
                     "gamelist.xml",
                     StringComparison.OrdinalIgnoreCase))
        {
            txtGameList.Text = path;
            txtRomFolder.Text = Path.GetDirectoryName(path)!;
        }

        // Met à jour l'état du bouton Comparer
        UpdateCompareButtonState();
    }

    private void ReloadExtensions()
    {
        List<string> current = GetExtensions();

        _allExtensions = _extensionService.LoadExtensions();

        cmbExtension.DataSource = null;
        cmbExtension.DataSource = _allExtensions;

        if (current.Any())
        {
            cmbExtension.Text =
                _extensionService.Format(current);
        }
    }

    private void btnExportTxt_Click(object sender, EventArgs e)
    {
        if (_lastResult == null)
            return;

        using SaveFileDialog dialog = new();

        string systemName = new DirectoryInfo(txtRomFolder.Text).Name;

        dialog.FileName =
            $"{systemName}_Compare_{DateTime.Now:yyyy-MM-dd_HHmmss}.txt";

        dialog.Filter = "Fichier texte (*.txt)|*.txt";

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        _exportService.ExportTxt(
            dialog.FileName,
            txtRomFolder.Text,
            txtGameList.Text,
            string.Join(";", GetExtensions()),
            _lastResult);

        MessageBox.Show(
            "Export terminé.",
            "Information",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void btnExportCsv_Click(object sender, EventArgs e)
    {
        if (_lastResult == null)
            return;

        using SaveFileDialog dialog = new();

        string systemName = new DirectoryInfo(txtRomFolder.Text).Name;

        dialog.FileName =
            $"{systemName}_Compare_{DateTime.Now:yyyy-MM-dd_HHmmss}.csv";

        dialog.Filter = "CSV (*.csv)|*.csv";

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        _exportService.ExportCsv(
            dialog.FileName,
            _lastResult);

        MessageBox.Show(
            "Export CSV terminé.",
            "Information",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private List<string> GetExtensions()
    {
        return _extensionService.NormalizeList(cmbExtension.Text);
    }

    private bool ValidateInputs()
    {
        if (!Directory.Exists(txtRomFolder.Text))
        {
            MessageBox.Show("Sélectionnez un dossier ROMs valide.");
            return false;
        }

        if (!File.Exists(txtGameList.Text))
        {
            MessageBox.Show("Sélectionnez un GameList.xml valide.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(cmbExtension.Text))
        {
            MessageBox.Show("Sélectionnez une extension.");
            return false;
        }

        return true;
    }

    private void btnBrowseRomFolder_Click(object sender, EventArgs e)
    {
        using FolderBrowserDialog dlg = new();

        if (dlg.ShowDialog() == DialogResult.OK)
            txtRomFolder.Text = dlg.SelectedPath;
        UpdateCompareButtonState();
    }

    private void btnBrowseGameList_Click(object sender, EventArgs e)
    {
        using OpenFileDialog dlg = new();

        dlg.Filter = "GameList (*.xml)|*.xml";

        if (dlg.ShowDialog() == DialogResult.OK)
            txtGameList.Text = dlg.FileName;
        UpdateCompareButtonState();
    }

    private void btnSelectExtensions_Click(object sender, EventArgs e)
    {
        List<string> allExtensions =
            _extensionService.LoadExtensions();

        List<string> selectedExtensions =
            GetExtensions();

        using ExtensionSelectorForm form =
            new(allExtensions, selectedExtensions);

        if (form.ShowDialog(this) == DialogResult.OK)
        {
            cmbExtension.Text =
                _extensionService.Format(form.SelectedExtensions);
            UpdateCompareButtonState();
        }
    }

    private void mnuAbout_Click(object sender, EventArgs e)
    {
        using AboutForm form = new();

        form.ShowDialog(this);
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void mnuGitHub_Click(object sender, EventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/theJim69/RetroBatGameListComparator",
                    UseShellExecute = true
                });
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Impossible d'ouvrir GitHub",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
    private void btnCompare_Click(object sender, EventArgs e)
    {
        progressBar.Visible = true;
        label1.Visible = true;

        progressBar.Value = 0;
        label1.Text = "Analyse du dossier ROMs...";

        Application.DoEvents();

        if (!ValidateInputs())
            return;

        List<string> extensions = GetExtensions();

        cmbExtension.Text = _extensionService.Format(extensions);

        List<string> unknown =
            _extensionService.GetUnknownExtensions(extensions);

        if (unknown.Any())
        {
            string message =
                "Les extensions suivantes n'existent pas :\n\n" +
                string.Join(Environment.NewLine, unknown) +
                "\n\nVoulez-vous les ajouter ?";

            if (MessageBox.Show(
                message,
                "Nouvelles extensions",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _extensionService.AddExtensions(unknown);

                ReloadExtensions();

                cmbExtension.Text =
                    _extensionService.Format(extensions);
            }
        }

        //----------------------------------------------------------
        // Scan du disque
        //----------------------------------------------------------

        var disk = _folderScannerService.Scan(
            txtRomFolder.Text,
            extensions,
            chkRecursive.Checked);

               //----------------------------------------------------------
        // Lecture du XML
        //----------------------------------------------------------

        var xml = _xmlReaderService.Read(
            txtGameList.Text,
            txtRomFolder.Text);

        progressBar.Value = 60;
        label1.Text = "Comparaison des fichiers...";
        Application.DoEvents();

        //----------------------------------------------------------
        // Comparaison
        //----------------------------------------------------------

        _lastResult = _comparisonService.Compare(
            disk,
            xml);

        //----------------------------------------------------------
        // Sauvegarde des listes originales
        //----------------------------------------------------------

        _missingFromXml =
            _lastResult.MissingFromXml.ToList();

        _missingFromDisk =
            _lastResult.MissingFromDisk.ToList();

        txtSearchXml.Enabled =
            _missingFromXml.Count > 0;

        txtSearchDisk.Enabled =
            _missingFromDisk.Count > 0;

        txtSearchXml.Clear();
        txtSearchDisk.Clear();

        progressBar.Value = 90;
        label1.Text = "Affichage des résultats...";
        Application.DoEvents();

        DisplayStatistics(
            _lastResult);

        RefreshMissingXml();
        RefreshMissingDisk();

        progressBar.Value = 100;
        label1.Text = "Comparaison terminée.";
        Application.DoEvents();

        Thread.Sleep(300);

        progressBar.Visible = false;
        label1.Visible = false;

        btnExportTxt.Enabled = true;
        btnExportCsv.Enabled = true;
    }

    private static void UpdateColumnHeaders(
        ListView listView,
        int column,
        SortOrder order)
    {
        foreach (ColumnHeader header in listView.Columns)
        {
            header.Text =
                header.Text
                    .Replace(" ▲", "")
                    .Replace(" ▼", "");
        }

        string arrow =
            order == SortOrder.Ascending
                ? " ▲"
                : " ▼";

        listView.Columns[column].Text += arrow;
    }

    private void DisplayStatistics(
    ComparisonResult result)
    {
        lblDiskCount.Text =
            $"⭐ Jeux de la plateforme : {result.ComparedCount}";

        lblXmlCount.Text =
            $"Entrées XML : {result.XmlCount}";

        lblMatching.Text =
            $"ROMs validées : {result.MatchingCount}";

        lblMultiDiskIgnored.Text =
            $"MultiDisk ignorés : {result.MultiDiskIgnoredCount}";

        lblHiddenIgnored.Text =
            $"Jeux cachés : {result.HiddenIgnoredCount}";

        lblMissingXml.Text =
            $"Absentes du XML : {result.MissingFromXml.Count}";

        lblMissingDisk.Text =
            $"Absentes du disque : {result.MissingFromDisk.Count}";
    }

    private void lvMissingFromXml_DoubleClick(object sender, EventArgs e)
    {
        if (lvMissingFromXml.SelectedItems.Count == 0)
            return;

        if (lvMissingFromXml.SelectedItems[0].Tag is not RomEntry rom)
            return;

        if (!File.Exists(rom.FullPath))
            return;

        System.Diagnostics.Process.Start(
            "explorer.exe",
            $"/select,\"{rom.FullPath}\"");
    }

    private void lvMissingFromDisk_DoubleClick(object sender, EventArgs e)
    {
        if (lvMissingFromDisk.SelectedItems.Count == 0)
            return;

        if (lvMissingFromDisk.SelectedItems[0].Tag is not RomEntry rom)
            return;

        if (!File.Exists(rom.GameListPath))
        {
            MessageBox.Show(
                "Le fichier GameList.xml est introuvable.",
                "RetroBat GameList Comparator",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = rom.GameListPath,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Impossible d'ouvrir le fichier.\n\n{ex.Message}",
                "RetroBat GameList Comparator",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void LvMissingFromXml_ColumnClick(object? sender, ColumnClickEventArgs e)
    {
        if (_xmlSorter.Column == e.Column)
        {
            _xmlSorter.Order =
                _xmlSorter.Order == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
        }
        else
        {
            _xmlSorter.Column = e.Column;
            _xmlSorter.Order = SortOrder.Ascending;
        }

        lvMissingFromXml.Sort();

        UpdateColumnHeaders(
            lvMissingFromXml,
            _xmlSorter.Column,
            _xmlSorter.Order);
    }

    private void LvMissingFromDisk_ColumnClick(object? sender, ColumnClickEventArgs e)
    {
        if (_diskSorter.Column == e.Column)
        {
            _diskSorter.Order =
                _diskSorter.Order == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
        }
        else
        {
            _diskSorter.Column = e.Column;
            _diskSorter.Order = SortOrder.Ascending;
        }

        lvMissingFromDisk.Sort();

        UpdateColumnHeaders(
            lvMissingFromDisk,
            _diskSorter.Column,
            _diskSorter.Order);
    }

    private void lblDropOverlay_Click(object sender, EventArgs e)
    {

    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void lblDropHint_Click(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private async void mnuCheckUpdates_Click(object sender, EventArgs e)
    {
        try
        {
            GitHubRelease? release =
                await _updateService.GetLatestReleaseAsync();

            MessageBox.Show(
                $"Version installée : {_updateService.GetCurrentVersionString()}" +
                $"\n\nDernière version : {release?.TagName}",
                "Vérification des mises à jour",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Impossible de vérifier les mises à jour.\n\n{ex.Message}",
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
    private async Task CheckForUpdatesAsync()
    {
        try
        {
            GitHubRelease? release =
                await _updateService.GetLatestReleaseAsync();

            if (release == null)
                return;

            Version current =
                _updateService.GetCurrentVersion();

            Version latest =
                Version.Parse(
                    release.TagName.TrimStart('v', 'V'));


            if (latest <= current)
                return;

            GitHubAsset? asset =
                _updateService.GetPortableAsset(release);

            if (asset == null)
            {
                MessageBox.Show(
                    "Impossible de trouver le fichier portable dans cette Release.",
                    "Mise à jour",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            UpdateForm updateForm = new(
                current,
                release,
                asset);

            if (updateForm.ShowDialog(this) == DialogResult.OK)
            {
                string downloadedFile =
                    await _updateService.DownloadPortableReleaseAsync(asset);

                MessageBox.Show(
                    $"Téléchargement terminé !\n\nLe fichier a été enregistré dans :\n\n{downloadedFile}",
                    "Mise à jour",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        catch
        {
            // Pas d'Internet ou GitHub indisponible :
            // on ignore silencieusement.
        }
    }

    private void lblDiskCount_Click(object sender, EventArgs e)
    {

    }

    private void lblXmlCount_Click(object sender, EventArgs e)
    {

    }

    private void grpStatistics_Enter(object sender, EventArgs e)
    {

    }
}
