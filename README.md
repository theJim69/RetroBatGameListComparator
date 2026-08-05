<div align="center">

# 🎮 RetroBat GameList Comparator

> **RetroBat GameList Comparator** is an open-source Windows utility dedicated to validating, analyzing and maintaining RetroBat `gamelist.xml` files.
>
> It is designed to provide **accurate results**, **high performance**, and **professional-grade reporting** for RetroBat users and ROM collectors.

**A fast, lightweight and intelligent utility to compare RetroBat ROM folders with their `gamelist.xml`.**

Detect missing ROMs, obsolete XML entries, and keep your RetroBat collections perfectly synchronized while correctly handling **Hidden** and **MultiDisk** games.

![GitHub release](https://img.shields.io/github/v/release/theJim69/RetroBatGameListComparator?style=for-the-badge)
![GitHub Downloads](https://img.shields.io/github/downloads/theJim69/RetroBatGameListComparator/total?style=for-the-badge)
![License](https://img.shields.io/github/license/theJim69/RetroBatGameListComparator?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge)
![Windows](https://img.shields.io/badge/Windows-10%20%7C%2011-blue?style=for-the-badge)

</div>

## ⭐ Highlights

- ✔ Accurate comparison engine
- ✔ Hidden & MultiDisk aware
- ✔ Drag & Drop support
- ✔ TXT / CSV exports
- ✔ GameList diagnostics
- ✔ English / French / Spanish
- ✔ Automatic update checker

---

# 📖 Overview

RetroBat GameList Comparator is a professional Windows utility for validating and maintaining RetroBat GameList.xml files.

It compares ROM folders with their corresponding GameList.xml, detects inconsistencies, and produces accurate reports while correctly handling Hidden and MultiDisk entries..

Unlike a simple file comparison tool, it understands how **RetroBat** and **EmulationStation** organize ROM collections and automatically ignores entries that should not be reported, producing statistics that closely match the games actually displayed in RetroBat.

---

# ✨ Features

## 🔍 Comparison

- ✅ Compare ROM folders with `gamelist.xml`
- ✅ Detect ROMs missing from the XML
- ✅ Detect XML entries missing from disk
- ✅ Accurate platform game statistics
- ✅ Recursive folder scanning

---

## 🎮 RetroBat / EmulationStation Support

- ✅ Hidden games (`<hidden>`) are automatically ignored
- ✅ MultiDisk child files (`<multidisk>`) are automatically ignored
- ✅ Correct platform game count
- ✅ Relative path comparison

---

## 📁 ROM Extensions

- ✅ Multiple ROM extensions
- ✅ Automatic detection of unknown extensions
- ✅ Extension selection dialog
- ✅ Instant search
- ✅ Select All / Clear All

---

## 🖥 User Interface

- ✅ Drag & Drop support
- ✅ Automatic `gamelist.xml` detection
- ✅ Smart Compare button
- ✅ Progress bar
- ✅ Sortable result lists
- ✅ Double-click to open a ROM folder
- ✅ English / French / Spanish localization
- ✅ Runtime language switching
- ✅ Automatic language persistence

---

## 📄 Reports

- ✅ TXT report
- ✅ CSV report
- ✅ GameList diagnostic report

---

# 📸 Screenshots

## Main Window

<p align="center">
<img src="./Doc/images/main-window.png" width="900">
</p>

---

## About

<p align="center">
<img src="./Doc/images/about.png" width="500">
</p>

---

## Extension Selector

<p align="center">
<img src="./Doc/images/extension-selector.png" width="600">
</p>

---

# 🚀 Installation

## Recommended (Self-contained)

Download the latest **Self-contained x64** release.

No installation and no .NET Runtime are required.

Simply extract the ZIP archive and launch:

```text
RetroBatGameListComparator.exe
```

---

## Portable Version

A smaller portable package is also available.

Requires:

- .NET 8 Desktop Runtime


---

# 🖱️ Usage

1. Select your ROM folder.
2. Select the corresponding `gamelist.xml`.
3. Choose the ROM extensions to compare.
4. Click **Compare**.

The application automatically reports:

- ROMs missing from the XML
- XML entries missing from disk
- Platform statistics

Reports can be exported as:

- TXT
- CSV

---

# 📊 Statistics

The application displays:

- ⭐ Platform Games
- ROMs Compared
- XML Entries
- Missing from XML
- Missing from Disk
- MultiDisk Ignored
- Hidden Games

---

# 🧠 Comparison Engine

The comparison engine has been specifically designed for RetroBat.

It automatically ignores:

- Hidden games (`<hidden>`)
- MultiDisk child files (`<multidisk>`)

This prevents false positives and produces statistics that closely match the games actually displayed by RetroBat.

---

# 🎯 Drag & Drop

Simply drag:

- 📁 A ROM folder → the application automatically fills the ROM folder and detects `gamelist.xml`
- 📄 A `gamelist.xml` file → both fields are automatically completed

---

# 🌍 Localization

RetroBat GameList Comparator now provides full multilingual support with runtime language switching.

Currently supported languages:

- 🇬🇧 English
- 🇫🇷 Français
- 🇪🇸 Español

Features:

- Runtime language switching
- No restart required
- Automatic language persistence
- Automatic refresh of all opened windows

The localization architecture has been designed to easily support additional languages in future releases.

---

# 🛠 Built With

- C#
- .NET 8
- Windows Forms
- XML
- GitHub REST API

---

# 📋 Roadmap

The next major milestone will focus on the evolution of RetroBat GameList Comparator into a complete GameList management solution.

Current priorities include:

- Improved documentation
- Release validation process
- Collection management
- Advanced diagnostics
- XML maintenance tools
- Batch operations

---

# 💡 Long-Term Ideas

Possible future features.

### 🔄 Automatic Synchronization

- ROM folder
- GameList
- Images
- Videos
- Manuals
- Marquees

### 🛠 Repair Wizard

- Missing paths
- Broken artwork
- Invalid MultiDisk entries
- Duplicate games
- Empty metadata

## 📊 Statistics

- Largest ROM collections
- Platform summaries
- Storage usage
- ROM extension statistics

---

## 📑 Reports

- HTML reports
- PDF reports
- JSON export

---

## 🌍 Localization

- ✅ English
- ✅ Français
- ✅ Español
- ✅ Runtime language switching
- ✅ Automatic language persistence

---

## ⚡ Performance

- Multi-threaded scanning
- Faster XML loading
- Improved comparison engine

---

## 🎨 Usability

- Dark mode
- Custom themes
- Additional localizations
- Portable settings
- Automatic update checker

---

# 🤝 Community Suggestions

Feature requests, bug reports and pull requests are always welcome.

If you have an idea that could improve the project, please open an **Issue** on GitHub.

Every suggestion helps make RetroBat GameList Comparator a better tool for the RetroBat community.

---

# 🎯 Current Focus

The immediate objective is to make **RetroBat GameList Comparator** the reference tool for validating and maintaining RetroBat GameLists.

Current priorities are:

- Reliability
- Performance
- Ease of use
- Accurate comparison
- Clear reporting
- Maintainable architecture

Quality and stability always have priority over adding new features.

---

# 📄 License

This project is licensed under the **MIT License**.

See the **LICENSE** file for details.

---

# 👤 Author

Created and maintained by **theJim**

GitHub:
https://github.com/theJim69

---

# ❤️ Special Thanks

- RetroBat Team
- RetroBat Community
- EmulationStation
- ScreenScraper
- All users who report bugs, suggest new ideas and help improve the project.

---

<div align="center">

### ⭐ If you like this project, consider giving it a star on GitHub!

It helps the project gain visibility and motivates future development.

Thank you for your support!

</div>
