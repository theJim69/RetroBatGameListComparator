using RetroBatGameListComparator.Helpers;

namespace RetroBatGameListComparator.Services;

public class ExtensionService
{
    public List<string> LoadExtensions()
    {
        if (!File.Exists(Constants.ExtensionsFile))
            return new List<string>();

        return File.ReadAllLines(Constants.ExtensionsFile)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(Normalize)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(x => x)
            .ToList();
    }

    public string Normalize(string extension)
    {
        extension = extension.Trim().ToLowerInvariant();

        if (!extension.StartsWith("."))
            extension = "." + extension;

        return extension;
    }

    /// <summary>
    /// Convertit une chaîne comme :
    /// zip;7z,chd
    /// en
    /// .zip .7z .chd
    /// </summary>
    public List<string> NormalizeList(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new();

        char[] separators =
        {
        ';',
        ',',
        '|',
        ' '
    };

        return text
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .Select(Normalize)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(x => x)
            .ToList();
    }

    public string Format(IEnumerable<string> extensions)
    {
        return string.Join("; ",
            extensions
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x));
    }

    public bool Exists(string extension)
    {
        extension = Normalize(extension);

        return LoadExtensions()
            .Contains(extension, StringComparer.OrdinalIgnoreCase);
    }

    public List<string> GetUnknownExtensions(IEnumerable<string> extensions)
    {
        List<string> known = LoadExtensions();

        return extensions
            .Where(e => !known.Contains(e, StringComparer.OrdinalIgnoreCase))
            .ToList();
    }

    public void AddExtension(string extension)
    {
        AddExtensions(new[] { extension });
    }

    public void AddExtensions(IEnumerable<string> extensions)
    {
        List<string> list = LoadExtensions();

        foreach (string extension in extensions)
        {
            string normalized = Normalize(extension);

            if (!list.Contains(normalized, StringComparer.OrdinalIgnoreCase))
                list.Add(normalized);
        }

        list = list
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(x => x)
            .ToList();

        File.WriteAllLines(Constants.ExtensionsFile, list);
    }
}