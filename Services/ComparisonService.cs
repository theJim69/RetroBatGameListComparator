using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class ComparisonService
{
    public ComparisonResult Compare(
        List<RomEntry> disk,
        List<RomEntry> xml)
    {
        ComparisonResult result = new();

        result.DiskCount = disk.Count;
        result.XmlCount = xml.Count;

        HashSet<string> diskFiles =
            disk.Select(x => x.FileName)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

        HashSet<string> xmlFiles =
            xml.Select(x => x.FileName)
               .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (RomEntry rom in disk)
        {
            if (xmlFiles.Contains(rom.FileName))
                result.MatchingCount++;
            else
                result.MissingFromXml.Add(rom);
        }

        foreach (RomEntry rom in xml)
        {
            if (!diskFiles.Contains(rom.FileName))
                result.MissingFromDisk.Add(rom);
        }

        result.AllDiskRoms = disk
            .OrderBy(x => x.FileName)
            .ToList();

        return result;
    }
}