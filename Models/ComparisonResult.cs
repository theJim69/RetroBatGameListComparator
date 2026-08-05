using System.Collections.Generic;

namespace RetroBatGameListComparator.Models;

public class ComparisonResult
{
    public int DiskCount { get; set; }

    public int XmlCount { get; set; }

    public int MatchingCount { get; set; }

    public int ComparedCount { get; set; }

    public int MultiDiskIgnoredCount { get; set; }

    public int HiddenIgnoredCount { get; set; }

    public List<RomEntry> MissingFromXml { get; set; } = new();

    public List<RomEntry> MissingFromDisk { get; set; } = new();

    public List<RomEntry> AllDiskRoms { get; set; } = new();

    // <-- AJOUT
    public List<RomEntry> XmlGames { get; set; } = new();
}