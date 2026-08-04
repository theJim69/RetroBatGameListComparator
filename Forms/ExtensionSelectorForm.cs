using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RetroBatGameListComparator;

public partial class ExtensionSelectorForm : Form
{
    public List<string> SelectedExtensions { get; private set; } = new();

    private readonly List<string> _allExtensions = new();

    private readonly HashSet<string> _selected =
        new(StringComparer.OrdinalIgnoreCase);

    public ExtensionSelectorForm(
        IEnumerable<string> allExtensions,
        IEnumerable<string> selectedExtensions)
    {
        InitializeComponent();

        _allExtensions.AddRange(allExtensions.OrderBy(x => x));

        foreach (string extension in selectedExtensions)
        {
            _selected.Add(extension);
        }

        RefreshList();
    }

    protected override void OnShown(EventArgs e)
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
                DialogResult = DialogResult.Cancel;
                Close();
            }

            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
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
            _selected.Add(e.Item.Text);
        else
            _selected.Remove(e.Item.Text);

        UpdateCounter();
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lvExtensions.Items)
        {
            item.Checked = true;
        }
    }

    private void btnClearAll_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lvExtensions.Items)
        {
            item.Checked = false;
        }
    }

    private void UpdateCounter()
    {
        lblCount.Text =
            $"{_selected.Count} extension(s) sélectionnée(s)";
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        SelectedExtensions = _selected
            .OrderBy(x => x)
            .ToList();

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void RefreshList()
    {
        lvExtensions.BeginUpdate();

        lvExtensions.Items.Clear();

        string filter = txtSearch.Text.Trim();

        IEnumerable<string> extensions = _allExtensions;

        if (!string.IsNullOrWhiteSpace(filter))
        {
            extensions = extensions.Where(x =>
                x.Contains(
                    filter,
                    StringComparison.OrdinalIgnoreCase));
        }

        foreach (string extension in extensions)
        {
            ListViewItem item = new(extension);

            item.Checked = _selected.Contains(extension);

            lvExtensions.Items.Add(item);
        }

        UpdateCounter();

        lvExtensions.EndUpdate();
    }
}