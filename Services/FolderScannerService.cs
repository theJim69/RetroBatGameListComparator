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

        HashSet<string> allowedExtensions =
            extensions
                .Select(e => e.ToLowerInvariant())
                .ToHashSet();

        return Directory
            .EnumerateFiles(folder, "*", searchOption)
            .Where(file =>
                allowedExtensions.Contains(
                    Path.GetExtension(file).ToLowerInvariant()))
            .Select(file => new RomEntry
            {
                FileName = Path.GetFileName(file),
                FullPath = file,
                RelativePath = Path.GetRelativePath(folder, file)
            })
            .OrderBy(x => x.FileName)
            .ToList();
    }
}