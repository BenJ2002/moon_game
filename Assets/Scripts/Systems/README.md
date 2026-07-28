# Moon Game - Systems Overview

This directory contains all the game systems for the Mars colony simulation.

## Files

- **AudioManager.cs** - Manages sound effects, music, and audio settings
- **CameraController.cs** - Controls camera movement and behavior  
- **BuildingSystem.cs** - Manages construction and building structures
- **SaveSystem.cs** - Handles saving and loading game state
- **SettingsSystem.cs** - Manages game preferences and configuration
- **UISystem.cs** - Main UI controller for interface elements

## How to Add to Unity

1. Open your Unity project
2. Navigate to the "Assets" folder  
3. Right-click and select "Create > Folder"
4. Name it "Systems"
5. Drag these system files to their respective locations:
   - AudioManager.cs → Systems/Audio/
   - CameraController.cs → Systems/Camera/
   - BuildingSystem.cs → Systems/Environment/ 
   - SaveSystem.cs → Systems/
   - SettingsSystem.cs → Systems/
   - UISystem.cs → Systems/UI/

### Setup Instructions

1. **Audio System**:
   - Create an empty GameObject in your main scene called "AudioManager"
   - Attach `AudioManager` component to this GameObject
   - In the Inspector, assign AudioSource components for music, SFX, and ambient sounds
   - Configure audio clips lists (background music, sound effects, etc.)

2. **Camera System**:
   - Create a Camera in your main scene  
   - Name it "MainCamera" or similar
   - Attach `CameraController` component to the camera GameObject
   - In the Inspector, assign the target GameObject for following behavior
   - Configure camera movement settings, zoom limits, and follow distance

3. **Building System**:
   - Create an empty GameObject in your main scene called "ConstructionManager"  
   - Attach `BuildingSystem` component to this GameObject
   - In the Inspector, populate building blueprints with construction requirements
   - Configure costs, sizes, and dependencies for each structure type

4. **Save System**:
   - Create an empty GameObject in your main scene called "SaveManager"
   - Attach `SaveSystem` component to this GameObject  
   - Configure save file name and auto-save settings in Inspector
   - The system will automatically handle saving and loading during game play

5. **Settings System**:
   - Create an empty GameObject in your main scene called "SettingsManager"
   - Attach `SettingsSystem` component to this GameObject
   - In the Inspector, configure user preference options
   - The system automatically loads/saves preferences between sessions

6. **UI System**:
   - Create a Canvas in your main scene (GameObject > UI > Canvas)
   - Create an empty GameObject called "UIManager"  
   - Attach `UISystem` component to this UIManager GameObject
   - In the Inspector, assign all required UI elements for game stats, menus, etc.