using RetroBatGameListComparator.Models;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;

namespace RetroBatGameListComparator.Services;

public class UpdateService
{
    private readonly HttpClient _http = new();

    private const string LatestReleaseUrl =
        "https://api.github.com/repos/theJim69/RetroBatGameListComparator/releases/latest";

    public UpdateService()
    {
        _http.DefaultRequestHeaders.UserAgent.ParseAdd(
            "RetroBatGameListComparator");
    }

    /// <summary>
    /// Retourne la version actuellement installée.
    /// </summary>
    public Version GetCurrentVersion()
    {
        return Assembly
            .GetExecutingAssembly()
            .GetName()
            .Version
            ?? new Version(1, 0, 0);
    }

    /// <summary>
    /// Retourne la version sous forme de texte.
    /// </summary>
    public string GetCurrentVersionString()
    {
        return GetCurrentVersion().ToString(3);
    }

    /// <summary>
    /// Récupère la dernière Release GitHub.
    /// </summary>
    public async Task<GitHubRelease?> GetLatestReleaseAsync()
    {
        string json =
            await _http.GetStringAsync(LatestReleaseUrl);

        return JsonSerializer.Deserialize<GitHubRelease>(json);
    }

    /// <summary>
    /// Recherche automatiquement le ZIP portable.
    /// </summary>
    public GitHubAsset? GetPortableAsset(GitHubRelease release)
    {
        return release.Assets.FirstOrDefault(asset =>
            asset.Name.Contains(
                "Portable",
                StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Retourne le dossier de téléchargement.
    /// </summary>
    public string GetDownloadFolder()
    {
        string programFolder =
            AppContext.BaseDirectory;

        string downloads =
            Path.Combine(
                programFolder,
                "Downloads");

        Directory.CreateDirectory(downloads);

        return downloads;
    }

    /// <summary>
    /// Télécharge un fichier avec progression.
    /// </summary>
    public async Task DownloadFileAsync(
    string url,
    string destinationFile,
    IProgress<DownloadProgress>? progress = null,
    CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response =
            await _http.GetAsync(
                url,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken);

        response.EnsureSuccessStatusCode();

        long totalBytes =
            response.Content.Headers.ContentLength ?? 0;

        await using Stream input =
            await response.Content.ReadAsStreamAsync(cancellationToken);

        await using FileStream output =
            File.Create(destinationFile);

        byte[] buffer = new byte[8192];

        long totalRead = 0;

        int bytesRead;

        while ((bytesRead =
            await input.ReadAsync(
                buffer,
                cancellationToken)) > 0)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await output.WriteAsync(
                buffer.AsMemory(0, bytesRead),
                cancellationToken);

            totalRead += bytesRead;

            progress?.Report(
                new DownloadProgress
                {
                    Percent =
                        totalBytes == 0
                            ? 0
                            : (int)(totalRead * 100 / totalBytes),

                    BytesReceived = totalRead,

                    TotalBytes = totalBytes
                });
        }
    }

    /// <summary>
    /// Télécharge automatiquement le ZIP portable.
    /// </summary>
    public async Task<string> DownloadPortableReleaseAsync(
    GitHubAsset asset,
    IProgress<DownloadProgress>? progress = null,
    CancellationToken cancellationToken = default)
    {
        string destinationFile =
            Path.Combine(
                GetDownloadFolder(),
                asset.Name);

        await DownloadFileAsync(
            asset.DownloadUrl,
            destinationFile,
            progress,
            cancellationToken);

        return destinationFile;
    
}
}