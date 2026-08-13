using System.Collections.Generic;

namespace RetroBatGameListComparator.Localization;

public static class Spanish
{
    public static readonly Dictionary<string, string> Strings = new()
    {
        // =========================================================
// MENUS
// =========================================================

{ "MenuFile", "Archivo" },
{ "MenuExit", "Salir" },
{ "MenuLanguage", "Idioma" },
{ "MenuHelp", "Ayuda" },
{ "MenuAbout", "A cerca..." },
{ "MenuGitHub", "Projecto GitHub" },
{ "MenuCheckUpdates", "Buscar actualizaciones." },


{ "Open", "Abrir" },
{ "Exit", "Salir" },

{ "CheckUpdates", "Buscar actualizaciones" },
{ "About", "Acerca de" },

{ "Language", "Idioma" },
{ "English", "English" },
{ "French", "Français" },
{ "Spanish", "Español" },

        // ==========================================================
        // LABELS
        // ==========================================================

        { "LabelRomFolder", "Carpeta de ROMs" },
{ "LabelGameList", "GameList.xml" },
{ "LabelExtensions", "Extensiones (ej.: .zip ; .7z ; .chd - separadas por ; , | o espacio)" },

        // ==========================================================
        // BUTTONS
        // ==========================================================

        { "ButtonCompare", "Comparar" },
{ "ButtonExportTxt", "Exportar TXT" },
{ "ButtonExportCsv", "Exportar CSV" },

        // ==========================================================
        // CHECKBOX
        // ==========================================================

        { "CheckRecursive", "Buscar en subcarpetas" },

        // ==========================================================
        // LISTVIEW
        // ==========================================================

       { "ColumnRom", "ROM" },
{ "ColumnFolder", "Carpeta" },

{ "MissingXmlTitle", "Ausentes del XML" },
{ "MissingDiskTitle", "Ausentes del disco" },

        // ==========================================================
        // STATISTICS
        // ==========================================================

      { "Statistics", "Estadísticas" },

{ "PlatformGames", "⭐ Juegos de la plataforma: {0}" },
{ "XmlEntries", "Entradas XML: {0}" },
{ "ValidRoms", "ROMs válidas: {0}" },
{ "IgnoredMultiDisk", "MultiDisk ignorados: {0}" },
{ "HiddenGames", "Juegos ocultos: {0}" },
{ "MissingXml", "Ausentes del XML: {0}" },
{ "MissingDisk", "Ausentes del disco: {0}" },

        // ==========================================================
        // SEARCH
        // ==========================================================

        { "Search", "🔍 Buscar..." },

        // ==========================================================
        // STATUS
        // ==========================================================

       { "Ready", "Listo" },

        // ==========================================================
        // HINT
        // ==========================================================

        { "Hint", "💡 Consejo: haz doble clic en una ROM para abrir su carpeta o su entrada en GameList.xml." },

        // ==========================================================
        // DIALOG TITLES
        // ==========================================================

        { "Information", "Información" },
{ "Warning", "Advertencia" },
{ "Error", "Error" },
{ "Question", "Pregunta" },

        // ==========================================================
        // VALIDATION
        // ==========================================================
{ "SelectValidRomFolder", "Seleccione una carpeta de ROMs válida." },
{ "SelectValidGameList", "Seleccione un archivo GameList.xml válido." },
{ "SelectExtension", "Seleccione una extensión." },

        // ==========================================================
        // EXPORT
        // ==========================================================

       { "ExportFinished", "Exportación completada." },

        // ==========================================================
        // EXTENSIONS
        // ==========================================================

        { "NewExtension", "Nueva extensión" },
{ "NewExtensionsTitle", "Nuevas extensiones" },

{ "AddExtensionQuestion", "¿Agregar {0} a la lista?" },

{
    "NewExtensionsMessage",
    "Las siguientes extensiones no existen:\n\n{0}\n\n¿Desea agregarlas?"
},

        // ==========================================================
// PLACEHOLDERS
// ==========================================================

{ "PlaceholderRomFolder", "📁 Suelte aquí una carpeta de ROMs... o búsquela" },
{ "PlaceholderGameList", "📄 Suelte aquí un GameList.xml... o busque un archivo" },
{ "PlaceholderSearch", "🔍 Buscar..." },

{ "DropRomFolder", "📁 Suelte para colocar la carpeta..." },
{ "DropGameList", "📄 GameList.xml se detectará automáticamente." },

// ==========================================================
// PROGRESS
// ==========================================================

{ "ScanningRomFolder", "Analizando la carpeta de ROMs..." },
{ "ReadingGameList", "Leyendo GameList.xml..." },
{ "ComparingFiles", "Comparando archivos..." },
{ "DisplayingResults", "Mostrando resultados..." },
{ "ComparisonFinished", "Comparación completada." },

// ===== Missing GameList =====
{ "GameListNotFound", "No se encontró el archivo GameList.xml." },
{ "ApplicationTitle", "RetroBat GameList Comparator" },

// ===== ListView =====
{ "NoMissingXml", "✓ No falta ninguna ROM en el XML" },
{ "NoMissingDisk", "✓ No falta ninguna ROM en el disco" },
{ "RootFolder", "[raíz]" },

// ===== Export =====
{ "ExportCsvFinished", "Exportación CSV completada." },
{ "TextFileFilter", "Archivos de texto (*.txt)|*.txt" },

// ===== GitHub =====
{ "CannotOpenGitHub", "No se puede abrir GitHub." },
{ "CannotOpenFile", "No se puede abrir el archivo.\n\n{0}" },

// ===== Updates =====
{ "UpdateCheckTitle", "Buscar actualizaciones" },
{ "InstalledVersion", "Versión instalada: {0}\n\nÚltima versión: {1}" },
{ "CannotCheckUpdates", "No se pudieron buscar actualizaciones.\n\n{0}" },
{ "PortableReleaseNotFound", "No se encontró el archivo portátil en esta versión." },
{ "UpdateTitle", "Actualización" },
{ "DownloadFinished", "¡Descarga completada!\n\nEl archivo se ha guardado en:\n\n{0}" },

// ==========================================================
// STATISTICS LABELS
// ==========================================================

{ "StatisticsGroup", "Estadísticas" },

{ "PlatformGamesLabel", "⭐ Juegos de la plataforma" },
{ "XmlEntriesLabel", "Entradas XML" },
{ "ValidRomsLabel", "ROMs válidas" },
{ "IgnoredMultiDiskLabel", "MultiDisk ignorados" },
{ "HiddenGamesLabel", "Juegos ocultos" },
{ "MissingXmlLabel", "Ausentes del XML" },
{ "MissingDiskLabel", "Ausentes del disco" },

// ===== File Dialogs =====

{ "GameListFilter", "GameList.xml|gamelist.xml|XML files (*.xml)|*.xml|Todas las carpetas (*.*)|*.*" },
{ "RomFolderDescription", "Seleccione la carpeta de ROMs" },

{ "TxtFilter", "Archivos de texto (*.txt)|*.txt" },
{ "CsvFilter", "Archivos CSV (*.csv)|*.csv" },

{ "SelectRomFolder", "Seleccionar carpeta de ROMs" },
{ "SelectGameList", "Seleccionar GameList.xml" },

// ==========================================================
// ABOUT
// ==========================================================

{ "AboutTitle", "Acerca de" },

{ "AboutDescription",
  "Herramienta profesional para validar\n" +
  "y mantener archivos GameList.xml\n\n" +
  "Diseñada especialmente para RetroBat." },

{ "Features", "Características principales" },

{ "AboutFeatures",
@"✔ Comparación ROM ↔ GameList.xml
✔ Detección de ROMs faltantes (Disco y XML)
✔ Compatibilidad automática con ROMs Hidden
✔ Compatibilidad con ROMs MultiDisk
✔ Compatibilidad con carpetas especiales (+homebrew, +prototype...)
✔ Detección de ZZZ(NotGame)
✔ Detección automática de extensiones
✔ Búsqueda de extensiones personalizadas
✔ Análisis recursivo de subcarpetas
✔ Apertura directa de una ROM
✔ Copia de seguridad automática del GameList
✔ Exportación TXT • CSV
✔ Diagnóstico del GameList
✔ Español • English • Français" },

{ "DevelopedBy", "Desarrollado por\r\ntheJim" },

{ "AboutFooter",
  "Desarrollado con .NET 8\r\nPublicado bajo licencia MIT\r\n© 2026 theJim" },

{ "Close", "Cerrar" },

{ "Version", "Versión {0}" },

// ==========================================================
// UPDATE FORM
// ==========================================================

{ "UpdateAvailableTitle", "Actualización disponible" },
{ "NewVersionAvailable", "🚀 ¡Hay una nueva versión disponible!" },

{ "CurrentVersionLabel", "Versión instalada: {0}" },
{ "LatestVersionLabel", "Última versión: {0}" },

{ "File", "Archivo:\n{0}" },
{ "Size", "Tamaño: {0:0.00} MB" },

{ "Download", "Descargar" },
{ "OpenGitHub", "Abrir GitHub" },
{ "Later", "Más tarde" },
{ "Cancel", "Cancelar" },

{ "PreparingDownload", "Preparando la descarga..." },
{ "DownloadCompleted", "Descarga completada." },
{ "DownloadCancelled", "Descarga cancelada." },
{ "DownloadError", "Se produjo un error." },

{ "DownloadRunning",
  "La descarga aún está en curso.\n\n¿Desea cancelarla?" },

{ "CancelDownloadTitle", "Cancelar descarga" },

// ==========================================================
// EXTENSION SELECTOR
// ==========================================================

{ "ExtensionSelectorTitle", "Selección de extensiones" },
{ "SearchLabel", "Buscar" },
{ "ExtensionColumn", "Extensión" },

{ "SelectAll", "Seleccionar todo" },
{ "ClearAll", "Deseleccionar todo" },

{ "SelectedExtensions", "{0} extensión(es) seleccionada(s)" },

{
    "DefaultPlatformExtensionsInfo",
    "Extensiones predeterminadas de la plataforma « {0} »: {1}\nFuente: {2}"
},

// ==========================================================
// EXPORT
// ==========================================================

{ "ExportTitle", "RetroBat GameList Comparator" },

{ "ExportDate", "Fecha: {0}" },
{ "ExportRomFolder", "Carpeta de ROMs: {0}" },
{ "ExportGameList", "GameList: {0}" },
{ "ExportExtension", "Extensión: {0}" },

{ "ComparedRoms", "ROMs comparadas: {0}" },
{ "Matches", "Coincidencias: {0}" },

{ "MissingXmlSection", "ROMs ausentes del XML" },
{ "MissingDiskSection", "ROMs ausentes del disco" },
{ "AllRomsSection", "Lista completa de ROMs" },

{ "CsvState", "Estado" },
{ "CsvName", "Nombre" },
{ "CsvExtension", "Extensión" },
{ "CsvFolder", "Carpeta" },

{ "CsvOk", "Correcto" },
{ "CsvMissingXml", "Ausente del XML" },
{ "CsvMissingDisk", "Ausente del disco" },

{ "Total", "Total: {0}" },

{ "Rom", "ROM: {0}" },
{ "Folder", "Carpeta: {0}" },
{ "Separator", "-------------------------------------------------------" },

// ==========================================================
// DIAGNOSTIC
// ==========================================================

{ "DiagnosticTitle", "Diagnóstico del GameList" },
{ "ExtensionDistribution", "Distribución de extensiones" },
{ "DuplicatePaths", "Rutas duplicadas" },
{ "SuspiciousEntries", "Entradas sospechosas" },

{ "VisibleGames", "Juegos visibles: {0}" },
{ "ChdGames", "Juegos .chd: {0}" },
{ "M3uGames", "Juegos .m3u: {0}" },
{ "CueGames", "Juegos .cue: {0}" },
{ "IsoGames", "Juegos .iso: {0}" },
{ "OtherExtensions", "Otras extensiones: {0}" },
{ "MultiDiskGames", "Juegos MultiDisk: {0}" },
{ "MultiDiskFiles", "Archivos MultiDisk: {0}" },
{ "DuplicatePathCount", "<path> duplicados: {0}" },
{ "GamesWithoutPath", "Juegos sin <path>: {0}" },
{ "GamesWithoutName", "Juegos sin <name>: {0}" },

{ "GameWithoutPath", "<game> sin <path>" },
{ "EmptyPath", "<path> está vacío" },
{ "InvalidMultiDiskJson", "JSON multidisk no válido: {0}" },

{ "TotalGames", "Total de <game>: {0}" },

// ==========================================================
// CONTEXT MENU
// ==========================================================

{ "CopyName", "📋 Copiar nombre" },
{ "CopyFullPath", "📂 Copiar ruta completa" },
{ "OpenFolder", "📂 Abrir carpeta" },

{ "HintDoubleClick", "💡 Consejo: haga doble clic en una ROM para abrir su carpeta o su GameList.xml." },

// ==========================================================
// AUTRES 
// ==========================================================

{"OpenGameList", "📋 Abrir GameList.xml" },

{"NotGame", "ZZZ(NotGame): {0}" },

{ "NotGameTooltip",
@"En ocasiones ScreenScraper identifica ROMs válidas como si no fueran juegos.

Cuando esto ocurre, el nombre pasa a ser ""ZZZ(NotGame):..."" y la etiqueta <hidden> del archivo gamelist.xml se establece automáticamente en true, ocultando el juego en RetroBat.

Se trata de una limitación conocida de la integración de metadatos de ScreenScraper." },

{ "NotGameReportTitle", "Informe ScreenScraper ZZZ(NotGame)" },

{ "NotGameReportDescription",
@"Este informe enumera las ROMs que ScreenScraper identificó incorrectamente como si no fueran juegos.

Estas ROMs fueron renombradas automáticamente como ""ZZZ(NotGame):..."" y marcadas como ocultas
(<hidden>true</hidden>) dentro del archivo GameList.xml.

Se trata de una limitación conocida de la integración de metadatos de ScreenScraper." },

{ "NotGameReportDetectedEntries", "Entradas detectadas" },

{ "NotGameReportGameName", "Nombre del juego" },

{ "NotGameReportRomFile", "Archivo ROM" },

{ "NotGameReportRelativePath", "Ruta relativa" },

{ "NotGameReportEnd", "Fin del informe" },

{ "GeneratedBy", "Generado por" },

{ "NotGamePlatformSummary", "Resumen de la plataforma" },

{
    "NotGameRepairConfirmation",
@"Esta operación corregirá todas las ROMs identificadas como ZZZ(NotGame).

Se realizarán las siguientes modificaciones:

• eliminar el prefijo ""ZZZ(NotGame):""
• reemplazar <hidden>true</hidden> por <hidden>false</hidden>

Antes de cualquier modificación se creará automáticamente una copia de seguridad del archivo GameList.xml.

¿Desea continuar?"
},

{
    "RepairCompleted",
@"La reparación se completó correctamente.

ROMs reparadas: {0}

Copia de seguridad creada:

{1}"
},
{
    "NoNotGameDetected",
    "No se encontró ninguna ROM ZZZ(NotGame)."
},

{
    "DefaultExtensionsWillBeSelected",
    "---> Seleccionar las extensiones"
},

{
    "DefaultColumn",
    "Predeterminado"
},

    };
}