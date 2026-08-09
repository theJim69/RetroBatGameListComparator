using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class ComparisonService
{
    public ComparisonResult Compare(
        List<RomEntry> disk,
        GameListData gameList)
    {
        ComparisonResult result = new();

        List<RomEntry> xml = gameList.Games;

        //----------------------------------------------------------
        // Statistiques
        //----------------------------------------------------------

        result.DiskCount = disk.Count;

        result.ComparedCount =
            disk.Count(r =>
                !gameList.HiddenFiles.Contains(r.FileName) &&
                !gameList.MultiDiskFiles.Contains(r.FileName));

        result.XmlCount =
            xml.Count;

        result.MultiDiskIgnoredCount =
            gameList.MultiDiskIgnoredCount;

        result.HiddenIgnoredCount =
            gameList.HiddenIgnoredCount;

        // Nombre de jeux ScreenScraper identifiés comme
        // "ZZZ(notgame)"
        result.NotGameCount =
            gameList.NotGameCount;
        result.NotGameEntries.AddRange(gameList.NotGameEntries);

        result.RomFolder = gameList.RomFolder;
        result.GameListPath = gameList.GameListPath;

        //----------------------------------------------------------
        // Préparation des HashSet
        //----------------------------------------------------------

        HashSet<string> diskPaths =
            disk
                .Where(r =>
                    !gameList.HiddenFiles.Contains(r.FileName) &&
                    !gameList.MultiDiskFiles.Contains(r.FileName))
                .Select(x =>
                    NormalizePath(x.RelativePath))
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

        HashSet<string> xmlPaths =
            xml
                .Select(x =>
                    NormalizePath(x.RelativePath))
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

        //----------------------------------------------------------
        // ROM présentes sur le disque
        //----------------------------------------------------------

        foreach (RomEntry rom in disk)
        {
            if (gameList.HiddenFiles.Contains(rom.FileName))
                continue;

            if (gameList.MultiDiskFiles.Contains(rom.FileName))
                continue;

            if (xmlPaths.Contains(
                    NormalizePath(rom.RelativePath)))
            {
                result.MatchingCount++;
            }
            else
            {
                result.MissingFromXml.Add(rom);
            }
        }

        //----------------------------------------------------------
        // ROM présentes dans le XML
        //----------------------------------------------------------

        foreach (RomEntry rom in xml)
        {
            // Hidden games are ignored.
            if (gameList.HiddenFiles.Contains(rom.FileName))
                continue;

            // MultiDisk child files are ignored.
            if (gameList.MultiDiskFiles.Contains(rom.FileName))
                continue;


            if (!diskPaths.Contains(
        NormalizePath(rom.RelativePath)))
            {
                // Ne pas compter les dossiers spéciaux RetroBat
                if (rom.IsFolder)
                    continue;

                result.MissingFromDisk.Add(rom);
            }
        }   

        //----------------------------------------------------------
        // Liste complète des ROMs comparées
        //----------------------------------------------------------

        result.AllDiskRoms =
            disk
                .Where(r =>
                    !gameList.HiddenFiles.Contains(r.FileName) &&
                    !gameList.MultiDiskFiles.Contains(r.FileName))
                .OrderBy(x => x.RelativePath)
                .ToList();

        return result;
    }
    

    //----------------------------------------------------------
    // Normalize path
    //----------------------------------------------------------

    private static string NormalizePath(string path)
    {
        return path
            .Replace('\\', '/')
            .TrimStart('.', '/')
            .Trim();
    }

}