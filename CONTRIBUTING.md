# Contributing

First of all, thank you for your interest in **RetroBat GameList Comparator**!

Whether you want to report a bug, suggest a feature or contribute code, your help is greatly appreciated.

---

# Reporting Bugs

If you find a bug, please open a GitHub Issue and include as much information as possible:

- RetroBat version
- Windows version
- Platform (PSX, Dreamcast, etc.)
- ROM extensions used
- Description of the problem
- Steps to reproduce it
- Screenshots if applicable

Whenever possible, include a sample `gamelist.xml` that reproduces the issue.

---

# Feature Requests

Suggestions are always welcome.

Before opening a Feature Request:

- Check if a similar request already exists.
- Clearly explain the problem you're trying to solve.
- Describe the expected behavior.

---

# Pull Requests

Pull Requests are welcome.

Please try to keep them:

- Small
- Focused
- Easy to review

Each Pull Request should address a single feature or bug whenever possible.

---

# Coding Guidelines

The project follows a few simple principles:

- Readability first
- Keep methods short
- Prefer descriptive names
- Avoid duplicated code
- Keep the UI responsive
- Separate UI from business logic

The project is organized using dedicated service classes whenever possible.

---

# Comparison Engine

The comparison engine is the core of the application.

Changes affecting comparison behavior should preserve support for:

- Hidden games
- MultiDisk games
- Relative path comparison

Please read **COMPARISON_RULES.md** before modifying the comparison engine.

---

# Development Environment

Current development environment:

- Visual Studio 2022
- .NET 8
- Windows Forms
- C#

---

# Testing

Before submitting changes, verify that:

- The project builds without warnings.
- TXT export works.
- CSV export works.
- Hidden games are ignored.
- MultiDisk games are ignored.
- Platform statistics remain correct.

---

# Questions

If you're unsure about a design decision, feel free to open a Discussion or an Issue before starting implementation.

---

# Thank You

Every contribution, suggestion or bug report helps improve the project.

Thank you for supporting RetroBat GameList Comparator!

---

This project was created to help RetroBat users maintain clean and reliable GameLists.

If it saves you time, then it has achieved its goal.