# Changelog

All notable changes to this project will be documented in this file.

The format is inspired by **Keep a Changelog** and follows **Semantic Versioning**.

---

## [1.0.0] - 2026-08-02

### 🎉 Initial public release

### Added

- Compare a RetroBat ROM folder with its corresponding `gamelist.xml`
- Detect ROMs missing from the XML
- Detect XML entries missing from disk
- Recursive folder scanning
- Multiple ROM extension support
- Automatic detection of new ROM extensions
- Extension selection dialog with search
- TXT export
- CSV export
- Drag & Drop support
- Automatic detection of `gamelist.xml`
- Smart **Compare** button (enabled only when all required information is valid)
- Progress bar during comparison
- Sortable result lists
- Result counters
- Double-click to open ROM location in Windows Explorer
- Modern About dialog
- GitHub link from the application

### Improved

- Cleaner and more intuitive user interface
- Better workflow for comparing ROM collections
- Faster navigation and easier project maintenance

### Technical

- Built with **C#**
- **.NET 8**
- Windows Forms
- Modular architecture with dedicated services