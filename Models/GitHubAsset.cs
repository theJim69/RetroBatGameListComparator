using System.Text.Json.Serialization;

namespace RetroBatGameListComparator.Models;

public class GitHubAsset
{
    /// <summary>
    /// Nom du fichier publié dans la Release.
    /// Exemple : RetroBatGameListComparator_Portable.zip
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// URL de téléchargement direct.
    /// </summary>
    [JsonPropertyName("browser_download_url")]
    public string DownloadUrl { get; set; } = string.Empty;

    /// <summary>
    /// Taille du fichier en octets.
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }
}