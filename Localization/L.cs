namespace RetroBatGameListComparator.Localization;

public static class L
{
    // ==========================================================
    // MENUS
    // ==========================================================

    public static string MenuFile => LocalizationService.Get(nameof(MenuFile));
    public static string MenuExit => LocalizationService.Get(nameof(MenuExit));
    public static string MenuHelp => LocalizationService.Get(nameof(MenuHelp));
    public static string MenuGitHub => LocalizationService.Get(nameof(MenuGitHub));
    public static string MenuAbout => LocalizationService.Get(nameof(MenuAbout));
    public static string MenuCheckUpdates => LocalizationService.Get(nameof(MenuCheckUpdates));

    // ==========================================================
    // LABELS
    // ==========================================================

    public static string LabelRomFolder => LocalizationService.Get(nameof(LabelRomFolder));
    public static string LabelGameList => LocalizationService.Get(nameof(LabelGameList));
    public static string LabelExtensions => LocalizationService.Get(nameof(LabelExtensions));

    // ==========================================================
    // BUTTONS
    // ==========================================================

    public static string ButtonCompare => LocalizationService.Get(nameof(ButtonCompare));
    public static string ButtonExportTxt => LocalizationService.Get(nameof(ButtonExportTxt));
    public static string ButtonExportCsv => LocalizationService.Get(nameof(ButtonExportCsv));

    // ==========================================================
    // CHECKBOX
    // ==========================================================

    public static string CheckRecursive => LocalizationService.Get(nameof(CheckRecursive));

    // ==========================================================
    // LISTVIEW
    // ==========================================================

    public static string ColumnRom => LocalizationService.Get(nameof(ColumnRom));
    public static string ColumnFolder => LocalizationService.Get(nameof(ColumnFolder));

    public static string MissingXmlTitle => LocalizationService.Get(nameof(MissingXmlTitle));
    public static string MissingDiskTitle => LocalizationService.Get(nameof(MissingDiskTitle));

    // ==========================================================
    // STATISTICS
    // ==========================================================

    public static string Statistics => LocalizationService.Get(nameof(Statistics));

    public static string PlatformGames => LocalizationService.Get(nameof(PlatformGames));
    public static string XmlEntries => LocalizationService.Get(nameof(XmlEntries));
    public static string ValidRoms => LocalizationService.Get(nameof(ValidRoms));
    public static string IgnoredMultiDisk => LocalizationService.Get(nameof(IgnoredMultiDisk));
    public static string HiddenGames => LocalizationService.Get(nameof(HiddenGames));
    public static string MissingXml => LocalizationService.Get(nameof(MissingXml));
    public static string MissingDisk => LocalizationService.Get(nameof(MissingDisk));

    // ==========================================================
    // SEARCH
    // ==========================================================

    public static string Search => LocalizationService.Get(nameof(Search));

    // ==========================================================
    // STATUS
    // ==========================================================

    public static string Ready => LocalizationService.Get(nameof(Ready));

    // ==========================================================
    // HINT
    // ==========================================================

    public static string Hint => LocalizationService.Get(nameof(Hint));

    // ==========================================================
    // DIALOG TITLES
    // ==========================================================

    public static string Information => LocalizationService.Get(nameof(Information));
    public static string Warning => LocalizationService.Get(nameof(Warning));
    public static string Error => LocalizationService.Get(nameof(Error));
    public static string Question => LocalizationService.Get(nameof(Question));

    // ==========================================================
    // MESSAGES
    // ==========================================================

    public static string ExportFinished => LocalizationService.Get(nameof(ExportFinished));

    public static string SelectValidRomFolder => LocalizationService.Get(nameof(SelectValidRomFolder));
    public static string SelectValidGameList => LocalizationService.Get(nameof(SelectValidGameList));
    public static string SelectExtension => LocalizationService.Get(nameof(SelectExtension));

    // ==========================================================
    // EXTENSIONS
    // ==========================================================

    public static string NewExtension => LocalizationService.Get(nameof(NewExtension));
    public static string NewExtensionsTitle => LocalizationService.Get(nameof(NewExtensionsTitle));
    public static string NewExtensionsMessage => LocalizationService.Get(nameof(NewExtensionsMessage));
    public static string AddExtensionQuestion => LocalizationService.Get(nameof(AddExtensionQuestion));


    // ==========================================================
    // PLACEHOLDERS
    // ==========================================================

    public static string PlaceholderRomFolder => LocalizationService.Get(nameof(PlaceholderRomFolder));
    public static string PlaceholderGameList => LocalizationService.Get(nameof(PlaceholderGameList));
    public static string PlaceholderSearch => LocalizationService.Get(nameof(PlaceholderSearch));

    public static string DropRomFolder => LocalizationService.Get(nameof(DropRomFolder));
    public static string DropGameList => LocalizationService.Get(nameof(DropGameList));

    // ==========================================================
    // PROGRESS
    // ==========================================================

