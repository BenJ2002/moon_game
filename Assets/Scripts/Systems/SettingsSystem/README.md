# Moon Game - Settings System

This directory contains the game settings and configuration system.

## Files

- **SettingsSystem.cs** - Manages game preferences and saves them to disk.

## How to Add to Unity

1. Open your Unity project
2. Navigate to the "Assets" folder
3. Right-click and select "Create > Folder"
4. Name it "Systems"
5. Create a subfolder called "Settings"
6. Drag this file into the "Settings" folder:
   - SettingsSystem.cs

### Setup Instructions

1. **Settings System**:
   - Attach `SettingsSystem` component to a GameObject in your scene (e.g., a GameManager)
   - The system automatically loads settings on startup and saves them when changed
   - Access settings through the `currentSettings` property

2. **Persistent Data Storage**:
   - Settings are saved to: `Application.persistentDataPath + "/game_settings.json"`
   - The system handles loading and saving automatically

3. **Using Settings**:
   ```csharp
   // Get reference to settings system
   SettingsSystem settings = FindObjectOfType<SettingsSystem>();
   
   // Change settings
   settings.SetSoundEnabled(false);
   settings.SetVolume(0.5f);
   settings.SetDifficulty(2);
   
   // Save changes
   settings.SaveSettings();
   
   // Load settings (usually done automatically)
   settings.LoadSettings();
   ```