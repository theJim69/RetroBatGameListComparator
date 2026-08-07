using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RetroBatGameListComparator.Localization;
using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class NotGameReportService
{
    public void CreateReport(ComparisonResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        if (result.NotGameEntries.Count == 0)
        {
            MessageBox.Show(
                "No ZZZ(NotGame) entries found.",
                L.ApplicationTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        StringBuilder sb = new();

        sb.AppendLine("==========================================================");
        sb.AppendLine("             RetroBat GameList Comparator");
        sb.AppendLine("==========================================================");
        sb.AppendLine();

        sb.AppendLine(L.NotGameReportTitle);
        sb.AppendLine();

        sb.AppendLine(L.NotGameReportDescription);
        sb.AppendLine();

        sb.AppendLine(string.Format(L.ExportDate, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        sb.AppendLine(string.Format(L.ExportRomFolder, result.RomFolder));
        sb.AppendLine(string.Format(L.ExportGameList, result.GameListPath));
        sb.AppendLine();

        sb.AppendLine("----------------------------------------------------------");
        sb.AppendLine();

        sb.AppendLine(L.NotGamePlatformSummary);
        sb.AppendLine("----------------------------------------------------------");
        sb.AppendLine();

        sb.AppendLine($"{string.Format(L.PlatformGamesLabel, "")} : {result.ComparedCount}");
        sb.AppendLine($"⚠ {L.NotGame.Replace("{0}", result.NotGameEntries.Count.ToString())}");

        sb.AppendLine();
        sb.AppendLine("==========================================================");
        sb.AppendLine(L.NotGameReportDetectedEntries);
        sb.AppendLine("==========================================================");
        sb.AppendLine();

        int index = 1;

        foreach (RomEntry rom in result.NotGameEntries.OrderBy(r => r.DisplayName))
        {
            sb.AppendLine($"{index}.");
            sb.AppendLine();

            sb.AppendLine(L.NotGameReportGameName);
            sb.AppendLine(rom.DisplayName);
            sb.AppendLine();

            sb.AppendLine(L.NotGameReportRomFile);
            sb.AppendLine(rom.FileName);
            sb.AppendLine();

            sb.AppendLine(L.NotGameReportRelativePath);
            sb.AppendLine(rom.RelativePath);
            sb.AppendLine();

            sb.AppendLine("----------------------------------------------------------");
            sb.AppendLine();

            index++;
        }

        sb.AppendLine("==========================================================");
        sb.AppendLine(L.NotGameReportEnd);
        sb.AppendLine("==========================================================");
        sb.AppendLine();

        sb.AppendLine(L.GeneratedBy);
        sb.AppendLine("RetroBat GameList Comparator");

        string folder = Path.GetDirectoryName(result.GameListPath)!;

        string file = Path.Combine(
            folder,
            $"RetroBatGameListComparator_ZZZ(NotGame)_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

        File.WriteAllText(file, sb.ToString(), Encoding.UTF8);

        Process.Start(new ProcessStartInfo
        {
            FileName = file,
            UseShellExecute = true
        });
    }
}