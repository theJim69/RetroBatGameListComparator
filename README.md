<div align="center">

# 🎮 RetroBat GameList Comparator

**A fast and lightweight utility to compare RetroBat ROM folders with their `gamelist.xml`.**

Keep your RetroBat collections synchronized by detecting missing ROMs, obsolete XML entries, while correctly handling **Hidden** and **MultiDisk** games.

![GitHub release](https://img.shields.io/github/v/release/theJim69/RetroBatGameListComparator?style=for-the-badge)
![GitHub Downloads](https://img.shields.io/github/downloads/theJim69/RetroBatGameListComparator/total?style=for-the-badge)
![License](https://img.shields.io/github/license/theJim69/RetroBatGameListComparator?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge)
![Windows](https://img.shields.io/badge/Windows-10%20%7C%2011-blue?style=for-the-badge)

</div>

---

# 📖 Overview

RetroBat GameList Comparator is a Windows utility designed to compare a ROM folder with its corresponding `gamelist.xml`.

Unlike a simple file comparison tool, it understands how RetroBat and EmulationStation organize ROM collections and correctly handles features such as:

- Hidden games (`<hidden>`)
- Multi-disc games (`<multidisk>`)
- Recursive ROM folders
- Multiple ROM extensions

The goal is to quickly identify inconsistencies while keeping the reported game count as close as possible to what RetroBat actually displays.

---

# ✨ Features

## Comparison

- ✅ Compare ROM folders with `gamelist.xml`
- ✅ Detect ROMs missing from the XML
- ✅ Detect XML entries missing from disk
- ✅ Accurate platform game statistics
- ✅ Recursive folder scanning

## RetroBat / EmulationStation support

- ✅ Hidden games (`<hidden>`) are automatically ignored
- ✅ MultiDisk child files (`<multidisk>`) are automatically ignored
- ✅ Correct platform game count
- ✅ Relative path comparison

## ROM Extensions

- ✅ Multiple ROM extensions
- ✅ Automatic detection of unknown extensions
- ✅ Extension selection dialog
- ✅ Instant search
- ✅ Select All / Clear All

## User Interface

- ✅ Drag & Drop support
- ✅ Automatic `gamelist.xml` detection
- ✅ Smart Compare button
- ✅ Progress bar
- ✅ Sortable result lists
- ✅ Instant search
- ✅ Double-click to open a ROM folder

## Export

- ✅ TXT report
- ✅ CSV report

---

# 📸 Screenshots

## Main Window

```text
(Screenshot here)
```

## Extension Selector

```text
(Screenshot here)
```

## About

```text
(Screenshot here)
```

---

# 🚀 Installation

## Recommended

Download the latest **Self-contained x64** release.

No installation is required.

Simply extract the ZIP archive and launch:

```text
RetroBatGameListComparator.exe
```

---

## Portable Version

A portable version is also available.

Requires:

- .NET 8 Desktop Runtime

---

# 🖱️ Usage

1. Select your ROM folder.
2. Select the corresponding `gamelist.xml`.
3. Choose the ROM extensions.
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
- ROMs Validated
- XML Entries
- Missing from XML
- Missing from Disk
- MultiDisk Ignored
- Hidden Games

---

# 🧠 Comparison Engine

The comparison engine has been specifically designed for RetroBat.

It automatically ignores:

- Hidden games
- MultiDisk child files

This prevents false positives and produces statistics that closely match the games actually displayed by RetroBat.

---

# 🎯 Drag & Drop

Simply drag:

- 📁 A ROM folder
- 📄 A `gamelist.xml`

The application automatically detects and fills the required information.

---

# 🛠️ Built With

- C#
- .NET 8
- Windows Forms

---

# 📋 Roadmap

### Version 1.5.1

- 🇬🇧 English localization

### Version 1.5.2

- 🇪🇸 Spanish localization

## Version 1.6

- GameList Inspector
- Duplicate `<path>` detection
- Missing images detection
- Missing videos detection
- Invalid MultiDisk detection
- XML consistency checker

## Version 1.7

- XML cleanup
- Metadata validator
- Automatic repairs

## Version 2.0

- GameList editor
- Automatic synchronization
- Batch metadata editing

---

# 🤝 Contributing

Suggestions, feature requests and pull requests are welcome.

If you discover a bug or have an idea for an improvement, please open an Issue.

---

# 📄 License

This project is licensed under the MIT License.

See the **LICENSE** file for details.

---

# 👤 Author

**Jeremy Maes**

GitHub:

https://github.com/theJim69/RetroBatGameListComparator

---

# ❤️ Special Thanks

- RetroBat Team
- EmulationStation
- ScreenScraper
- Everyone who contributes feedback and ideas.