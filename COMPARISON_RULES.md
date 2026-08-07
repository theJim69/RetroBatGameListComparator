# Comparison Rules

This document describes how the comparison engine works and explains how **RetroBat GameList Comparator** determines whether a ROM is valid, missing or intentionally ignored.

The objective of this document is to document the comparison engine so that its behavior remains predictable, maintainable and consistent across future versions.

---

# Overview

The comparison engine compares two sources:

- the ROM folder
- the corresponding `gamelist.xml`

Its objective is to detect inconsistencies while reproducing the behavior of RetroBat / EmulationStation as closely as possible.

Unlike a generic file comparison tool, RetroBat GameList Comparator understands the structure of RetroBat GameLists and intentionally ignores entries that should not affect comparison results.

---

# Comparison Philosophy

RetroBat GameList Comparator does not compare files blindly.

Its primary objective is to reproduce RetroBat / EmulationStation behavior as closely as possible while avoiding false positives.

Whenever a conflict exists between strict XML validation and RetroBat compatibility, compatibility is preferred.

The comparison engine has been designed around five principles:

- Accuracy
- Predictability
- Compatibility with RetroBat
- Performance
- Avoiding false positives

---

# Comparison Workflow

The comparison engine follows the workflow below:

```text
ROM Folder
      │
      ▼
 Scan Files
      │
      ▼
Read GameList.xml
      │
      ▼
Normalize Paths
      │
      ▼
Ignore Hidden Games
      │
      ▼
Ignore MultiDisk Child Files
      │
      ▼
Compare
      │
      ▼
Generate Statistics
      │
      ▼
Generate Reports
```

The comparison process consists of four main steps.

---

# 1. Scan the ROM Folder

The application recursively scans the selected ROM directory (optional).

Only files matching the selected extensions are considered.

Example:

```text
*.zip
*.7z
*.cue
*.iso
*.chd
*.m3u
```

Every detected ROM is stored using its normalized relative path.

---

# 2. Read the GameList

Each `<game>` entry is loaded.

The following information is extracted:

- `<path>`
- `<hidden>`
- `<multidisk>`

Only the `<path>` element represents the playable game.

Additional metadata is ignored during comparison because it has no influence on ROM validation.

---

# 3. Build the Comparison Lists

Two collections are created.

## Disk

Contains every ROM found on disk.

## XML

Contains every visible game found inside the GameList.

Hidden games are excluded.

MultiDisk child files are excluded.

Only playable games remain.

---

# 4. Compare

Each ROM is compared using its normalized relative path.

Comparison is case-insensitive.

This allows Windows paths and GameList paths to match regardless of formatting differences.

---

# Path Normalization

Before comparison, every path is normalized.

The following transformations are applied:

```text
\  →  /
```

Leading characters are removed:

```text
./
/
```

Whitespace is trimmed.

Examples:

```text
Original                    Normalized

./PSX/Game.chd      →        PSX/Game.chd
/PSX/Game.chd       →        PSX/Game.chd
\PSX\Game.chd       →        PSX/Game.chd
```

This avoids false mismatches caused by path formatting differences.

---

# Hidden Games

If a game contains:

```xml
<hidden>true</hidden>
```

or

```xml
<hidden>1</hidden>
```

the game is ignored.

Hidden games:

- are not counted
- are not compared
- never appear as missing

### Why?

Hidden games are intentionally ignored because RetroBat does not display them to the user.

Reporting them as missing would generate false positives and inaccurate platform statistics.

---

# MultiDisk Games

Example:

```xml
<path>./Final Fantasy VII.m3u</path>

<multidisk>
[
"./Final Fantasy VII (Disc 1).chd",
"./Final Fantasy VII (Disc 2).chd",
"./Final Fantasy VII (Disc 3).chd"
]
</multidisk>
```

Only the `.m3u` file represents the playable game.

Child files listed inside `<multidisk>` are ignored.