    public static string ScanningRomFolder => LocalizationService.Get(nameof(ScanningRomFolder));
    public static string ReadingGameList => LocalizationService.Get(nameof(ReadingGameList));
    public static string ComparingFiles => LocalizationService.Get(nameof(ComparingFiles));
    public static string DisplayingResults => LocalizationService.Get(nameof(DisplayingResults));
    public static string ComparisonFinished => LocalizationService.Get(nameof(ComparisonFinished));

    public static string GameListNotFound => LocalizationService.Get(nameof(GameListNotFound));
    public static string ApplicationTitle => LocalizationService.Get(nameof(ApplicationTitle));

    public static string NoMissingXml => LocalizationService.Get(nameof(NoMissingXml));
    public static string NoMissingDisk => LocalizationService.Get(nameof(NoMissingDisk));
    public static string RootFolder => LocalizationService.Get(nameof(RootFolder));

    public static string ExportCsvFinished => LocalizationService.Get(nameof(ExportCsvFinished));
    public static string TextFileFilter => LocalizationService.Get(nameof(TextFileFilter));

    public static string CannotOpenGitHub => LocalizationService.Get(nameof(CannotOpenGitHub));
    public static string CannotOpenFile => LocalizationService.Get(nameof(CannotOpenFile));

    public static string UpdateCheckTitle => LocalizationService.Get(nameof(UpdateCheckTitle));
    public static string InstalledVersion => LocalizationService.Get(nameof(InstalledVersion));
    public static string CannotCheckUpdates => LocalizationService.Get(nameof(CannotCheckUpdates));
    public static string PortableReleaseNotFound => LocalizationService.Get(nameof(PortableReleaseNotFound));
    public static string UpdateTitle => LocalizationService.Get(nameof(UpdateTitle));
    public static string DownloadFinished => LocalizationService.Get(nameof(DownloadFinished));

    public static string StatisticsGroup => LocalizationService.Get(nameof(StatisticsGroup));

    public static string PlatformGamesLabel => LocalizationService.Get(nameof(PlatformGamesLabel));
    public static string XmlEntriesLabel => LocalizationService.Get(nameof(XmlEntriesLabel));
    public static string ValidRomsLabel => LocalizationService.Get(nameof(ValidRomsLabel));
    public static string IgnoredMultiDiskLabel => LocalizationService.Get(nameof(IgnoredMultiDiskLabel));
    public static string HiddenGamesLabel => LocalizationService.Get(nameof(HiddenGamesLabel));
    public static string MissingXmlLabel => LocalizationService.Get(nameof(MissingXmlLabel));
    public static string MissingDiskLabel => LocalizationService.Get(nameof(MissingDiskLabel));

    public static string GameListFilter => LocalizationService.Get(nameof(GameListFilter));
    public static string RomFolderDescription => LocalizationService.Get(nameof(RomFolderDescription));

    public static string TxtFilter => LocalizationService.Get(nameof(TxtFilter));
    public static string CsvFilter => LocalizationService.Get(nameof(CsvFilter));

    public static string SelectRomFolder => LocalizationService.Get(nameof(SelectRomFolder));
    public static string SelectGameList => LocalizationService.Get(nameof(SelectGameList));

    public static string AboutTitle => LocalizationService.Get(nameof(AboutTitle));
    public static string AboutDescription => LocalizationService.Get(nameof(AboutDescription));
    public static string Features => LocalizationService.Get(nameof(Features));
    public static string AboutFeatures => LocalizationService.Get(nameof(AboutFeatures));
    public static string DevelopedBy => LocalizationService.Get(nameof(DevelopedBy));
    public static string AboutFooter => LocalizationService.Get(nameof(AboutFooter));
    public static string Close => LocalizationService.Get(nameof(Close));

    public static string Version => LocalizationService.Get(nameof(Version));

    public static string UpdateAvailableTitle => LocalizationService.Get(nameof(UpdateAvailableTitle));
    public static string NewVersionAvailable => LocalizationService.Get(nameof(NewVersionAvailable));

    public static string LatestVersion => LocalizationService.Get(nameof(LatestVersion));

    public static string File => LocalizationService.Get(nameof(File));
    public static string Size => LocalizationService.Get(nameof(Size));

    public static string Download => LocalizationService.Get(nameof(Download));
    public static string OpenGitHub => LocalizationService.Get(nameof(OpenGitHub));
    public static string Later => LocalizationService.Get(nameof(Later));
    public static string Cancel => LocalizationService.Get(nameof(Cancel));
    public static string OpenFolder => LocalizationService.Get(nameof(OpenFolder));

    public static string PreparingDownload => LocalizationService.Get(nameof(PreparingDownload));
    public static string DownloadCompleted => LocalizationService.Get(nameof(DownloadCompleted));
    public static string DownloadCancelled => LocalizationService.Get(nameof(DownloadCancelled));
    public static string DownloadError => LocalizationService.Get(nameof(DownloadError));

