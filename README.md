# Tanzaku

A Unity-based narrative game project and visual story prototype. This repository contains the main game project under `tanzaku/`, along with supporting character art, concept images, and a packaged Windows showcase build.

## Overview

Tanzaku is a multi-scene interactive story project built in Unity. It includes:

- a main menu flow
- multiple scene transitions
- a pause/settings system
- dialogue assets in English and Japanese
- a packaged Windows demonstration build
- supporting art and character reference materials

The main gameplay flow and menu logic are managed by `tanzaku/Assets/GameHandler.cs`.

## Project Structure

```text
kanaubitoProject/
├── .gitignore
├── README.md
├── tanzaku/
│   ├── Assets/
│   │   ├── GameHandler.cs
│   │   ├── Scenes/
│   │   ├── Dialogue_EN/
│   │   ├── Dialogue_JP/
│   │   ├── Fonts/
│   │   ├── Maps/
│   │   ├── Prefabs/
│   │   ├── TextMesh Pro/
│   │   ├── UI Toolkit/
│   │   ├── images/
│   │   └── ...
│   ├── Packages/
│   ├── ProjectSettings/
│   ├── build_showcase/
│   ├── ver0_2a/
│   └── .gitignore
├── tanzaku_images/
│   ├── 2013_07_12/
│   ├── 2025_02/
│   ├── headshots/
│   ├── *.jpg
│   ├── *.png
│   └── *.pptx
└── ...
```

## Features

- Scene-based progression with menu and ending screens
- Pause/resume controls and settings menu handling
- Audio mixer and volume support
- Unity URP integration
- TextMeshPro support
- Multi-language dialogue assets
- Included build artifacts for quick showcase testing
- Character and concept art assets stored in `tanzaku_images/`

## Requirements

To open and run the project locally, you will need:

- Unity Hub
- Unity 2022.3.26f1
- A Windows machine for running the packaged showcase build

The Unity version is specified in:

```text
tanzaku/ProjectSettings/ProjectVersion.txt
```

## Getting Started

1. Open Unity Hub.
2. Add the project by selecting the `tanzaku/` directory.
3. Make sure Unity `2022.3.26f1` is installed.
4. Open the project and load the `MainMenu` scene.
5. Press Play to run the game.

## Running the Showcase Build

A prebuilt Windows version is included in:

```text
tanzaku/build_showcase/
```

You can launch the desktop build with:

```text
tanzaku/build_showcase/tanzaku.exe
```

## Controls

The project includes quick scene-switch/debug shortcuts in `GameHandler.cs`:

- `Q` — Pause/Resume
- `0` — Main Menu
- `1` — Scene 1
- `2` — Scene 2
- `3` — Scene 3
- `4` — Scene 4
- `5` — Scene 5
- `6` — Scene 6
- `7` — Scene 7
- `8` — Scene 8
- `9` — Scene Win

## Notes

This repository appears to be an active game prototype and art showcase rather than a final production release. It contains a mix of Unity project files, narrative scene assets, localization folders, and reference imagery used during development.

## License

No explicit license file was found in the repository. Unless otherwise stated, assume the project is protected by copyright and should not be redistributed without permission from the rights holder.

## Credits

This project includes story content, game assets, and visual reference materials stored in the repository itself. Attribution details for all individual assets are not fully documented in the project files.