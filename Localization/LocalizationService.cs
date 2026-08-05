using System;
using System.Collections.Generic;

namespace RetroBatGameListComparator.Localization;

public static class LocalizationService
{
    private static Dictionary<string, string> _strings = English.Strings;

    /// <summary>
    /// Déclenché lorsqu'un changement de langue est effectué.
    /// </summary>
    public static event EventHandler? LanguageChanged;

    /// <summary>
    /// Change la langue active.
    /// </summary>
    public static void SetLanguage(Dictionary<string, string> strings)
    {
        ArgumentNullException.ThrowIfNull(strings);

        _strings = strings;

        LanguageChanged?.Invoke(null, EventArgs.Empty);
    }

    /// <summary>
    /// Retourne la traduction d'une clé.
    /// Si la clé n'existe pas, son nom est retourné.
    /// </summary>
    public static string Get(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        return _strings.TryGetValue(key, out string? value)
            ? value
            : key;
    }

    /// <summary>
    /// Langue actuellement utilisée.
    /// </summary>
    public static IReadOnlyDictionary<string, string> CurrentLanguage => _strings;
}