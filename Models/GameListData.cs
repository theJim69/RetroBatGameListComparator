using System;

namespace RetroBatGameListComparator.Models;

public class GameListData
{
    /// <summary>
    /// Jeux principaux déclarés dans le gamelist.xml
    /// (balise &lt;path&gt;).
    /// </summary>
    public List<RomEntry> Games { get; } = new();

    /// <summary>
    /// Fichiers référencés dans les balises &lt;multidisk&gt;.
    /// Ces fichiers ne doivent jamais être considérés
    /// comme des ROMs absentes du XML.
    /// </summary>
    public HashSet<string> MultiDiskFiles { get; } =
        new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Jeux masqués (balise &lt;hidden&gt;).
    /// Ils ne doivent pas être comptés
    /// ni apparaître dans les comparaisons.
    /// </summary>
    public HashSet<string> HiddenFiles { get; } =
        new(StringComparer.OrdinalIgnoreCase);

    //---------------------------------------------------------
    // Statistiques
    //---------------------------------------------------------

    /// <summary>
    /// Nombre de jeux réellement comparés.
    /// </summary>
    public int ComparedCount =>
        Games.Count;

    /// <summary>
    /// Nombre de fichiers ignorés grâce à la balise &lt;multidisk&gt;.
    /// </summary>
    public int MultiDiskIgnoredCount =>
        MultiDiskFiles.Count;

    /// <summary>
    /// Nombre de jeux cachés grâce à la balise &lt;hidden&gt;.
    /// </summary>
    public int HiddenIgnoredCount =>
        HiddenFiles.Count;
}