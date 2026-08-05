using RetroBatGameListComparator.Localization;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace RetroBatGameListComparator.Services;

public class GameListDiagnosticService
{
    public string Analyze(string gameListPath)
    {
        XDocument document = XDocument.Load(gameListPath);

        int totalGames = 0;
        int hiddenGames = 0;
        int visibleGames = 0;

        int chdCount = 0;
        int m3uCount = 0;
        int cueCount = 0;
        int isoCount = 0;
        int otherExtensions = 0;

        int multiDiskGames = 0;
        int multiDiskFiles = 0;

        int gamesWithoutPath = 0;
        int gamesWithoutName = 0;

        Dictionary<string, int> extensionCounter =
            new(StringComparer.OrdinalIgnoreCase);

        Dictionary<string, int> pathCounter =
            new(StringComparer.OrdinalIgnoreCase);

        List<string> duplicatePaths = new();
        List<string> suspicious = new();

        foreach (XElement game in document.Descendants("game"))
        {
            totalGames++;

            //------------------------------------------------------
            // path
            //------------------------------------------------------

            XElement? pathElement = game.Element("path");

            if (pathElement == null)
            {
                gamesWithoutPath++;
                suspicious.Add(L.GameWithoutPath);
                continue;
            }

            string relativePath =
                pathElement.Value
                    .Trim()
                    .Replace("./", "");

            if (string.IsNullOrWhiteSpace(relativePath))
            {
                gamesWithoutPath++;
                suspicious.Add(L.EmptyPath);
                continue;
            }

            //------------------------------------------------------
            // doublons
            //------------------------------------------------------

            if (pathCounter.ContainsKey(relativePath))
            {
                pathCounter[relativePath]++;
            }
            else
            {
                pathCounter.Add(relativePath, 1);
            }

            //------------------------------------------------------
            // hidden
            //------------------------------------------------------

            bool hidden = false;

            XElement? hiddenElement =
                game.Element("hidden");

            if (hiddenElement != null)
            {
                string value =
                    hiddenElement.Value
                        .Trim()
                        .ToLowerInvariant();

                hidden =
                    value == "true"
                    || value == "1";
            }

            if (hidden)
                hiddenGames++;
            else
                visibleGames++;

            //------------------------------------------------------
            // name
            //------------------------------------------------------

            XElement? nameElement =
                game.Element("name");

            if (nameElement == null ||
                string.IsNullOrWhiteSpace(nameElement.Value))
            {
                gamesWithoutName++;
            }

            //------------------------------------------------------
            // extension
            //------------------------------------------------------

            string extension =
                Path.GetExtension(relativePath)
                    .ToLowerInvariant();

            if (!extensionCounter.ContainsKey(extension))
                extensionCounter.Add(extension, 0);

            extensionCounter[extension]++;

            switch (extension)
            {
                case ".chd":
                    chdCount++;
                    break;

                case ".m3u":
                    m3uCount++;
                    break;

                case ".cue":
                    cueCount++;
                    break;

                case ".iso":
                    isoCount++;
                    break;

                default:
                    otherExtensions++;
                    suspicious.Add(relativePath);
                    break;
            }

            //------------------------------------------------------
            // multidisk
            //------------------------------------------------------

            XElement? multidisk =
                game.Element("multidisk");

            if (multidisk != null)
            {
                multiDiskGames++;

                try
                {
                    List<string>? disks =
                        JsonSerializer.Deserialize<List<string>>(
                            multidisk.Value);

                    if (disks != null)
                        multiDiskFiles += disks.Count;
                }
                catch
                {
                    suspicious.Add(
    string.Format(
        L.InvalidMultiDiskJson,
        relativePath));
                }
            }
        }

        //----------------------------------------------------------
        // doublons
        //----------------------------------------------------------

        foreach (var pair in pathCounter)
        {
            if (pair.Value > 1)
                duplicatePaths.Add(pair.Key);
        }

        //----------------------------------------------------------
        // Rapport
        //----------------------------------------------------------

        StringBuilder sb = new();

        sb.AppendLine("==============================================");
        sb.AppendLine($"          {L.DiagnosticTitle}");
        sb.AppendLine("==============================================");
        sb.AppendLine();

        sb.AppendLine(string.Format(L.TotalGames, totalGames));
        sb.AppendLine(string.Format(L.VisibleGames, visibleGames));
        sb.AppendLine(string.Format(L.HiddenGames, hiddenGames));
        sb.AppendLine();

        sb.AppendLine(string.Format(L.ChdGames, chdCount));
        sb.AppendLine(string.Format(L.M3uGames, m3uCount));
        sb.AppendLine(string.Format(L.CueGames, cueCount));
        sb.AppendLine(string.Format(L.IsoGames, isoCount));
        sb.AppendLine(string.Format(L.OtherExtensions, otherExtensions));
        sb.AppendLine();

        sb.AppendLine(string.Format(L.MultiDiskGames, multiDiskGames));
        sb.AppendLine(string.Format(L.MultiDiskFiles, multiDiskFiles));
        sb.AppendLine();

        sb.AppendLine(string.Format(L.DuplicatePathCount, duplicatePaths.Count));
        sb.AppendLine(string.Format(L.GamesWithoutPath, gamesWithoutPath));
        sb.AppendLine(string.Format(L.GamesWithoutName, gamesWithoutName));
        sb.AppendLine();

        sb.AppendLine("----------------------------------------------");
        sb.AppendLine(L.ExtensionDistribution);
        sb.AppendLine("----------------------------------------------");

        foreach (var ext in extensionCounter.OrderBy(x => x.Key))
        {
            sb.AppendLine($"{ext.Key,-10} {ext.Value}");
        }

        sb.AppendLine();

        if (duplicatePaths.Any())
        {
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine(L.DuplicatePaths);
            sb.AppendLine("----------------------------------------------");

            foreach (string path in duplicatePaths)
                sb.AppendLine(path);

            sb.AppendLine();
        }

        if (suspicious.Any())
        {
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine(L.SuspiciousEntries);
            sb.AppendLine("----------------------------------------------");

            foreach (string s in suspicious.Distinct())
                sb.AppendLine(s);
        }

        return sb.ToString();
    }
}