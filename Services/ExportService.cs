using RetroBatGameListComparator.Localization;
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
		sb.AppendLine($"              {L.ExportTitle}");
		sb.AppendLine("==============================================================");
        sb.AppendLine();

		sb.AppendLine(string.Format(
	L.ExportDate,
	DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
		sb.AppendLine();

		sb.AppendLine(string.Format(
	L.ExportRomFolder,
	romFolder));
		sb.AppendLine(string.Format(
	L.ExportGameList,
	gameListFile));
		sb.AppendLine(string.Format(
	L.ExportExtension,
	extension));

		sb.AppendLine();
        sb.AppendLine("--------------------------------------------------------------");
        sb.AppendLine();

		sb.AppendLine(string.Format(L.ComparedRoms, result.ComparedCount));
		sb.AppendLine(string.Format(L.XmlEntries, result.XmlCount));
		sb.AppendLine(string.Format(L.Matches, result.MatchingCount));
		sb.AppendLine(string.Format(L.IgnoredMultiDisk, result.MultiDiskIgnoredCount));
		sb.AppendLine(string.Format(L.HiddenGames, result.HiddenIgnoredCount));
		sb.AppendLine(string.Format(L.MissingXml, result.MissingFromXml.Count));
		sb.AppendLine(string.Format(L.MissingDisk, result.MissingFromDisk.Count));

		sb.AppendLine();
        sb.AppendLine("==============================================================");
        sb.AppendLine(L.MissingXmlSection);
        sb.AppendLine("==============================================================");
        sb.AppendLine();

        foreach (RomEntry rom in result.MissingFromXml.OrderBy(x => x.FileName))
        {
			sb.AppendLine(string.Format(L.Rom, rom.FileName));

			string folder = Path.GetDirectoryName(rom.RelativePath) ?? "";

            if (!string.IsNullOrWhiteSpace(folder))
				sb.AppendLine(string.Format(L.Folder, folder));

			sb.AppendLine(L.Separator);
		}

        sb.AppendLine();
        sb.AppendLine("==============================================================");
        sb.AppendLine(L.MissingDiskSection);
        sb.AppendLine("==============================================================");
        sb.AppendLine();

		sb.AppendLine(string.Format(L.Total, result.MissingFromDisk.Count));
		sb.AppendLine();

        foreach (RomEntry rom in result.MissingFromDisk.OrderBy(x => x.FileName))
        {
			sb.AppendLine(string.Format(L.Rom, rom.FileName));

			string folder = Path.GetDirectoryName(rom.RelativePath) ?? "";

            if (!string.IsNullOrWhiteSpace(folder))
				sb.AppendLine(string.Format(L.Folder, folder));

			sb.AppendLine(L.Separator);
		}

        sb.AppendLine();
        sb.AppendLine("==============================================================");
        sb.AppendLine(L.AllRomsSection);
        sb.AppendLine("==============================================================");
        sb.AppendLine();

        foreach (RomEntry rom in result.AllDiskRoms)
        {
            string folder = Path.GetDirectoryName(rom.RelativePath);

            if (string.IsNullOrWhiteSpace(folder))
				folder = L.RootFolder;

			sb.AppendLine($"{rom.FileName,-70} {folder}");
        }

        sb.AppendLine();
		sb.AppendLine(string.Format(L.Total, result.AllDiskRoms.Count));

		File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
    }

    public void ExportCsv(
        string fileName,
        ComparisonResult result)
    {
        using StreamWriter writer = new(fileName, false, Encoding.UTF8);

		writer.WriteLine(
	 $"{L.CsvState};{L.CsvName};{L.CsvExtension};{L.CsvFolder}");

		foreach (RomEntry rom in result.AllDiskRoms)
        {
			string state = L.CsvOk;

			if (result.MissingFromXml.Any(x =>
                x.FileName.Equals(
                    rom.FileName,
                    StringComparison.OrdinalIgnoreCase)))
            {
				state = L.CsvMissingXml;
			}

            writer.WriteLine(CreateCsvLine(state, rom));
        }

        foreach (RomEntry rom in result.MissingFromDisk)
        {
			writer.WriteLine(CreateCsvLine(L.CsvMissingDisk, rom));
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
			folder = L.RootFolder;

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