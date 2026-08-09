using System.Collections.Generic;

namespace RetroBatGameListComparator.Localization;

public static class French
{
    public static readonly Dictionary<string, string> Strings = new()
    {
        // ==========================================================
        // MENUS
        // ==========================================================

        { "MenuFile", "Fichier" },
        { "MenuExit", "Quitter" },
        { "MenuHelp", "Aide" },
        { "MenuGitHub", "Projet GitHub" },
        { "MenuAbout", "À propos..." },
        { "MenuCheckUpdates", "Vérifier les mises à jour" },

        // ==========================================================
        // LABELS
        // ==========================================================

        { "LabelRomFolder", "Dossier des ROMs" },
        { "LabelGameList", "GameList.xml" },
        { "LabelExtensions", "Extensions (ex. : .zip ; .7z ; .chd - séparées par ; , | ou espace)" },

        // ==========================================================
        // BUTTONS
        // ==========================================================

        { "ButtonCompare", "Comparer" },
        { "ButtonExportTxt", "Exporter TXT" },
        { "ButtonExportCsv", "Exporter CSV" },

        // ==========================================================
        // CHECKBOX
        // ==========================================================

        { "CheckRecursive", "Rechercher dans les sous-dossiers" },

        // ==========================================================
        // LISTVIEW
        // ==========================================================

        { "ColumnRom", "ROM" },
        { "ColumnFolder", "Dossier" },

        { "MissingXmlTitle", "Absentes du XML" },
        { "MissingDiskTitle", "Absentes du disque" },

        // ==========================================================
        // STATISTICS
        // ==========================================================

        { "Statistics", "Statistiques" },

        { "PlatformGames", "⭐ Jeux de la plateforme : {0}" },
        { "XmlEntries", "Entrées XML : {0}" },
        { "ValidRoms", "ROMs validées : {0}" },
        { "IgnoredMultiDisk", "MultiDisk ignorés : {0}" },
        { "HiddenGames", "Jeux cachés : {0}" },
        { "MissingXml", "Absentes du XML : {0}" },
        { "MissingDisk", "Absentes du disque : {0}" },

        // ==========================================================
        // SEARCH
        // ==========================================================

        { "Search", "🔍 Rechercher..." },

        // ==========================================================
        // STATUS
        // ==========================================================

        { "Ready", "Prêt" },

        // ==========================================================
        // HINT
        // ==========================================================

        { "Hint", "💡 Astuce : Double-cliquez sur une ROM pour ouvrir son emplacement ou sa GameList.xml." },

        // ==========================================================
        // DIALOG TITLES
        // ==========================================================

        { "Information", "Information" },
        { "Warning", "Attention" },
        { "Error", "Erreur" },
        { "Question", "Question" },

        // ==========================================================
        // VALIDATION
        // ==========================================================

        { "SelectValidRomFolder", "Sélectionnez un dossier ROMs valide." },
        { "SelectValidGameList", "Sélectionnez un GameList.xml valide." },
        { "SelectExtension", "Sélectionnez une extension." },

        // ==========================================================
        // EXPORT
        // ==========================================================

        { "ExportFinished", "Export terminé." },

        // ==========================================================
        // EXTENSIONS
        // ==========================================================

        { "NewExtension", "Nouvelle extension" },
        { "NewExtensionsTitle", "Nouvelles extensions" },

        { "AddExtensionQuestion", "Ajouter {0} à la liste ?" },

        {
            "NewExtensionsMessage",
            "Les extensions suivantes n'existent pas :\n\n{0}\n\nVoulez-vous les ajouter ?"
        },
        // ==========================================================
// PLACEHOLDERS
// ==========================================================

{ "PlaceholderRomFolder", "📁 Glissez ici un dossier de ROMs... Ou sélectionnez un dossier" },
{ "PlaceholderGameList", "📄 Glissez ici un fichier GameList.xml... ou sélectionnez un fichier" },
{ "PlaceholderSearch", "🔍 Rechercher..." },

{ "DropRomFolder", "📁 Relâchez pour déposer votre dossier..." },
{ "DropGameList", "📄 Le GameList.xml sera détecté automatiquement." },

// ==========================================================
// PROGRESS
// ==========================================================

{ "ScanningRomFolder", "Analyse du dossier ROMs..." },
{ "ReadingGameList", "Lecture du GameList.xml..." },
{ "ComparingFiles", "Comparaison des fichiers..." },
{ "DisplayingResults", "Affichage des résultats..." },
{ "ComparisonFinished", "Comparaison terminée." },
// ===== Missing GameList =====
{ "GameListNotFound", "Le fichier GameList.xml est introuvable." },
{ "ApplicationTitle", "RetroBat GameList Comparator" },

// ===== ListView =====
{ "NoMissingXml", "✓ Aucune ROM absente du XML" },
{ "NoMissingDisk", "✓ Aucune ROM absente du disque" },
{ "RootFolder", "[racine]" },

// ===== Export =====
{ "ExportCsvFinished", "Export CSV terminé." },
{ "TextFileFilter", "Fichier texte (*.txt)|*.txt" },

// ===== GitHub =====
{ "CannotOpenGitHub", "Impossible d'ouvrir GitHub" },
{ "CannotOpenFile", "Impossible d'ouvrir le fichier.\n\n{0}" },

// ===== Updates =====
{ "UpdateCheckTitle", "Vérification des mises à jour" },
{ "InstalledVersion", "Version installée : {0}\n\nDernière version : {1}" },
{ "CannotCheckUpdates", "Impossible de vérifier les mises à jour.\n\n{0}" },
{ "PortableReleaseNotFound", "Impossible de trouver le fichier portable dans cette Release." },
{ "UpdateTitle", "Mise à jour" },
{ "DownloadFinished", "Téléchargement terminé !\n\nLe fichier a été enregistré dans :\n\n{0}" },

// ==========================================================
// STATISTICS LABELS
// ==========================================================

{ "StatisticsGroup", "Statistiques" },

{ "PlatformGamesLabel", "⭐ Jeux de la plateforme" },
{ "XmlEntriesLabel", "Entrées XML" },
{ "ValidRomsLabel", "ROMs validées" },
{ "IgnoredMultiDiskLabel", "MultiDisk ignorés" },
{ "HiddenGamesLabel", "Jeux cachés" },
{ "MissingXmlLabel", "Absentes du XML" },
{ "MissingDiskLabel", "Absentes du disque" },

// ===== File Dialogs =====

{ "GameListFilter", "GameList.xml|gamelist.xml|Fichiers XML (*.xml)|*.xml|Tous les fichiers (*.*)|*.*" },
{ "RomFolderDescription", "Sélectionnez le dossier des ROMs" },

{ "TxtFilter", "Fichier texte (*.txt)|*.txt" },
{ "CsvFilter", "Fichier CSV (*.csv)|*.csv" },

{ "SelectRomFolder", "Sélectionner le dossier des ROMs" },
{ "SelectGameList", "Sélectionner le fichier GameList.xml" },

// ==========================================================
// ABOUT
// ==========================================================

{ "AboutTitle", "À propos" },

{ "AboutDescription",
  "Outil professionnel de validation\n" +
  "et de maintenance des GameList.xml\n\n" +
  "Conçu spécialement pour RetroBat." },

{ "Features", "Fonctionnalités principales" },

{ "AboutFeatures",
@"✔ Comparaison ROM ↔ GameList.xml
✔ Détection des ROMs manquantes (Disque & XML)
✔ Gestion automatique des ROMs Hidden
✔ Gestion des ROMs MultiDisk
✔ Gestion des dossiers spéciaux (+homebrew, +prototype...)
✔ Détection des ZZZ(NotGame)
✔ Détection automatique des extensions
✔ Recherche d'extensions personnalisées
✔ Analyse récursive des sous-dossiers
✔ Ouverture directe d'une ROM
✔ Sauvegarde automatique du GameList
✔ Export TXT • CSV
✔ Diagnostic du GameList
✔ Français • English • Español" },

{ "DevelopedBy", "Développé par\r\ntheJim" },

{ "AboutFooter",
  "Développé avec .NET 8\r\nPublié sous licence MIT\r\n© 2026 theJim" },

{ "Close", "Fermer" },

{ "Version", "Version {0}" },

// ==========================================================
// UPDATE FORM
// ==========================================================

{ "UpdateAvailableTitle", "Mise à jour disponible" },
{ "NewVersionAvailable", "🚀 Une nouvelle version est disponible !" },

{ "CurrentVersionLabel", "Version installée : {0}" },
{ "LatestVersionLabel", "Nouvelle version : {0}" },

{ "File", "Fichier :\n{0}" },
{ "Size", "Taille : {0:0.00} MB" },

{ "Download", "Télécharger" },
{ "OpenGitHub", "Ouvrir GitHub" },
{ "Later", "Plus tard" },
{ "Cancel", "Annuler" },
{ "OpenFolder", "Ouvrir le dossier" },

{ "PreparingDownload", "Préparation du téléchargement..." },
{ "DownloadCompleted", "Téléchargement terminé." },
{ "DownloadCancelled", "Téléchargement annulé." },
{ "DownloadError", "Une erreur est survenue." },

{ "DownloadRunning",
  "Le téléchargement est encore en cours.\n\nVoulez-vous vraiment l'annuler ?" },

{ "CancelDownloadTitle", "Annuler le téléchargement" },

// ==========================================================
// EXTENSION SELECTOR
// ==========================================================

{ "ExtensionSelectorTitle", "Sélection des extensions" },
{ "SearchLabel", "Rechercher" },
{ "ExtensionColumn", "Extension" },

{ "SelectAll", "Tout cocher" },
{ "ClearAll", "Tout décocher" },

{ "SelectedExtensions", "{0} extension(s) sélectionnée(s)" },

// ==========================================================
// EXPORT
// ==========================================================

{ "ExportTitle", "RetroBat GameList Comparator" },

{ "ExportDate", "Date : {0}" },
{ "ExportRomFolder", "Dossier ROMs : {0}" },
{ "ExportGameList", "GameList : {0}" },
{ "ExportExtension", "Extension : {0}" },

{ "ComparedRoms", "ROMs comparées : {0}" },
{ "Matches", "Correspondances : {0}" },

{ "MissingXmlSection", "ROMs absentes du XML" },
{ "MissingDiskSection", "ROMs absentes du disque" },
{ "AllRomsSection", "Liste complète des ROMs" },

{ "CsvState", "État" },
{ "CsvName", "Nom" },
{ "CsvExtension", "Extension" },
{ "CsvFolder", "Dossier" },

{ "CsvOk", "OK" },
{ "CsvMissingXml", "Absente XML" },
{ "CsvMissingDisk", "Absente disque" },

{ "Total", "Total : {0}" },

{ "Rom", "ROM : {0}" },
{ "Folder", "Dossier : {0}" },
{ "Separator", "-------------------------------------------------------" },

// ==========================================================
// DIAGNOSTIC
// ==========================================================

{ "DiagnosticTitle", "Diagnostic GameList" },
{ "ExtensionDistribution", "Répartition des extensions" },
{ "DuplicatePaths", "Doublons" },
{ "SuspiciousEntries", "Entrées suspectes" },

{ "VisibleGames", "Jeux visibles : {0}" },
{ "ChdGames", "Jeux .chd : {0}" },
{ "M3uGames", "Jeux .m3u : {0}" },
{ "CueGames", "Jeux .cue : {0}" },
{ "IsoGames", "Jeux .iso : {0}" },
{ "OtherExtensions", "Autres extensions : {0}" },
{ "MultiDiskGames", "Jeux MultiDisk : {0}" },
{ "MultiDiskFiles", "Fichiers MultiDisk : {0}" },
{ "DuplicatePathCount", "Doublons de <path> : {0}" },
{ "GamesWithoutPath", "Jeux sans <path> : {0}" },
{ "GamesWithoutName", "Jeux sans <name> : {0}" },

{ "GameWithoutPath", "<game> sans <path>" },
{ "EmptyPath", "<path> vide" },
{ "InvalidMultiDiskJson", "JSON multidisk invalide : {0}" },

{ "TotalGames", "Total <game> : {0}" },

// ==========================================================
// CONTEXT MENU
// ==========================================================

{ "CopyName", "📋 Copier le nom" },
{ "CopyFullPath", "📂 Copier le chemin complet" },

{ "HintDoubleClick", "💡 Astuce : Double-cliquez sur une ROM pour ouvrir son emplacement ou sa GameList.xml." },

{ "MenuLanguage", "Langue" },

// ==========================================================
// AUTRES 
// ==========================================================

{"OpenGameList", "📋 Ouvrir GameList.xml" },

{"NotGame", "ZZZ(NotGame): {0}" },

{ "NotGameTooltip",
@"ScreenScraper identifie parfois certaines ROMs valides comme n'étant pas des jeux.

Dans ce cas, le nom est remplacé par ""ZZZ(NotGame):..."" et la balise <hidden> du fichier gamelist.xml est automatiquement définie sur true, ce qui masque le jeu dans RetroBat.

Il s'agit d'une limitation connue de l'intégration des métadonnées de ScreenScraper." },

{ "NotGameReportTitle", "Rapport ScreenScraper ZZZ(NotGame)" },

{ "NotGameReportDescription",
@"Ce rapport liste les ROMs que ScreenScraper a identifiées à tort comme n'étant pas des jeux.

Ces ROMs ont été automatiquement renommées en ""ZZZ(NotGame):..."" et marquées comme cachées
(<hidden>true</hidden>) dans le fichier GameList.xml.

Il s'agit d'une limitation connue de l'intégration des métadonnées de ScreenScraper." },

{ "NotGameReportDetectedEntries", "Entrées détectées" },

{ "NotGameReportGameName", "Nom du jeu" },

{ "NotGameReportRomFile", "Fichier ROM" },

{ "NotGameReportRelativePath", "Chemin relatif" },

{ "NotGameReportEnd", "Fin du rapport" },

{ "GeneratedBy", "Généré par" },

{ "NotGamePlatformSummary", "Résumé de la plateforme" },

{
    "NotGameRepairConfirmation",
@"Cette opération va corriger toutes les ROMs identifiées comme ZZZ(NotGame).

Les modifications suivantes seront appliquées :

• suppression du préfixe ""ZZZ(NotGame):""
• remplacement de <hidden>true</hidden> par <hidden>false</hidden>

Avant toute modification, une sauvegarde du fichier GameList.xml sera créée automatiquement.

Voulez-vous continuer ?"
},

{
    "RepairCompleted",
@"Correction terminée avec succès.

ROMs corrigées : {0}

Sauvegarde créée :

{1}"
},
{
    "NoNotGameDetected",
    "Aucune ROM ZZZ(NotGame) n'a été trouvée."
},

    };
}