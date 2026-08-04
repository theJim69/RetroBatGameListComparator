using RetroBatGameListComparator.Models;
using System.Text;

namespace RetroBatGameListComparator.Services;

public class ExportService
{
    public void ExportTxt(
        string fileName,
        string romFolder,
        string gameListFile,
        string extension,
        ComparisonResult result)
    {
        StringBuilder sb = new();

        sb.AppendLine("==============================================================");
        sb.AppendLine("              RetroBat GameList Comparator");
        sb.AppendLine("==============================================================");
        sb.AppendLine();

        sb.AppendLine($"Date : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        sb.AppendLine();

        sb.AppendLine($"Dossier ROMs : {romFolder}");
        sb.AppendLine($"GameList     : {gameListFile}");
        sb.AppendLine($"Extension    : {extension}");

        sb.AppendLine();
        sb.AppendLine("--------------------------------------------------------------");
        sb.AppendLine();

        sb.AppendLine($"ROMs comparées     : {result.ComparedCount}");
        sb.AppendLine($"Entrées XML        : {result.XmlCount}");
        sb.AppendLine($"Correspondances    : {result.MatchingCount}");
        sb.AppendLine($"MultiDisk ignorés  : {result.MultiDiskIgnoredCount}");
        sb.AppendLine($"Jeux cachés        : {result.HiddenIgnoredCount}");
        sb.AppendLine($"Absentes XML       : {result.MissingFromXml.Count}");
        sb.AppendLine($"Absentes disque    : {result.MissingFromDisk.Count}");

        sb.AppendLine();
        sb.AppendLine("==============================================================");
        sb.AppendLine("ROMs absentes du XML");
        sb.AppendLine("==============================================================");
        sb.AppendLine();

        foreach (RomEntry rom in result.MissingFromXml.OrderBy(x => x.FileName))
        {
            sb.AppendLine($"ROM : {rom.FileName}");

            string folder = Path.GetDirectoryName(rom.RelativePath) ?? "";

            if (!string.IsNullOrWhiteSpace(folder))
                sb.AppendLine($"Dossier : {folder}");

            sb.AppendLine(new string('-', 55));
        }

        sb.AppendLine();
        sb.AppendLine("==============================================================");
        sb.AppendLine("ROMs absentes du disque");
        sb.AppendLine("==============================================================");
        sb.AppendLine();

        sb.AppendLine($"Total : {result.MissingFromDisk.Count}");
        sb.AppendLine();

        foreach (RomEntry rom in result.MissingFromDisk.OrderBy(x => x.FileName))
        {
            sb.AppendLine($"ROM : {rom.FileName}");

            string folder = Path.GetDirectoryName(rom.RelativePath) ?? "";

            if (!string.IsNullOrWhiteSpace(folder))
                sb.AppendLine($"Dossier : {folder}");

            sb.AppendLine(new string('-', 55));
        }

        sb.AppendLine();
        sb.AppendLine("==============================================================");
        sb.AppendLine("Liste complète des ROMs");
        sb.AppendLine("==============================================================");
        sb.AppendLine();

        foreach (RomEntry rom in result.AllDiskRoms)
        {
            string folder = Path.GetDirectoryName(rom.RelativePath);

            if (string.IsNullOrWhiteSpace(folder))
                folder = "[racine]";

            sb.AppendLine($"{rom.FileName,-70} {folder}");
        }

        sb.AppendLine();
        sb.AppendLine($"Total : {result.AllDiskRoms.Count}");

        File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
    }

    public void ExportCsv(
        string fileName,
        ComparisonResult result)
    {
        using StreamWriter writer = new(fileName, false, Encoding.UTF8);

        writer.WriteLine("Etat;Nom;Extension;Dossier");

        foreach (RomEntry rom in result.AllDiskRoms)
        {
            string state = "OK";

            if (result.MissingFromXml.Any(x =>
                x.FileName.Equals(
                    rom.FileName,
                    StringComparison.OrdinalIgnoreCase)))
            {
                state = "Absente XML";
            }

            writer.WriteLine(CreateCsvLine(state, rom));
        }

        foreach (RomEntry rom in result.MissingFromDisk)
        {
            writer.WriteLine(CreateCsvLine("Absente disque", rom));
        }
    }

    private static string CreateCsvLine(
        string state,
        RomEntry rom)
    {
        string name =
            Path.GetFileNameWithoutExtension(rom.FileName);

        string extension =
            Path.GetExtension(rom.FileName);

        string folder =
            Path.GetDirectoryName(rom.RelativePath);

        if (string.IsNullOrWhiteSpace(folder))
            folder = "[racine]";

        return string.Join(";",
            state,
            Escape(name),
            Escape(extension),
            Escape(folder));
    }

    private static string Escape(string value)
    {
        value ??= "";

        if (value.Contains(';') || value.Contains('"'))
        {
            value = "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        return value;
    }
}