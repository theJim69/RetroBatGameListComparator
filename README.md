# 🎮 RetroBat GameList Comparator

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![Platform](https://img.shields.io/badge/Platform-Windows-blue)
![License](https://img.shields.io/badge/License-MIT-green)
![Release](https://img.shields.io/badge/Version-1.0.0-orange)

A lightweight Windows utility to compare a RetroBat ROM folder with its corresponding `gamelist.xml`.

It quickly detects inconsistencies between your ROM collection and the GameList, making it easy to keep your RetroBat systems clean and organized.

---

## ✨ Features

- ✔ Compare ROM folders with `gamelist.xml`
- ✔ Detect ROMs missing from the XML
- ✔ Detect XML entries missing from disk
- ✔ Support multiple ROM extensions
- ✔ Recursive folder scanning
- ✔ Automatic detection of new ROM extensions
- ✔ TXT export
- ✔ CSV export
- ✔ Drag & Drop support
- ✔ Automatic `gamelist.xml` detection
- ✔ Smart Compare button
- ✔ Progress bar during analysis
- ✔ Sortable result lists
- ✔ Double-click to open a ROM location
- ✔ Modern Windows interface

---

## 📸 Screenshots

### Main Window

The application's main interface

![Main Window](./docs/images/mainwindow.png)


### About Dialog

![About](./docs/images/about.png)

---

## 🚀 Getting Started

### Requirements

- Windows 10 / Windows 11
- .NET 8 Runtime

### Installation

Download the latest release from the **Releases** page.

No installation is required.

Simply extract the ZIP archive and run:

```
RetroBatGameListComparator.exe
```

---

## 🖱️ Usage

1. Select your RetroBat ROM folder.
2. Select the corresponding `gamelist.xml`.
3. Choose the ROM extensions.
4. Click **Compare**.

The application displays:

- ROMs missing from the XML
- XML entries missing from disk

You can export the results to TXT or CSV.

---

## 🎯 Drag & Drop

Simply drag:

- a ROM folder → the application automatically fills the ROM folder and detects `gamelist.xml`
- a `gamelist.xml` file → the GameList field is filled automatically

---

## 📦 Export

Supported formats:

- TXT
- CSV

---

## 🛠️ Built With

- C#
- .NET 8
- Windows Forms

---

## 📋 Roadmap

### Version 1.1

- Status bar
- Context menu
- Last folder history
- Improved progress reporting

### Version 2.0

- Automatic GameList synchronization
- XML editing
- Automatic metadata updates

---

## 🤝 Contributing

Suggestions and pull requests are welcome.

If you find a bug or have an idea for a new feature, feel free to open an issue.

---

## 📄 License

This project is licensed under the MIT License.

See the [LICENSE](LICENSE) file for details.

---

## 👤 Author

Jeremy Maes

GitHub:

https://github.com/theJim69/RetroBatGameListComparator
