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

        ToolStripMenuItem copyName =
            new("📋 Copier le nom");

        ToolStripMenuItem copyFull =
            new("📂 Copier le chemin complet");

        ToolStripMenuItem openFolder =
            new("📂 Ouvrir le dossier");

        menu.Items.Add(copyName);
        menu.Items.Add(copyFull);
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(openFolder);

        copyName.Click += (_, _) => CopyName(listView);
        copyFull.Click += (_, _) => CopyFullPath(listView);
        openFolder.Click += (_, _) => OpenFolder(listView);

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
}