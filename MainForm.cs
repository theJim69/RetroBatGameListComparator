using RetroBatGameListComparator.Models;
using RetroBatGameListComparator.Services;
using System.Threading;

namespace RetroBatGameListComparator;

public partial class MainForm : Form
{
    private readonly ExtensionService _extensionService = new();
    private readonly FolderScannerService _folderScannerService = new();
    private readonly XmlReaderService _xmlReaderService = new();
    private readonly ComparisonService _comparisonService = new();
    private readonly ExportService _exportService = new();

    private ComparisonResult? _lastResult;

    private readonly ListViewSorter _xmlSorter = new();
    private readonly ListViewSorter _diskSorter = new();

    private readonly Color _normalBackColor;
    private readonly Color _dropBackColor = Color.FromArgb(240, 248, 255);


    public MainForm()
    {
        InitializeComponent();

        _normalBackColor = BackColor;

        AllowDrop = true;

        DragEnter += MainForm_DragEnter;
        DragLeave += MainForm_DragLeave;
        DragDrop += MainForm_DragDrop;

        ActiveControl = btnCompare;

        lvMissingFromXml.ListViewItemSorter = _xmlSorter;
        lvMissingFromDisk.ListViewItemSorter = _diskSorter;

        lvMissingFromXml.ColumnClick += LvMissingFromXml_ColumnClick;
        lvMissingFromDisk.ColumnClick += LvMissingFromDisk_ColumnClick;

        ReloadExtensions();

        btnExportTxt.Enabled = false;
        btnExportCsv.Enabled = false;
        
        txtRomFolder.TextChanged += (_, _) => UpdateCompareButtonState();
        txtGameList.TextChanged += (_, _) => UpdateCompareButtonState();
        cmbExtension.TextChanged += (_, _) => UpdateCompareButtonState();

        UpdateCompareButtonState();
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

    private void MainForm_DragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
        {
            e.Effect = DragDropEffects.Copy;

            txtRomFolder.BackColor = Color.FromArgb(210, 235, 255);
            txtGameList.BackColor = Color.FromArgb(210, 235, 255);

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

        txtRomFolder.PlaceholderText =
            "📁 Glissez ici un dossier de ROMs...";

        txtGameList.PlaceholderText =
            "📄 Glissez ici un fichier gamelist.xml...";
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

    private void MainForm_DragDrop(object? sender, DragEventArgs e)
    {
        pnlDropOverlay.Visible = false;

        BackColor = _normalBackColor;

        txtRomFolder.PlaceholderText =
            "📁 Glissez ici un dossier de ROMs...";

        txtGameList.PlaceholderText =
            "📄 Glissez ici un fichier gamelist.xml...";

        txtRomFolder.BackColor = SystemColors.Window;
        txtGameList.BackColor = SystemColors.Window;

        txtRomFolder.PlaceholderText =
            "📁 Glissez ici un dossier de ROMs...";

        txtGameList.PlaceholderText =
            "📄 Glissez ici un fichier gamelist.xml...";

        if (e.Data?.GetData(DataFormats.FileDrop) is not string[] files ||
            files.Length == 0)
            return;

        string path = files[0];

        // Dépôt d'un dossier
        if (Directory.Exists(path))
        {
            txtRomFolder.Text = path;

            string gameList =
                Path.Combine(path, "gamelist.xml");

            if (File.Exists(gameList))
                txtGameList.Text = gameList;

            return;

            UpdateCompareButtonState();
        }

        // Dépôt d'un fichier gamelist.xml
        if (File.Exists(path) &&
            Path.GetFileName(path).Equals(
                "gamelist.xml",
                StringComparison.OrdinalIgnoreCase))
        {
            txtGameList.Text = path;
            txtRomFolder.Text =
                Path.GetDirectoryName(path)!;
        }
    }

    private void ReloadExtensions()
    {
        List<string> current = GetExtensions();

        cmbExtension.DataSource = null;
        cmbExtension.DataSource = _extensionService.LoadExtensions();

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

        var disk = _folderScannerService.Scan(
    txtRomFolder.Text,
    extensions,
    chkRecursive.Checked);

        progressBar.Value = 30;
        label1.Text = "Lecture du GameList.xml...";
        Application.DoEvents();

        var xml = _xmlReaderService.Read(
    txtGameList.Text,
    txtRomFolder.Text);

        progressBar.Value = 60;
        label1.Text = "Comparaison des fichiers...";
        Application.DoEvents();

        _lastResult = _comparisonService.Compare(disk, xml);

        progressBar.Value = 90;
        label1.Text = "Affichage des résultats...";
        Application.DoEvents();

        DisplayResult(_lastResult);

        progressBar.Value = 100;
        label1.Text = "Comparaison terminée.";
        Application.DoEvents();

        Thread.Sleep(300);

        progressBar.Visible = false;
        label1.Visible = false;

        btnExportTxt.Enabled = true;
        btnExportCsv.Enabled = true;
    }

    private void DisplayResult(ComparisonResult result)
    {
        lblDiskCount.Text = $"ROMs disque : {result.DiskCount}";
        lblXmlCount.Text = $"Entrées XML : {result.XmlCount}";
        lblMatching.Text = $"Correspondances : {result.MatchingCount}";
        lblMissingXml.Text = $"Absentes XML : {result.MissingFromXml.Count}";
        lblMissingDisk.Text = $"Absentes disque : {result.MissingFromDisk.Count}";
        lblMissingXmlTitle.Text = $"Absentes du XML ({result.MissingFromXml.Count})";
        lblMissingDiskTitle.Text = $"Absentes du disque ({result.MissingFromDisk.Count})";

        lvMissingFromXml.Items.Clear();
        lvMissingFromDisk.Items.Clear();

        //---------------------------------------
        // ROMs absentes du XML
        //---------------------------------------

        if (result.MissingFromXml.Count == 0)
        {
            lvMissingFromXml.Items.Add(
                new ListViewItem("✓ Aucune ROM absente du XML"));
        }
        else
        {
            foreach (RomEntry rom in result.MissingFromXml)
            {
                ListViewItem item = new(rom.FileName);

                string folder = Path.GetDirectoryName(rom.RelativePath);

                if (string.IsNullOrWhiteSpace(folder))
                    folder = "[racine]";

                item.SubItems.Add(folder);

                // IMPORTANT
                item.Tag = rom;

                lvMissingFromXml.Items.Add(item);
            }
        }

        //---------------------------------------
        // ROMs absentes du disque
        //---------------------------------------

        if (result.MissingFromDisk.Count == 0)
        {
            lvMissingFromDisk.Items.Add(
                new ListViewItem("✓ Aucune ROM absente du disque"));
        }
        else
        {
            foreach (RomEntry rom in result.MissingFromDisk)
            {
                ListViewItem item = new(rom.FileName);

                string folder = Path.GetDirectoryName(rom.RelativePath);

                if (string.IsNullOrWhiteSpace(folder))
                    folder = "[racine]";

                item.SubItems.Add(folder);

                // IMPORTANT
                item.Tag = rom;

                lvMissingFromDisk.Items.Add(item);
            }
        }

        // Tri automatique des listes
        _xmlSorter.Column = 0;
        _xmlSorter.Order = SortOrder.Ascending;

        _diskSorter.Column = 0;
        _diskSorter.Order = SortOrder.Ascending;

        lvMissingFromXml.Sort();
        lvMissingFromDisk.Sort();

        UpdateColumnHeaders(
            lvMissingFromXml,
            0,
            SortOrder.Ascending);

        UpdateColumnHeaders(
            lvMissingFromDisk,
            0,
            SortOrder.Ascending);

        foreach (ColumnHeader column in lvMissingFromXml.Columns)
            column.Width = -2;

        foreach (ColumnHeader column in lvMissingFromDisk.Columns)
            column.Width = -2;
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

        string folder = Path.GetDirectoryName(rom.FullPath);

        if (string.IsNullOrWhiteSpace(folder))
            return;

        if (Directory.Exists(folder))
        {
            System.Diagnostics.Process.Start(
                "explorer.exe",
                $"\"{folder}\"");
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
}
