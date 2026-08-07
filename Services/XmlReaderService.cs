using System.Text.Json;
using System.Xml.Linq;
using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class XmlReaderService
{
    public GameListData Read(
        string xmlFile,
        string romFolder)
    {
        XDocument document = XDocument.Load(xmlFile);

        GameListData result = new();

        foreach (XElement pathElement in document.Descendants("path"))
        {
            XElement? game = pathElement.Parent;

            if (game == null)
                continue;

            string relativePath =
                pathElement.Value
                    .Trim()
                    .Replace("./", "")
                    .Replace('\\', '/');

            if (string.IsNullOrWhiteSpace(relativePath))
                continue;

            //---------------------------------------------------------
            // Jeu caché ?
            //---------------------------------------------------------

            XElement? hiddenElement =
                game.Element("hidden");

            bool isHidden = false;

            if (hiddenElement != null)
            {
                string value =
                    hiddenElement.Value
                        .Trim()
                        .ToLowerInvariant();

                isHidden =
                    value == "true"
                    || value == "1";
            }

                

            //---------------------------------------------------------
            // multidisk
            //---------------------------------------------------------

            XElement? multidiskElement =
                game.Element("multidisk");

            List<string> multidiskFiles = new();

            if (multidiskElement != null)
            {
                try
                {
                    List<string>? disks =
                        JsonSerializer.Deserialize<List<string>>(
                            multidiskElement.Value.Trim());

                    if (disks != null)
                    {
                        foreach (string disk in disks)
                        {
                            string fileName =
                                Path.GetFileName(
                                    disk
                                        .Replace("./", "")
                                        .Replace('\\', '/'));

                            multidiskFiles.Add(fileName);

                            result.MultiDiskFiles.Add(fileName);
                        }
                    }
                }
                catch
                {
                    // Balise multidisk invalide.
                    // On l'ignore simplement.
                }
            }

            //---------------------------------------------------------
            // Jeu caché
            //---------------------------------------------------------

            if (isHidden)
            {
                result.HiddenFiles.Add(
                    Path.GetFileName(relativePath));

                foreach (string disk in multidiskFiles)
                {
                    result.HiddenFiles.Add(disk);
                }

                continue;
            }

            //---------------------------------------------------------
            // Jeu principal
            //---------------------------------------------------------

            result.Games.Add(
                new RomEntry

                {
                    FileName =
                        Path.GetFileName(relativePath),

                    RelativePath =
                        relativePath,

                    FullPath =
                        Path.Combine(
                            romFolder,
                            relativePath),

                    GameListPath =
                        xmlFile,

                    ExistsInGameList = true,

                   });
        }

        result.Games.Sort(
            (a, b) =>
                string.Compare(
                    a.FileName,
                    b.FileName,
                    StringComparison.OrdinalIgnoreCase));
        var duplicates =
    result.Games
        .GroupBy(g => NormalizePath(g.RelativePath))
        .Where(g => g.Count() > 1);

        File.WriteAllLines(
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DuplicatePaths.txt"),
            duplicates.SelectMany(g =>
            {
                List<string> lines = new();

                lines.Add("====================================");
                lines.Add(g.Key);

                foreach (var game in g)
                    lines.Add(game.FileName);

                return lines;
            }));

        //---------------------------------------------------------
        // ZZZ(NotGame) statistics
        //---------------------------------------------------------

        foreach (XElement game in document.Descendants("game"))
        {
            XElement? hiddenElement = game.Element("hidden");
            XElement? nameElement = game.Element("name");

            if (hiddenElement == null || nameElement == null)
                continue;

            string name = nameElement.Value.Trim();

            bool isHidden =
                hiddenElement.Value.Trim()
                    .Equals("true", StringComparison.OrdinalIgnoreCase);

            if (isHidden &&
     name.StartsWith("ZZZ(", StringComparison.OrdinalIgnoreCase) &&
     name.Contains("notgame", StringComparison.OrdinalIgnoreCase))
            {
                result.NotGameCount++;

                string relativePath =
                    game.Element("path")?
                        .Value
                        .Trim()
                        .Replace("./", "")
                        .Replace('\\', '/')
                    ?? string.Empty;

                result.NotGameEntries.Add(new RomEntry
                {
                    FileName = Path.GetFileName(relativePath),
                    RelativePath = relativePath,
                    FullPath = Path.Combine(romFolder, relativePath),
                    GameListPath = xmlFile,
                    ExistsInGameList = true,
                    IsNotGame = true
                });
            }
        }

        result.RomFolder = romFolder;
        result.GameListPath = xmlFile;

        return result;
    }
    private static string NormalizePath(string path)
    {
        return path
            .Replace('\\', '/')
            .TrimStart('.', '/')
            .Trim();
    }
}