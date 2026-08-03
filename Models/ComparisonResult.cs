using System.Collections.Generic;

namespace RetroBatGameListComparator.Models;

public class ComparisonResult
{
    public int DiskCount { get; set; }

    public int XmlCount { get; set; }

    public int MatchingCount { get; set; }

    public List<RomEntry> MissingFromXml { get; set; } = new();

    public List<RomEntry> MissingFromDisk { get; set; } = new();

    // Toutes les ROMs trouvées sur le disque
    public List<RomEntry> AllDiskRoms { get; set; } = new();
}