They:

- are not compared
- are not counted
- never appear as missing

### Why?

Only the parent entry represents a playable game.

Counting every disc individually would inflate platform statistics and generate incorrect comparison results.

---

# Missing from XML

A ROM is reported as **Missing from XML** when:

- it exists on disk
- it is not Hidden
- it is not a MultiDisk child
- no matching `<path>` exists inside the GameList

---

# Missing from Disk

A game is reported as **Missing from Disk** only when:

- it exists in the GameList;
- it is not Hidden;
- it is not a MultiDisk child;
- its ROM cannot be found on disk.

---

## ZZZ(NotGame)

Some ROMs may be intentionally renamed by ScreenScraper using the following format:

<name>ZZZ(notgame):Game Name</name>

When this entry is also marked as:

<hidden>true</hidden>

it is identified as a **ZZZ(NotGame)** entry.

These entries:

- remain counted as Hidden Games;
- are additionally reported in the **ZZZ(NotGame)** statistic;
- are still excluded from Platform Games because they are hidden.

---

# Platform Game Count

The value displayed as:

```text
⭐ Platform Games
```

represents the number of games actually compared by the engine.

It excludes:

- Hidden games
- MultiDisk child files

The objective is to reproduce as closely as possible the number of games displayed by RetroBat / EmulationStation.

This statistic is therefore intentionally different from the total number of `<game>` entries stored inside the GameList.

---

# ROMs Validated

The value:

```text
ROMs Validated
```

represents the number of ROMs successfully matched between:

- the ROM folder
- the GameList

A validated ROM exists both on disk and inside the GameList.

---

# Comparison Results

At the end of the comparison, every entry belongs to one of the following categories:

## ✔ Valid

The ROM exists both on disk and in the GameList.

## ❌ Missing from XML

The ROM exists on disk but has no corresponding GameList entry.

## ❌ Missing from Disk

The GameList references a ROM that cannot be found on disk.

## ⏭ Ignored

Hidden games and MultiDisk child files are intentionally excluded from the comparison and therefore never reported as missing.

These four categories represent every possible comparison result.

---

# Current Scope

The comparison engine intentionally focuses on validating ROM collections.

The following features are currently outside its scope:

- Duplicate `<path>` detection
- Duplicate `<game>` detection
- Missing images
- Missing videos
- Missing manuals
- Broken artwork
- Metadata validation
- XML consistency checking

These features may become part of future collection analysis tools.

---

# Design Goals

The comparison engine has been designed to be:

- Fast
- Lightweight
- Deterministic
- Easy to understand
- Easy to maintain
- Compatible with RetroBat
- Resistant to false positives

Every design decision should preserve these objectives.

---

# Possible Future Enhancements

Future improvements under consideration include:

- XML consistency validation
- Duplicate detection
- Missing artwork detection
- Missing video detection
- Metadata validation
- Automatic XML repair
- Collection health analysis
- Advanced GameList diagnostics

The roadmap intentionally remains flexible to allow future evolution of the project.

---

# Comparison Rules Summary

A ROM is compared only if:

- ✔ Its extension is selected
- ✔ It exists on disk
- ✔ It is not Hidden
- ✔ It is not a MultiDisk child
- ✔ Its normalized relative path matches a GameList entry

Otherwise, it is reported as missing or intentionally ignored according to the rules described in this document.

---

# Summary

RetroBat GameList Comparator does not simply compare filenames.

Its comparison engine has been specifically designed to reproduce the behavior of RetroBat and EmulationStation while providing accurate, predictable and reliable results.

By intentionally ignoring Hidden games and MultiDisk child files, the application avoids false positives and produces platform statistics that closely reflect what users actually see inside RetroBat.

Future enhancements will continue to follow the same philosophy:

- prioritize RetroBat compatibility
- avoid false positives
- remain fast and deterministic
- keep the comparison engine simple, reliable and easy to maintain
