using RetroBatGameListComparator.Localization;
using RetroBatGameListComparator.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RetroBatGameListComparator;

public partial class ExtensionSelectorForm : Form
{
    public List<string> SelectedExtensions { get; private set; } = new();

    private readonly List<string> _allExtensions = new();

    private readonly HashSet<string> _selected =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly HashSet<string> _defaultExtensions =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly PlatformExtensionInfo _platformInfo;

    private Panel _defaultInfoPanel = null!;
    private Label _defaultInfoLabel = null!;

    // =========================================================
    // CONSTRUCTEUR SANS PLATEFORME
    // =========================================================

    public ExtensionSelectorForm(
        IEnumerable<string> allExtensions,
        IEnumerable<string> selectedExtensions)
        : this(
            allExtensions,
            selectedExtensions,
            new PlatformExtensionInfo())
    {
    }

    // =========================================================
    // CONSTRUCTEUR AVEC PLATEFORME
    // =========================================================

    public ExtensionSelectorForm(
        IEnumerable<string> allExtensions,
        IEnumerable<string> selectedExtensions,
        PlatformExtensionInfo platformInfo)
    {
        InitializeComponent();

        ResizeExtensionColumns();

        lvExtensions.Resize += (_, _) =>
        {
            ResizeExtensionColumns();
        };

        colDefault.Text = string.Empty;

        ApplyLocalization();

        _platformInfo = platformInfo;

        // ---------------------------------------------------------
        // Toutes les extensions disponibles.
        // Les extensions par défaut de la plateforme sont ajoutées
        // même si elles n'existaient pas encore dans la liste.
        // ---------------------------------------------------------

        _allExtensions.AddRange(
            allExtensions
                .Concat(platformInfo.DefaultExtensions)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x));

        // ---------------------------------------------------------
        // Extensions par défaut de la plateforme.
        // ---------------------------------------------------------

        foreach (string extension in platformInfo.DefaultExtensions)
        {
            _defaultExtensions.Add(extension);

            // Les extensions par défaut sont sélectionnées
            // automatiquement.
            _selected.Add(extension);
        }

        // ---------------------------------------------------------
        // Extensions déjà sélectionnées par l'utilisateur.
        // ---------------------------------------------------------

        foreach (string extension in selectedExtensions)
        {
            _selected.Add(extension);
        }

        ApplyLocalization();

        CreateDefaultInfoPanel();

        LocalizationService.LanguageChanged +=
            OnLanguageChanged;

