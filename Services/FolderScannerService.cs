using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class FolderScannerService
{
    public List<RomEntry> Scan(
        string folder,
        List<string> extensions,
        bool recursive)
    {
        SearchOption searchOption = recursive
            ? SearchOption.AllDirectories
            : SearchOption.TopDirectoryOnly;

        HashSet<string> allowedExtensions = extensions
            .Select(e => e.Trim())
            .Where(e => !string.IsNullOrWhiteSpace(e))
            .Select(e => e.StartsWith(".") ? e : "." + e)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        List<RomEntry> entries = new();

        //----------------------------------------------------------
        // FICHIERS
        //----------------------------------------------------------

        foreach (string file in Directory.EnumerateFiles(
            folder,
            "*",
            searchOption))
        {
            string extension =
                Path.GetExtension(file);

            if (!allowedExtensions.Contains(extension))
                continue;

            entries.Add(
                new RomEntry
                {
                    FileName = Path.GetFileName(file),
                    FullPath = file,
                    RelativePath = Path.GetRelativePath(folder, file)
                });
        }

        //----------------------------------------------------------
        // DOSSIERS
        //
        // Certains systèmes RetroBat utilisent des dossiers
        // dont le nom possède une extension :
        //
        // cpower1.hypseus
        // game.teknoparrot
        // game.psvita
        //
        // Ces dossiers doivent être considérés comme des ROMs.
        //----------------------------------------------------------

        foreach (string directory in Directory.EnumerateDirectories(
            folder,
            "*",
            searchOption))
        {
            string extension =
                Path.GetExtension(directory);

            if (!allowedExtensions.Contains(extension))
                continue;

            entries.Add(
                new RomEntry
                {
                    FileName = Path.GetFileName(directory),
                    FullPath = directory,
                    RelativePath = Path.GetRelativePath(folder, directory)
                });
        }

        //----------------------------------------------------------
        // TRI
        //----------------------------------------------------------

        return entries
            .OrderBy(
                x => x.RelativePath,
                StringComparer.OrdinalIgnoreCase)
            .ToList();
    }
}