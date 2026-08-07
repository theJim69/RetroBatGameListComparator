using System;
using System.IO;
using System.Xml.Linq;
using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class NotGameRepairService
{
    public NotGameRepairResult Repair(string gameListPath)
    {
        ArgumentNullException.ThrowIfNull(gameListPath);

        XDocument document = XDocument.Load(gameListPath);

        NotGameRepairResult result = new();

        foreach (XElement game in document.Descendants("game"))
        {
            XElement? nameElement = game.Element("name");
            XElement? hiddenElement = game.Element("hidden");

            if (nameElement == null || hiddenElement == null)
                continue;

            string name = nameElement.Value.Trim();

            bool hidden =
                hiddenElement.Value.Trim().Equals(
                    "true",
                    StringComparison.OrdinalIgnoreCase);

            if (!hidden)
                continue;

            if (!name.StartsWith(
                    "ZZZ(NotGame):",
                    StringComparison.OrdinalIgnoreCase))
                continue;

            //----------------------------------------------------
            // Correction
            //----------------------------------------------------

            nameElement.Value = name.Replace(
                "ZZZ(NotGame):",
                "",
                StringComparison.OrdinalIgnoreCase).Trim();

            hiddenElement.Value = "false";

            result.RepairedCount++;
        }

        //----------------------------------------------------
        // Sauvegarde uniquement si nécessaire
        //----------------------------------------------------

        if (result.RepairedCount > 0)
        {
            result.BackupFile =
                $"{gameListPath}_BAK_{DateTime.Now:yyyyMMdd_HHmmss}";

            File.Copy(
                gameListPath,
                result.BackupFile,
                overwrite: false);

            document.Save(gameListPath);
        }

        return result;
    }
}