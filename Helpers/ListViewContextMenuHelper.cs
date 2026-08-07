using RetroBatGameListComparator.Localization;
using RetroBatGameListComparator.Models;
using System.Diagnostics;
using System.Windows.Forms;

namespace RetroBatGameListComparator.Helpers;

public static class ListViewContextMenuHelper
{
    public static void Attach(ListView listView)
    {
        ArgumentNullException.ThrowIfNull(listView);

        listView.KeyDown += ListView_KeyDown;

        ContextMenuStrip menu = new();
        bool isMissingFromXml = listView.Name == "lvMissingFromXml";

        ToolStripMenuItem copyName =
            new(L.CopyName);

        ToolStripMenuItem copyFull =
            new(L.CopyFullPath);

        ToolStripMenuItem openFolder =
            new(L.OpenFolder);

        ToolStripMenuItem openGameList =
    new(L.OpenGameList);

        menu.Items.Add(copyName);
        menu.Items.Add(copyFull);
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(openFolder);

        if (!isMissingFromXml)
        {
            menu.Items.Add(openGameList);
        }

        copyName.Click += (_, _) => CopyName(listView);
        copyFull.Click += (_, _) => CopyFullPath(listView);
        openFolder.Click += (_, _) => OpenFolder(listView);
        openGameList.Click += (_, _) => OpenGameList(listView);

        listView.MouseUp += (_, e) =>
        {
            if (e.Button != MouseButtons.Right)
                return;

            ListViewItem? item =
                listView.GetItemAt(e.X, e.Y);

            if (item == null)
                return;

            // Les lignes d'information n'ont pas de RomEntry.
            if (item.Tag is not RomEntry)
                return;

            listView.SelectedItems.Clear();

            item.Selected = true;
            item.Focused = true;

            menu.Show(listView, e.Location);
        };
    }

    private static void ListView_KeyDown(
        object? sender,
        KeyEventArgs e)
    {
        if (!e.Control || e.KeyCode != Keys.C)
            return;

        if (sender is not ListView listView)
            return;

        CopyName(listView);

        e.SuppressKeyPress = true;
    }

    private static RomEntry? GetSelectedRom(
        ListView listView)
    {
        if (listView.SelectedItems.Count == 0)
            return null;

        if (listView.SelectedItems[0].Tag is not RomEntry rom)
            return null;

        return rom;
    }

    private static void CopyName(
        ListView listView)
    {
        RomEntry? rom = GetSelectedRom(listView);

        if (rom == null)
            return;

        Clipboard.SetText(rom.FileName);
    }

    private static void CopyFullPath(
        ListView listView)
    {
        RomEntry? rom = GetSelectedRom(listView);

        if (rom == null)
            return;

        Clipboard.SetText(rom.FullPath);
    }

    private static void OpenFolder(
        ListView listView)
    {
        RomEntry? rom = GetSelectedRom(listView);

        if (rom == null)
            return;

        if (!File.Exists(rom.FullPath))
            return;

        Process.Start(new ProcessStartInfo
        {
            FileName = "explorer.exe",
            Arguments = $"/select,\"{rom.FullPath}\"",
            UseShellExecute = true
        });
    }
    private static void OpenGameList(
    ListView listView)
    {
        RomEntry? rom = GetSelectedRom(listView);

        if (rom == null)
            return;

        if (!File.Exists(rom.GameListPath))
        {
            MessageBox.Show(
                L.GameListNotFound,
                L.ApplicationTitle,
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
                string.Format(L.CannotOpenFile, ex.Message),
                L.ApplicationTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
