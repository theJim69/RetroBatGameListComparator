using System.Collections.Generic;

namespace RetroBatGameListComparator.Localization;

public static class English
{
    public static readonly Dictionary<string, string> Strings = new()
    {
        // ==========================================================
        // MENUS
        // ==========================================================

        { "MenuFile", "File" },
        { "MenuExit", "Exit" },
        { "MenuHelp", "Help" },
        { "MenuGitHub", "GitHub Project" },
        { "MenuAbout", "About..." },
        { "MenuCheckUpdates", "Check for Updates" },

        // ==========================================================
        // LABELS
        // ==========================================================

        { "LabelRomFolder", "ROM Folder" },
        { "LabelGameList", "GameList.xml" },
        { "LabelExtensions", "Extensions (e.g. .zip ; .7z ; .chd - separated by ; , | or space)" },

        // ==========================================================
        // BUTTONS
        // ==========================================================

        { "ButtonCompare", "Compare" },
        { "ButtonExportTxt", "Export TXT" },
        { "ButtonExportCsv", "Export CSV" },

        // ==========================================================
        // CHECKBOX
        // ==========================================================

        { "CheckRecursive", "Search subfolders" },

        // ==========================================================
        // LISTVIEW
        // ==========================================================

        { "ColumnRom", "ROM" },
        { "ColumnFolder", "Folder" },

        { "MissingXmlTitle", "Missing from XML" },
        { "MissingDiskTitle", "Missing from Disk" },

        // ==========================================================
        // STATISTICS
        // ==========================================================

        { "Statistics", "Statistics" },

        { "PlatformGames", "⭐ Platform Games: {0}" },
        { "XmlEntries", "XML Entries: {0}" },
        { "ValidRoms", "Valid ROMs: {0}" },
        { "IgnoredMultiDisk", "Ignored MultiDisk: {0}" },
        { "HiddenGames", "Hidden Games: {0}" },
        { "MissingXml", "Missing from XML: {0}" },
        { "MissingDisk", "Missing from Disk: {0}" },

        // ==========================================================
        // SEARCH
        // ==========================================================

        { "Search", "🔍 Search..." },

        // ==========================================================
        // STATUS
        // ==========================================================

        { "Ready", "Ready" },

        // ==========================================================
        // HINT
        // ==========================================================

        { "Hint", "💡 Tip: Double-click a ROM to open its folder or its GameList.xml entry." },

        // ==========================================================
        // DIALOG TITLES
        // ==========================================================

        { "Information", "Information" },
        { "Warning", "Warning" },
        { "Error", "Error" },
        { "Question", "Question" },

        // ==========================================================
        // VALIDATION
        // ==========================================================

        { "SelectValidRomFolder", "Please select a valid ROM folder." },
        { "SelectValidGameList", "Please select a valid GameList.xml file." },
        { "SelectExtension", "Please select an extension." },

        // ==========================================================
        // EXPORT
        // ==========================================================

        { "ExportFinished", "Export completed." },

        // ==========================================================
        // EXTENSIONS
        // ==========================================================

        { "NewExtension", "New Extension" },
        { "NewExtensionsTitle", "New Extensions" },

        { "AddExtensionQuestion", "Add {0} to the list?" },

        {
            "NewExtensionsMessage",
            "The following extensions do not exist:\n\n{0}\n\nWould you like to add them?"
        },

        // ==========================================================
// PLACEHOLDERS
// ==========================================================

{ "PlaceholderRomFolder", "📁 Drop a ROM folder here... or browse for a folder" },
{ "PlaceholderGameList", "📄 Drop a GameList.xml here... or browse for a file" },
{ "PlaceholderSearch", "🔍 Search..." },

{ "DropRomFolder", "📁 Release to drop your folder..." },
{ "DropGameList", "📄 GameList.xml will be detected automatically." },

// ==========================================================
// PROGRESS
// ==========================================================

{ "ScanningRomFolder", "Scanning ROM folder..." },
{ "ReadingGameList", "Reading GameList.xml..." },
{ "ComparingFiles", "Comparing files..." },
{ "DisplayingResults", "Displaying results..." },
{ "ComparisonFinished", "Comparison completed." },

// ===== Missing GameList =====
{ "GameListNotFound", "GameList.xml file not found." },
{ "ApplicationTitle", "RetroBat GameList Comparator" },

// ===== ListView =====
{ "NoMissingXml", "✓ No ROM missing from XML" },
{ "NoMissingDisk", "✓ No ROM missing from Disk" },
{ "RootFolder", "[root]" },

// ===== Export =====
{ "ExportCsvFinished", "CSV export completed." },
{ "TextFileFilter", "Text files (*.txt)|*.txt" },

// ===== GitHub =====
{ "CannotOpenGitHub", "Unable to open GitHub." },
{ "CannotOpenFile", "Unable to open the file.\n\n{0}" },

// ===== Updates =====
{ "UpdateCheckTitle", "Check for Updates" },
{ "InstalledVersion", "Installed version: {0}\n\nLatest version: {1}" },
{ "CannotCheckUpdates", "Unable to check for updates.\n\n{0}" },
{ "PortableReleaseNotFound", "Unable to find the portable file in this release." },
{ "UpdateTitle", "Update" },
{ "DownloadFinished", "Download completed!\n\nThe file has been saved to:\n\n{0}" },

// ==========================================================
// STATISTICS LABELS
// ==========================================================

{ "StatisticsGroup", "Statistics" },

{ "PlatformGamesLabel", "⭐ Platform Games" },
{ "XmlEntriesLabel", "XML Entries" },
{ "ValidRomsLabel", "Valid ROMs" },
{ "IgnoredMultiDiskLabel", "Ignored MultiDisk" },
{ "HiddenGamesLabel", "Hidden Games" },
{ "MissingXmlLabel", "Missing from XML" },
{ "MissingDiskLabel", "Missing from Disk" },

// ===== File Dialogs =====

{ "GameListFilter", "GameList.xml|gamelist.xml|XML files (*.xml)|*.xml|All files (*.*)|*.*" },
{ "RomFolderDescription", "Select the ROM folder" },

{ "TxtFilter", "Text files (*.txt)|*.txt" },
{ "CsvFilter", "CSV files (*.csv)|*.csv" },

{ "SelectRomFolder", "Select ROM Folder" },
{ "SelectGameList", "Select GameList.xml" },

// ==========================================================
// ABOUT
// ==========================================================

{ "AboutTitle", "About" },
{ "AboutDescription",
  "Compares the ROMs stored on disk with the entries in the GameList.xml file,\n" +
  "detects differences and helps maintain RetroBat collections." },

{ "Features", "Features" },

{ "AboutFeatures",
@"✔ Compare ROMs ↔ GameList.xml
✔ Detect ROMs missing from XML
✔ Detect ROMs missing from disk
✔ Support multiple extensions (.zip, .7z, .chd...)
✔ Search subfolders
✔ Recursive scan
✔ Instant extension search
✔ Multiple extension selection
✔ Automatic detection of new extensions
✔ Open a ROM directly in Windows Explorer
✔ Export results to TXT
✔ Export results to CSV" },

{ "DevelopedBy", "Developed by\r\ntheJim" },

{ "AboutFooter",
  "Version : {0}      Framework : .NET 8\r\n© 2026 theJim • Windows Forms • C#" },

{ "Close", "Close" },

{ "Version", "Version {0}" },

// ==========================================================
// UPDATE FORM
// ==========================================================

{ "UpdateAvailableTitle", "Update Available" },
{ "NewVersionAvailable", "🚀 A new version is available!" },

{ "CurrentVersionLabel", "Installed version: {0}" },
{ "LatestVersionLabel", "Latest version: {0}" },

{ "File", "File:\n{0}" },
{ "Size", "Size: {0:0.00} MB" },

{ "Download", "Download" },
{ "OpenGitHub", "Open GitHub" },
{ "Later", "Later" },
{ "Cancel", "Cancel" },

{ "PreparingDownload", "Preparing download..." },
{ "DownloadCompleted", "Download completed." },
{ "DownloadCancelled", "Download cancelled." },
{ "DownloadError", "An error occurred." },

{ "DownloadRunning",
  "The download is still in progress.\n\nDo you really want to cancel it?" },

{ "CancelDownloadTitle", "Cancel Download" },

// ==========================================================
// EXTENSION SELECTOR
// ==========================================================

{ "ExtensionSelectorTitle", "Extension Selection" },
{ "SearchLabel", "Search" },
{ "ExtensionColumn", "Extension" },

{ "SelectAll", "Select All" },
{ "ClearAll", "Clear All" },

{ "SelectedExtensions", "{0} extension(s) selected" },

// ==========================================================
// EXPORT
// ==========================================================

{ "ExportTitle", "RetroBat GameList Comparator" },

{ "ExportDate", "Date: {0}" },
{ "ExportRomFolder", "ROM Folder: {0}" },
{ "ExportGameList", "GameList: {0}" },
{ "ExportExtension", "Extension: {0}" },

{ "ComparedRoms", "Compared ROMs: {0}" },
{ "Matches", "Matches: {0}" },

{ "MissingXmlSection", "ROMs missing from XML" },
{ "MissingDiskSection", "ROMs missing from Disk" },
{ "AllRomsSection", "Complete ROM list" },

{ "CsvState", "State" },
{ "CsvName", "Name" },
{ "CsvExtension", "Extension" },
{ "CsvFolder", "Folder" },

{ "CsvOk", "OK" },
{ "CsvMissingXml", "Missing XML" },
{ "CsvMissingDisk", "Missing Disk" },

{ "Total", "Total: {0}" },

{ "Rom", "ROM: {0}" },
{ "Folder", "Folder: {0}" },
{ "Separator", "-------------------------------------------------------" },

// ==========================================================
// DIAGNOSTIC
// ==========================================================

{ "DiagnosticTitle", "GameList Diagnostic" },
{ "ExtensionDistribution", "Extension Distribution" },
{ "DuplicatePaths", "Duplicate Paths" },
{ "SuspiciousEntries", "Suspicious Entries" },

{ "VisibleGames", "Visible Games: {0}" },
{ "ChdGames", ".chd Games: {0}" },
{ "M3uGames", ".m3u Games: {0}" },
{ "CueGames", ".cue Games: {0}" },
{ "IsoGames", ".iso Games: {0}" },
{ "OtherExtensions", "Other Extensions: {0}" },
{ "MultiDiskGames", "MultiDisk Games: {0}" },
{ "MultiDiskFiles", "MultiDisk Files: {0}" },
{ "DuplicatePathCount", "Duplicate <path>: {0}" },
{ "GamesWithoutPath", "Games without <path>: {0}" },
{ "GamesWithoutName", "Games without <name>: {0}" },

{ "GameWithoutPath", "<game> without <path>" },
{ "EmptyPath", "<path> is empty" },
{ "InvalidMultiDiskJson", "Invalid multidisk JSON: {0}" },

{ "TotalGames", "Total <game>: {0}" },

// ==========================================================
// CONTEXT MENU
// ==========================================================

{ "CopyName", "📋 Copy Name" },
{ "CopyFullPath", "📂 Copy Full Path" },
{ "OpenFolder", "📂 Open Folder" },

{ "HintDoubleClick", "💡 Tip: Double-click a ROM to open its folder or its GameList.xml." },

{ "MenuLanguage", "Language" },

// ==========================================================
// AUTRES 
// ==========================================================

{"OpenGameList", "📋 Open GameList.xml" },

{"NotGame", "ZZZ(NotGame): {0}" },

{ "NotGameTooltip",
@"ScreenScraper sometimes identifies valid ROMs as non-game entries.

When this happens, the game is renamed to ""ZZZ(NotGame):..."" and the <hidden> tag in gamelist.xml is automatically set to true, causing the game to be hidden in RetroBat.

This is a known limitation of the ScreenScraper metadata integration." },

    };
}