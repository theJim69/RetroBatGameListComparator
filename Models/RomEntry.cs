namespace RetroBatGameListComparator.Models;

public class RomEntry
{
    /// <summary>
    /// Nom du fichier.
    /// Exemple : Mario.zip
    /// </summary>
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// Chemin relatif.
    /// Exemple : SNES\Mario.zip
    /// </summary>
    public string RelativePath { get; set; } = string.Empty;

    /// <summary>
    /// Chemin complet de la ROM.
    /// Exemple : D:\RetroBat\roms\snes\Mario.zip
    /// </summary>
    public string FullPath { get; set; } = string.Empty;

    /// <summary>
    /// Chemin complet du fichier gamelist.xml.
    /// </summary>
    public string GameListPath { get; set; } = string.Empty;

    /// <summary>
    /// Valeur de la balise <name>.
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Indique si la ROM est présente sur le disque.
    /// </summary>
    public bool ExistsOnDisk { get; set; }

    /// <summary>
    /// Indique si la ROM est présente dans le gamelist.xml.
    /// </summary>
    public bool ExistsInGameList { get; set; }

    public bool IsNotGame { get; set; }
    public bool IsFolder { get; set; }
}