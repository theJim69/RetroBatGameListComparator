namespace RetroBatGameListComparator.Models;

public class SystemScanInfo
{
    public string Name { get; set; } = "";

    public string RomFolder { get; set; } = "";

    public string GameListPath { get; set; } = "";

    public bool HasGameList =>
        File.Exists(GameListPath);

    public ComparisonResult? Result { get; set; }
}