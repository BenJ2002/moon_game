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

1. **UI System**:
   - Attach `UISystem` component to a GameObject in your scene (usually a UI manager)
   - Reference all UI elements in the Inspector:
     - Text fields for oxygen, radiation, and regolith amounts
     - Slider bars for progress indicators
     - Building and worker menu GameObjects with buttons
     - Status text and icons

2. **UI Elements**:
   - Create a Canvas in your scene
   - Add UI elements like Text, Sliders, Buttons according to the UI structure
   - Assign references to the UISystem component in the Inspector