# Changelog

All notable changes to this project will be documented in this file.

This project follows **Semantic Versioning** and is inspired by the **Keep a Changelog** format.
Releases are listed from newest to oldest.

---

# [Unreleased]

## Planned

Future development currently focuses on:

- Documentation improvements
- Release validation process
- GameList management
- Advanced diagnostics
- XML maintenance tools
- Batch operations

---

# [1.5.2] - 2026-08-05

### Added

- Complete Spanish localization
- Spanish language selection
- Runtime Spanish language switching

### Improved

- Localized About dialog
- Localized Update dialog
- Localized Extension Selector
- Localized Diagnostic report
- Localized TXT export
- Localized CSV export
- Improved multilingual support
- Improved localization consistency

### Technical

- Added Spanish localization resources
- Extended localization architecture
- Improved language management

---

# [1.5.1] - 2026-08-05

### Added

- Complete English localization
- Dynamic language switching
- Automatic language detection
- Persistent user language selection
- Language menu
- Live localization of all windows

### Improved

- About dialog
- Update dialog
- Extension selector
- Diagnostic reports
- TXT export
- CSV export
- Context menus
- Internal localization architecture

### Technical

- New LocalizationService
- Strongly typed localization (L.cs)
- LanguageChanged event
- Runtime UI refresh


# [1.5.0] - 2026-08-04

## 🎉 Major Update

This release significantly improves the comparison engine to better match the behavior of RetroBat and EmulationStation.

The application now correctly handles hidden games and multidisc collections while providing more accurate platform statistics.

---

## ✨ Added

### Comparison Engine

- Added support for Hidden games (`<hidden>`)
- Added support for MultiDisk entries (`<multidisk>`)
- Added accurate platform game counting
- Added ignored MultiDisk statistics
- Added ignored Hidden games statistics

### User Interface

- New platform statistics display
- Advanced extension selector
- Extension search
- Extension counter
- ESC shortcut clears the search field
- Automatic focus on the search box
- Improved statistics layout

### Reports

- Improved TXT export
- Improved CSV export
- Better platform statistics inside exported reports

---

## 🚀 Improved

### Comparison

- More accurate ROM comparison
- Better path normalization
- Improved recursive scanning
- Better MultiDisk handling
- Better Hidden game handling

### User Experience

- Cleaner statistics
- Better extension management
- Improved navigation
- Faster comparison
- Better overall responsiveness

---

## 🛠 Fixed

- Fixed incorrect platform game count
- Fixed MultiDisk child file comparison
- Fixed Hidden games being counted
- Fixed several comparison edge cases
- Fixed statistics consistency
- Improved export formatting

---

# [1.0.0] - 2026-08-02

## 🎉 Initial Public Release

### Added

- Compare RetroBat ROM folders with their corresponding `gamelist.xml`
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
- Smart Compare button
- Progress bar
- Sortable result lists
- Result counters
- Double-click to open ROM folders
- About dialog
- GitHub link

### Technical

- Built with C#
- .NET 8
- Windows Forms
- Modular service-based architecture