    public static string DownloadRunning => LocalizationService.Get(nameof(DownloadRunning));
    public static string CancelDownloadTitle => LocalizationService.Get(nameof(CancelDownloadTitle));

    public static string CurrentVersionLabel =>
    LocalizationService.Get(nameof(CurrentVersionLabel));

    public static string LatestVersionLabel =>
        LocalizationService.Get(nameof(LatestVersionLabel));

    public static string ExtensionSelectorTitle => LocalizationService.Get(nameof(ExtensionSelectorTitle));

    public static string SearchLabel => LocalizationService.Get(nameof(SearchLabel));

    public static string ExtensionColumn => LocalizationService.Get(nameof(ExtensionColumn));

    public static string SelectAll => LocalizationService.Get(nameof(SelectAll));
    public static string ClearAll => LocalizationService.Get(nameof(ClearAll));

    public static string SelectedExtensions => LocalizationService.Get(nameof(SelectedExtensions));

    public static string ExportTitle => LocalizationService.Get(nameof(ExportTitle));

    public static string ExportDate => LocalizationService.Get(nameof(ExportDate));
    public static string ExportRomFolder => LocalizationService.Get(nameof(ExportRomFolder));
    public static string ExportGameList => LocalizationService.Get(nameof(ExportGameList));
    public static string ExportExtension => LocalizationService.Get(nameof(ExportExtension));

    public static string ComparedRoms => LocalizationService.Get(nameof(ComparedRoms));
    public static string Matches => LocalizationService.Get(nameof(Matches));

    public static string MissingXmlSection => LocalizationService.Get(nameof(MissingXmlSection));
    public static string MissingDiskSection => LocalizationService.Get(nameof(MissingDiskSection));
    public static string AllRomsSection => LocalizationService.Get(nameof(AllRomsSection));

    public static string CsvState => LocalizationService.Get(nameof(CsvState));
    public static string CsvName => LocalizationService.Get(nameof(CsvName));
    public static string CsvExtension => LocalizationService.Get(nameof(CsvExtension));
    public static string CsvFolder => LocalizationService.Get(nameof(CsvFolder));

    public static string CsvOk => LocalizationService.Get(nameof(CsvOk));
    public static string CsvMissingXml => LocalizationService.Get(nameof(CsvMissingXml));
    public static string CsvMissingDisk => LocalizationService.Get(nameof(CsvMissingDisk));

    public static string Total => LocalizationService.Get(nameof(Total));

    public static string Rom => LocalizationService.Get(nameof(Rom));
    public static string Folder => LocalizationService.Get(nameof(Folder));
    public static string Separator => LocalizationService.Get(nameof(Separator));

    public static string DiagnosticTitle => LocalizationService.Get(nameof(DiagnosticTitle));

    public static string ExtensionDistribution => LocalizationService.Get(nameof(ExtensionDistribution));

    public static string DuplicatePaths => LocalizationService.Get(nameof(DuplicatePaths));

    public static string SuspiciousEntries => LocalizationService.Get(nameof(SuspiciousEntries));

    public static string VisibleGames => LocalizationService.Get(nameof(VisibleGames));
    public static string ChdGames => LocalizationService.Get(nameof(ChdGames));
    public static string M3uGames => LocalizationService.Get(nameof(M3uGames));
    public static string CueGames => LocalizationService.Get(nameof(CueGames));
    public static string IsoGames => LocalizationService.Get(nameof(IsoGames));
    public static string OtherExtensions => LocalizationService.Get(nameof(OtherExtensions));
    public static string MultiDiskGames => LocalizationService.Get(nameof(MultiDiskGames));
    public static string MultiDiskFiles => LocalizationService.Get(nameof(MultiDiskFiles));
    public static string DuplicatePathCount => LocalizationService.Get(nameof(DuplicatePathCount));
    public static string GamesWithoutPath => LocalizationService.Get(nameof(GamesWithoutPath));
    public static string GamesWithoutName => LocalizationService.Get(nameof(GamesWithoutName));

    public static string GameWithoutPath => LocalizationService.Get(nameof(GameWithoutPath));
    public static string EmptyPath => LocalizationService.Get(nameof(EmptyPath));
    public static string InvalidMultiDiskJson => LocalizationService.Get(nameof(InvalidMultiDiskJson));

    public static string TotalGames => LocalizationService.Get(nameof(TotalGames));

    public static string CopyName => LocalizationService.Get(nameof(CopyName));

    public static string CopyFullPath => LocalizationService.Get(nameof(CopyFullPath));

    public static string HintDoubleClick => LocalizationService.Get(nameof(HintDoubleClick));

    public static string MenuLanguage => LocalizationService.Get(nameof(MenuLanguage));

    public static string OpenGameList => LocalizationService.Get(nameof(OpenGameList));

    public static string NotGame => LocalizationService.Get(nameof(NotGame));
        public static string NotGameTooltip =>
    LocalizationService.Get(nameof(NotGameTooltip));
}