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
                suspicious.Add("<game> sans <path>");
                continue;
            }

            string relativePath =
                pathElement.Value
                    .Trim()
                    .Replace("./", "");

            if (string.IsNullOrWhiteSpace(relativePath))
            {
                gamesWithoutPath++;
                suspicious.Add("<path> vide");
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
                        $"JSON multidisk invalide : {relativePath}");
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
        sb.AppendLine("          GameList Diagnostic");
        sb.AppendLine("==============================================");
        sb.AppendLine();

        sb.AppendLine($"Total <game>              : {totalGames}");
        sb.AppendLine($"Jeux visibles             : {visibleGames}");
        sb.AppendLine($"Jeux cachés               : {hiddenGames}");
        sb.AppendLine();

        sb.AppendLine($"Jeux .chd                 : {chdCount}");
        sb.AppendLine($"Jeux .m3u                 : {m3uCount}");
        sb.AppendLine($"Jeux .cue                 : {cueCount}");
        sb.AppendLine($"Jeux .iso                 : {isoCount}");
        sb.AppendLine($"Autres extensions         : {otherExtensions}");
        sb.AppendLine();

        sb.AppendLine($"Jeux MultiDisk            : {multiDiskGames}");
        sb.AppendLine($"Fichiers MultiDisk        : {multiDiskFiles}");
        sb.AppendLine();

        sb.AppendLine($"Doublons de <path>        : {duplicatePaths.Count}");
        sb.AppendLine($"Jeux sans <path>          : {gamesWithoutPath}");
        sb.AppendLine($"Jeux sans <name>          : {gamesWithoutName}");
        sb.AppendLine();

        sb.AppendLine("----------------------------------------------");
        sb.AppendLine("Répartition des extensions");
        sb.AppendLine("----------------------------------------------");

        foreach (var ext in extensionCounter.OrderBy(x => x.Key))
        {
            sb.AppendLine($"{ext.Key,-10} {ext.Value}");
        }

        sb.AppendLine();

        if (duplicatePaths.Any())
        {
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine("Doublons");
            sb.AppendLine("----------------------------------------------");

            foreach (string path in duplicatePaths)
                sb.AppendLine(path);

            sb.AppendLine();
        }

        if (suspicious.Any())
        {
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine("Entrées suspectes");
            sb.AppendLine("----------------------------------------------");

            foreach (string s in suspicious.Distinct())
                sb.AppendLine(s);
        }

        return sb.ToString();
    }
}