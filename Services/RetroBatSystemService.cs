using System.Xml.Linq;
using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class RetroBatSystemService
{
    private const string EmulationStationFolder =
        "emulationstation";

    private const string ConfigurationFolder =
        ".emulationstation";

    public PlatformExtensionInfo GetPlatformExtensions(
        string romFolder,
        string platform)
    {
        if (string.IsNullOrWhiteSpace(romFolder) ||
            string.IsNullOrWhiteSpace(platform))
        {
            return new PlatformExtensionInfo
            {
                Platform = platform
            };
        }

        string? configurationFolder =
            FindConfigurationFolder(romFolder);

        if (configurationFolder == null)
        {
            return new PlatformExtensionInfo
            {
                Platform = platform
            };
        }

        // ---------------------------------------------------------
        // 1. Recherche dans les configurations custom
        // ---------------------------------------------------------

        string[] customFiles =
            Directory.GetFiles(
                configurationFolder,
                "es_systems_*.cfg",
                SearchOption.TopDirectoryOnly);

        foreach (string file in customFiles.OrderBy(x => x))
        {
            PlatformExtensionInfo? result =
                ReadPlatformFromFile(
                    file,
                    platform,
                    true);

            if (result != null)
                return result;
        }

        // ---------------------------------------------------------
        // 2. Recherche dans la configuration principale
        // ---------------------------------------------------------

        string mainFile =
            Path.Combine(
                configurationFolder,
                "es_systems.cfg");

        if (File.Exists(mainFile))
        {
            PlatformExtensionInfo? result =
                ReadPlatformFromFile(
                    mainFile,
                    platform,
                    false);

            if (result != null)
                return result;
        }

        // ---------------------------------------------------------
        // 3. Plateforme non trouvée
        // ---------------------------------------------------------

        return new PlatformExtensionInfo
        {
            Platform = platform
        };
    }

    private static PlatformExtensionInfo? ReadPlatformFromFile(
        string filePath,
        string platform,
        bool isCustom)
    {
        try
        {
            XDocument document =
                XDocument.Load(filePath);

            IEnumerable<XElement> systems =
                document.Descendants("system");

            foreach (XElement system in systems)
            {
                string? name =
                    system.Element("name")?.Value.Trim();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                if (!name.Equals(
                        platform,
                        StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                XElement? extensionElement =
                    system.Element("extension");

                List<string> extensions =
                    extensionElement == null
                        ? new List<string>()
                        : ParseExtensions(
                            extensionElement.Value);

                return new PlatformExtensionInfo
                {
                    Platform = platform,
                    DefaultExtensions = extensions,
                    SourceFile =
                        Path.GetFileName(filePath),
                    IsCustomConfiguration =
                        isCustom
                };
            }
        }
        catch
        {
            // Une configuration invalide ne doit pas
            // empêcher le Comparator de fonctionner.
        }

        return null;
    }

    private static List<string> ParseExtensions(
        string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new List<string>();

        return value
            .Split(
                new[]
                {
                    ' ',
                    '\t',
                    '\r',
                    '\n'
                },
                StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x =>
                x.StartsWith(".")
                    ? x
                    : "." + x)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(x => x)
            .ToList();
    }

    private static string? FindConfigurationFolder(
        string romFolder)
    {
        DirectoryInfo? current =
            new DirectoryInfo(romFolder);

        while (current != null)
        {
            string candidate =
                Path.Combine(
                    current.FullName,
                    EmulationStationFolder,
                    ConfigurationFolder);

            if (Directory.Exists(candidate))
                return candidate;

            current = current.Parent;
        }

        return null;
    }
}