        RefreshList();
    }

    private void OnLanguageChanged(
        object? sender,
        EventArgs e)
    {
        ApplyLocalization();
        UpdateDefaultInfoPanel();
    }

    private void ResizeExtensionColumns()
    {
        int availableWidth =
            lvExtensions.ClientSize.Width
            - colExtension.Width
            - 4;

        colDefault.Width =
            Math.Max(80, availableWidth);
    }

    protected override void OnFormClosed(
        FormClosedEventArgs e)
    {
        LocalizationService.LanguageChanged -=
            OnLanguageChanged;

        base.OnFormClosed(e);
    }

    protected override void OnShown(
        EventArgs e)
    {
        base.OnShown(e);

        txtSearch.Focus();
    }

    protected override bool ProcessCmdKey(
        ref Message msg,
        Keys keyData)
    {
        if (keyData == Keys.Escape)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Clear();
                txtSearch.Focus();
            }
            else
            {
                DialogResult =
                    DialogResult.Cancel;

                Close();
            }

            return true;
        }

        return base.ProcessCmdKey(
            ref msg,
            keyData);
    }

    private void ApplyLocalization()
    {
        Text =
            L.ExtensionSelectorTitle;

        lblSearch.Text =
            L.SearchLabel;

        colExtension.Text =
            L.ExtensionColumn;

        btnSelectAll.Text =
            L.SelectAll;

        btnClearAll.Text =
            L.ClearAll;

        btnCancel.Text =
            L.Cancel;
    }

    private void CreateDefaultInfoPanel()
    {
        // =========================================================
        // DIMENSIONS GÉNÉRALES
        // =========================================================

        ClientSize =
            new Size(
                430,
                575);

        // =========================================================
        // RECHERCHE
        // =========================================================

        lblSearch.Location =
            new Point(
                12,
                13);

        txtSearch.Location =
            new Point(
                90,
                10);

        txtSearch.Size =
            new Size(
                325,
                23);

        // =========================================================
        // BOUTONS DU HAUT
        // =========================================================

        btnSelectAll.Location =
            new Point(
                12,
                46);

        btnClearAll.Location =
            new Point(
                125,
                46);

        // =========================================================
        // LISTE DES EXTENSIONS
        // =========================================================

        lvExtensions.Location =
            new Point(
                12,
                85);

        lvExtensions.Size =
            new Size(
                405,
                335);

        // =========================================================
        // PANNEAU D'INFORMATION
        // =========================================================

        _defaultInfoPanel =
            new Panel
            {
                Location =
                    new Point(
                        12,
                        445),

                Size =
                    new Size(
                        405,
                        68),

                BorderStyle =
                    BorderStyle.FixedSingle,

                BackColor =
                    Color.FromArgb(
                        255,
                        248,
                        248)
            };

        _defaultInfoLabel =
            new Label
            {
                Location =
                    new Point(
                        8,
                        7),

                Size =
                    new Size(
                        387,
                        52),

                AutoSize = false,

                Font =
                    new Font(
                        Font.FontFamily,
                        8.5F,
                        FontStyle.Regular),

                ForeColor =
                    Color.FromArgb(
                        150,
                        80,
                        80)
            };

        _defaultInfoPanel.Controls.Add(
            _defaultInfoLabel);

        Controls.Add(
            _defaultInfoPanel);

        // =========================================================
        // COMPTEUR
        // =========================================================

        lblCount.Location =
            new Point(
                12,
                425);

        // =========================================================
        // BOUTONS DU BAS
        // =========================================================

        btnOK.Location =
            new Point(
                252,
                530);

        btnCancel.Location =
            new Point(
                340,
                530);

        UpdateDefaultInfoPanel();
    }

    private void UpdateDefaultInfoPanel()
    {
        if (_defaultInfoPanel == null ||
            _defaultInfoLabel == null)
        {
            return;
        }

        if (!_platformInfo.Found)
        {
            _defaultInfoPanel.Visible =
                false;

            return;
        }

        string extensions =
            string.Join(
                ", ",
                _platformInfo
                    .DefaultExtensions
                    .OrderBy(x => x));

        string source =
            _platformInfo.SourceFile
            ?? string.Empty;

        _defaultInfoLabel.Text =
            string.Format(
                L.DefaultPlatformExtensionsInfo,
                _platformInfo.Platform,
                extensions,
                source);

        _defaultInfoPanel.Visible =
            true;
    }

      private void txtSearch_TextChanged(
        object sender,
        EventArgs e)
    {
        RefreshList();
    }

    private void lvExtensions_ItemChecked(
        object sender,
        ItemCheckedEventArgs e)
    {
        if (e.Item.Checked)
        {
            _selected.Add(
                e.Item.Text);
        }
        else
        {
            _selected.Remove(
                e.Item.Text);
        }

        UpdateCounter();
    }

    private void btnSelectAll_Click(
        object sender,
        EventArgs e)
    {
        foreach (ListViewItem item
            in lvExtensions.Items)
        {
            item.Checked = true;
        }
    }

    private void btnClearAll_Click(
        object sender,
        EventArgs e)
    {
        foreach (ListViewItem item
            in lvExtensions.Items)
        {
            item.Checked = false;
        }
    }

    private void UpdateCounter()
    {
        lblCount.Text =
            string.Format(
                L.SelectedExtensions,
                _selected.Count);
    }

    private void btnOK_Click(
        object sender,
        EventArgs e)
    {
        SelectedExtensions =
            _selected
                .OrderBy(x => x)
                .ToList();

        DialogResult =
            DialogResult.OK;

        Close();
    }

    private void btnCancel_Click(
        object sender,
        EventArgs e)
    {
        DialogResult =
            DialogResult.Cancel;

        Close();
    }

    private void RefreshList()
    {
        lvExtensions.BeginUpdate();

        try
        {
            lvExtensions.Items.Clear();

            string filter =
                txtSearch.Text.Trim();

            IEnumerable<string> extensions =
                _allExtensions;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                extensions =
                    extensions.Where(x =>
                        x.Contains(
                            filter,
                            StringComparison.OrdinalIgnoreCase));
            }

            foreach (string extension
                in extensions)
            {
                ListViewItem item =
                    new(extension);

                bool isDefault =
                    _defaultExtensions.Contains(
                        extension);

                // -------------------------------------------------
                // Deuxième colonne :
                // affiche "Défaut" pour les extensions proposées
                // par la plateforme.
                // -------------------------------------------------

                item.SubItems.Add(
                    isDefault
                        ? L.DefaultColumn
                        : string.Empty);

                // -------------------------------------------------
                // Les extensions par défaut sont sélectionnées.
                // -------------------------------------------------

                item.Checked =
                    _selected.Contains(
                        extension);

                // -------------------------------------------------
                // Extensions par défaut :
                // texte normal / noir.
                //
                // Autres extensions :
                // gris clair.
                // -------------------------------------------------

                if (isDefault)
                {
                    item.ForeColor =
                        SystemColors.WindowText;
                }
                else
                {
                    item.ForeColor =
                        Color.FromArgb(
                            190,
                            190,
                            190);
                }

                lvExtensions.Items.Add(
                    item);
            }

            UpdateCounter();
        }
        finally
        {
            lvExtensions.EndUpdate();
        }
    }
}