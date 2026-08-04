# Comparison Rules

This document describes how the comparison engine works and explains how RetroBat GameList Comparator determines whether a ROM is valid, missing or ignored.

---

# Overview

The comparison engine compares two sources:

- the ROM folder
- the corresponding `gamelist.xml`

Its goal is to detect inconsistencies while reproducing the game count displayed by RetroBat / EmulationStation as closely as possible.

---

# Comparison Workflow

The comparison process consists of four main steps.

## 1. Scan the ROM folder

The application recursively scans the selected ROM directory (optional).

Only files matching the selected extensions are considered.

Example:

```
*.zip
*.7z
*.cue
*.iso
*.chd
*.m3u
```

---

## 2. Read the GameList

Each `<game>` entry is loaded.

The following information is extracted:

- `<path>`
- `<hidden>`
- `<multidisk>`

Only the `<path>` element represents the main game.

---

## 3. Build the comparison lists

Two collections are created.

### Disk

Contains every ROM found on disk.

### XML

Contains every visible game found in the GameList.

Hidden games are excluded.

---

## 4. Compare

Each ROM is compared using its **relative path**.

Comparison is case-insensitive.

---

# Path Normalization

Before comparison, every path is normalized.

The following transformations are applied:

```
\  →  /
```

Leading characters are removed:

```
./
/
```

Whitespace is trimmed.

Example:

```
./PSX/Game.chd

↓

PSX/Game.chd
```

This avoids false mismatches caused by path formatting.

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

Only the `.m3u` file represents the game.

Child files listed inside `<multidisk>` are ignored.

They:

- are not compared
- are not counted
- never appear as missing

This prevents every CD from being counted as an individual game.

---

# Missing from XML

A ROM is reported as **Missing from XML** when:

- it exists on disk
- it is not Hidden
- it is not a MultiDisk child
- no matching `<path>` exists inside the GameList

---

# Missing from Disk

A game is reported as **Missing from Disk** when:

- it exists in the GameList
- it is not Hidden
- its ROM cannot be found on disk

---

# Platform Game Count

The value displayed as:

```
⭐ Platform Games
```

represents the number of games actually compared.

It excludes:

- Hidden games
- MultiDisk child files

The goal is to produce statistics that closely match the number of games displayed by RetroBat.

---

# ROMs Validated

The value:

```
ROMs Validated
```

represents the number of ROMs successfully matched between the disk and the GameList.

---

# Current Limitations

The comparison engine does not currently validate:

- duplicated `<path>` entries
- duplicated `<game>` entries
- missing images
- missing videos
- invalid metadata
- XML consistency

These features are planned for a future **GameList Inspector**.

---

# Design Goals

The comparison engine is designed to be:

- Fast
- Lightweight
- Deterministic
- Easy to understand
- Easy to maintain

---

# Future Improvements

Future versions may include:

- XML consistency checker
- Duplicate detection
- Missing artwork detection
- Missing video detection
- Automatic XML repair
- Metadata validation
- GameList Inspector

---

# Summary

The comparison engine intentionally ignores Hidden games and MultiDisk child files to avoid false positives and to provide platform statistics that better reflect what RetroBat and EmulationStation actually display.