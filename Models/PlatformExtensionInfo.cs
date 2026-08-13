namespace RetroBatGameListComparator.Models;

public class PlatformExtensionInfo
{
    public string Platform { get; init; } = string.Empty;

    public List<string> DefaultExtensions { get; init; } = new();

    public string? SourceFile { get; init; }

    public bool IsCustomConfiguration { get; init; }

    public bool Found => DefaultExtensions.Count > 0;
}