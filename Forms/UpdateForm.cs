using RetroBatGameListComparator.Models;
using System.Diagnostics;
using RetroBatGameListComparator.Services;

namespace RetroBatGameListComparator.Forms;

public partial class UpdateForm : Form
{
    private readonly GitHubRelease _release;
    private readonly GitHubAsset _asset;
    private readonly UpdateService _updateService = new();

    private CancellationTokenSource? _cts;

    private string? _downloadedFile;

    private bool _downloadInProgress;

    public bool DownloadRequested { get; private set; }

    public string DownloadUrl => _asset.DownloadUrl;

    public string GitHubUrl => _release.HtmlUrl;

    public UpdateForm(
        Version currentVersion,
        GitHubRelease release,
        GitHubAsset asset)
    {
        InitializeComponent();

        // Partie téléchargement masquée au démarrage
        lblStatus.Visible = false;
        progressBarDownload.Visible = false;
        lblProgress.Visible = false;
        btnCancel.Visible = false;

        _release = release;
        _asset = asset;

        lblCurrentVersion.Text =
    $"Version installée : {currentVersion.ToString(3)}";

        lblLatestVersion.Text =
    $"Nouvelle version : {release.TagName.TrimStart('v', 'V')}";

        lblFileName.Text =
            $"Fichier :\n{asset.Name}";

        lblFileSize.Text =
            $"Taille : {asset.Size / 1024d / 1024d:0.00} MB";

        // Association des événements
        btnDownload.Click += btnDownload_Click;
        btnGitHub.Click += btnGitHub_Click;
        btnLater.Click += btnLater_Click;
        btnCancel.Click += btnCancel_Click;
    }

    private async void btnDownload_Click(object sender, EventArgs e)
    {
        if (_downloadInProgress)
            return;

        btnDownload.Visible = false;

        btnGitHub.Enabled = false;
        btnLater.Enabled = false;

        btnCancel.Visible = true;
        btnCancel.Enabled = true;
        btnCancel.Text = "Annuler";

        lblStatus.Visible = true;
        progressBarDownload.Visible = true;
        lblProgress.Visible = true;

        progressBarDownload.Value = 0;
        lblProgress.Text = "0 %";
        lblStatus.Text = "Préparation du téléchargement...";

        _cts = new CancellationTokenSource();

        _downloadInProgress = true;

        Progress<DownloadProgress> progress =
            new(download =>
            {
                progressBarDownload.Value = download.Percent;

                lblProgress.Text =
                    $"{download.Percent} %";

                lblStatus.Text =
                    $"{download.ReceivedMB:0.00} MB / {download.TotalMB:0.00} MB";
            });

        try
        {
            _downloadedFile =
                await _updateService.DownloadPortableReleaseAsync(
                    _asset,
                    progress,
                    _cts.Token);

            _downloadInProgress = false;

            progressBarDownload.Value = 100;

            lblProgress.Text = "100 %";

            lblStatus.Text = "Téléchargement terminé.";

            btnCancel.Text = "Ouvrir le dossier";
            btnCancel.Enabled = true;
        }
        catch (OperationCanceledException)
        {
            _downloadInProgress = false;

            progressBarDownload.Value = 0;

            lblProgress.Text = "0 %";

            lblStatus.Text = "Téléchargement annulé.";

            btnCancel.Text = "Fermer";
            btnCancel.Enabled = true;

            if (!string.IsNullOrWhiteSpace(_downloadedFile) &&
                File.Exists(_downloadedFile))
            {
                File.Delete(_downloadedFile);
            }
        }
        catch (Exception ex)
        {
            _downloadInProgress = false;

            MessageBox.Show(
                ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            lblStatus.Text = "Une erreur est survenue.";

            btnCancel.Text = "Fermer";
            btnCancel.Enabled = true;
        }
    }

    private void btnGitHub_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start(
            new System.Diagnostics.ProcessStartInfo
            {
                FileName = GitHubUrl,
                UseShellExecute = true
            });
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        if (btnCancel.Text == "Annuler")
        {
            _cts?.Cancel();
            return;
        }

        if (btnCancel.Text == "Ouvrir le dossier")
        {
            if (!string.IsNullOrWhiteSpace(_downloadedFile))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = $"/select,\"{_downloadedFile}\"",
                    UseShellExecute = true
                });
            }

            Close();
            return;
        }

        Close();
    }

    private void btnLater_Click(object sender, EventArgs e)
    {
        DownloadRequested = false;
        DialogResult = DialogResult.Cancel;
        Close();
    }

      private void UpdateForm_FormClosing(
    object sender,
    FormClosingEventArgs e)
    {
        if (!_downloadInProgress)
            return;

        DialogResult result =
            MessageBox.Show(
                "Le téléchargement est encore en cours.\n\nVoulez-vous vraiment l'annuler ?",
                "Annuler le téléchargement",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result == DialogResult.No)
        {
            e.Cancel = true;
            return;
        }

        _cts?.Cancel();
    }
}