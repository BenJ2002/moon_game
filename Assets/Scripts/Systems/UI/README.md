# Moon Game - UI Systems

This directory contains the user interface systems for the Mars colony game.

## Files

- **UISystem.cs** - Main UI controller that manages all game interfaces.

## How to Add to Unity

1. Open your Unity project
2. Navigate to the "Assets" folder
3. Right-click and select "Create > Folder"
4. Name it "Systems"
5. Create a subfolder called "UI"
6. Drag this file into the "UI" folder:
   - UISystem.cs

### Setup Instructions

1. **UISystem**:
   - Add a Canvas to your scene
   - Attach `UISystem` component to a GameObject in your scene
   - Configure UI elements to reference the System's public variables