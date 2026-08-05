using RetroBatGameListComparator.Localization;

namespace RetroBatGameListComparator;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Anglais par défaut
        if (Properties.Settings.Default.Language == "French")
        {
            LocalizationService.SetLanguage(French.Strings);
        }
        else
        {
            LocalizationService.SetLanguage(English.Strings);
        }

        Application.Run(new MainForm());
    }
}