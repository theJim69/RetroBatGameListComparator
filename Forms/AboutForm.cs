using System.Diagnostics;
using System.Reflection;

namespace RetroBatGameListComparator;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();

        lblVersion.Text =
            $"Version {Assembly.GetExecutingAssembly().GetName().Version?.ToString(3)}";
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
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
                "Impossible d'ouvrir GitHub",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}