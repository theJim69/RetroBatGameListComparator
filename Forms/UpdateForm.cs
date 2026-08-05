using RetroBatGameListComparator.Localization;
using RetroBatGameListComparator.Models;
using RetroBatGameListComparator.Services;
using System.Diagnostics;

namespace RetroBatGameListComparator.Forms;

public partial class UpdateForm : Form
{
    private readonly GitHubRelease _release;
    private readonly GitHubAsset _asset;
    private readonly UpdateService _updateService = new();

    private CancellationTokenSource? _cts;

    private string? _downloadedFile;

    private bool _downloadInProgress;

    private enum CancelButtonMode
    {
        Cancel,
        OpenFolder,
        Close
    }

    private CancelButtonMode _cancelMode = CancelButtonMode.Cancel;

    public bool DownloadRequested { get; private set; }

    public string DownloadUrl => _asset.DownloadUrl;

    public string GitHubUrl => _release.HtmlUrl;

    public UpdateForm(
        Version currentVersion,
        GitHubRelease release,
        GitHubAsset asset)
    {
        InitializeComponent();

        ApplyLocalization();

        LocalizationService.LanguageChanged += OnLanguageChanged;

        // Partie téléchargement masquée au démarrage
        lblStatus.Visible = false;
        progressBarDownload.Visible = false;
        lblProgress.Visible = false;
        btnCancel.Visible = false;

        _release = release;
        _asset = asset;

        lblCurrentVersion.Text =
    string.Format(
        L.CurrentVersionLabel,
        currentVersion.ToString(3));

        lblLatestVersion.Text =
    string.Format(
        L.LatestVersionLabel,
        release.TagName.TrimStart('v', 'V'));

        lblFileName.Text =
    string.Format(
        L.File,
        asset.Name);
        
        lblFileSize.Text =
            string.Format(
                L.Size,
                asset.Size / 1024d / 1024d);

        // Association des événements
        btnDownload.Click += btnDownload_Click;
        btnGitHub.Click += btnGitHub_Click;
        btnLater.Click += btnLater_Click;
        btnCancel.Click += btnCancel_Click;
    }

    private void OnLanguageChanged(object? sender, EventArgs e)
    {
        ApplyLocalization();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        LocalizationService.LanguageChanged -= OnLanguageChanged;

        base.OnFormClosed(e);
    }
    private void ApplyLocalization()
    {
        Text = L.UpdateAvailableTitle;

        lblTitle.Text = L.NewVersionAvailable;

        btnDownload.Text = L.Download;
        btnGitHub.Text = L.OpenGitHub;
        btnLater.Text = L.Later;
        btnCancel.Text = L.Cancel;
        _cancelMode = CancelButtonMode.Cancel;
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
        btnCancel.Text = L.Cancel;

        lblStatus.Visible = true;
        progressBarDownload.Visible = true;
        lblProgress.Visible = true;

        progressBarDownload.Value = 0;
        lblProgress.Text = "0 %";
        lblStatus.Text = L.PreparingDownload;

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

            lblStatus.Text = L.DownloadCompleted;

            btnCancel.Text = L.OpenFolder;
            _cancelMode = CancelButtonMode.OpenFolder;
            btnCancel.Enabled = true;
        }
        catch (OperationCanceledException)
        {
            _downloadInProgress = false;

            progressBarDownload.Value = 0;

            lblProgress.Text = "0 %";

            lblStatus.Text = L.DownloadCancelled;

            btnCancel.Text = L.Close;
            _cancelMode = CancelButtonMode.Close;
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

            lblStatus.Text = L.DownloadError;

            btnCancel.Text = L.Close;
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
        switch (_cancelMode)
        {
            case CancelButtonMode.Cancel:
                _cts?.Cancel();
                return;

            case CancelButtonMode.OpenFolder:

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

            case CancelButtonMode.Close:
                Close();
                return;
        }
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
    L.DownloadRunning,
    L.CancelDownloadTitle,
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