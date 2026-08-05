using System.Globalization;
using System.Resources;

namespace RetroBatGameListComparator.Services;

public class LanguageService
{
    private static readonly LanguageService _instance = new();

    public static LanguageService Current => _instance;

    private readonly Dictionary<string, ResourceManager> _resources = new();

    private CultureInfo _culture = CultureInfo.CurrentUICulture;

    private LanguageService()
    {
        Register("Messages");
        Register("MainForm");
    }

    private void Register(string resourceName)
    {
        ResourceManager manager = new(
            $"RetroBatGameListComparator.Localization.{resourceName}",
            typeof(LanguageService).Assembly);

        _resources.Add(resourceName, manager);
    }

    public void SetLanguage(string culture)
    {
        _culture = new CultureInfo(culture);
    }

    public string Get(string resourceFile, string key)
    {
        if (!_resources.TryGetValue(resourceFile, out ResourceManager? manager))
            return $"[[{resourceFile}.{key}]]";

        return manager.GetString(key, _culture)
               ?? $"[[{resourceFile}.{key}]]";
    }
}