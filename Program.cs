using RetroBatGameListComparator.Localization;

namespace RetroBatGameListComparator;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        switch (Properties.Settings.Default.Language)
        {
            case "French":
                LocalizationService.SetLanguage(French.Strings);
                break;

            case "Spanish":
                LocalizationService.SetLanguage(Spanish.Strings);
                break;

            default:
                LocalizationService.SetLanguage(English.Strings);
                break;
        }

        Application.Run(new MainForm());
    }
}