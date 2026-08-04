using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class SystemAnalysisService
{
    private readonly FolderScannerService _folderScanner = new();
    private readonly XmlReaderService _xmlReader = new();
    private readonly ComparisonService _comparison = new();

    public ComparisonResult Analyze(
        string romFolder,
        string gameListPath,
        List<string> extensions,
        bool recursive)
    {
        List<RomEntry> disk =
            _folderScanner.Scan(
                romFolder,
                extensions,
                recursive);

        GameListData xml =
            _xmlReader.Read(
                gameListPath,
                romFolder);

        ComparisonResult result =
            _comparison.Compare(
                disk,
                xml);

        // **************
        // AJOUT
        // **************

        result.XmlGames =
            xml.Games
                .OrderBy(x => x.RelativePath)
                .ToList();

        return result;
    }
}