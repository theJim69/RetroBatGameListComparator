using RetroBatGameListComparator.Localization;
using System.Diagnostics;
using System.Reflection;

namespace RetroBatGameListComparator;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();

        ApplyLocalization();

        linkGithub.LinkClicked += LinkGithub_LinkClicked;
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
        string version =
            Assembly.GetExecutingAssembly()
                    .GetName()
                    .Version?
                    .ToString(3) ?? "";

        // Fenêtre
        Text = L.AboutTitle;

        // Nom du programme (ne change pas selon la langue)
        lblTitle.Text = "🎮 RetroBat GameList Comparator";

        // Version
        lblVersion.Text = string.Format(L.Version, version);

        // Description
        lblDescription.Text = L.AboutDescription;

        // Fonctionnalités
        grpFeatures.Text = L.Features;
        lblFeatures.Text = L.AboutFeatures;

        // Auteur
        lblAuthor.Text = L.DevelopedBy;

        // Pied de page
        lblFooter.Text = string.Format(L.AboutFooter, version);

        // Bouton
        btnClose.Text = L.Close;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void LinkGithub_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/theJim69/RetroBatGameListComparator",
                UseShellExecute = true
            });
        }
        catch
        {
            MessageBox.Show(
                L.CannotOpenGitHub,
                L.Error,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void linkGithub_LinkClicked(
        object sender,
        LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/theJim69/RetroBatGameListComparator",
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                L.CannotOpenGitHub,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}