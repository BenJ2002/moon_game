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
   - Create a Canvas in your main scene (GameObject > UI > Canvas)
   - Name the Canvas "GameUI" or similar 
   - Create an empty GameObject in your scene called "UIManager"
   - Attach `UISystem` component to this UIManager GameObject
   - In the Inspector, assign all required UI elements:
     - Text fields for oxygen, radiation, and regolith amounts
     - Slider bars for progress indicators  
     - Building and worker menu GameObjects with buttons
     - Status text and icons
   - Ensure all referenced UI elements (Text, Sliders, Buttons) are assigned properly in the Inspector

2. **UI Structure Setup**:
   - Create a hierarchy under the Canvas for your UI panels:
     - Main Game Panel (for resource stats)
     - Worker Selection Panel  
     - Building Menu Panel
     - Story Log Panel
     - Pause Menu

3. **Assigning UI Elements**:
   - Each public variable in UISystem.cs represents a specific GUI element
   - These must be assigned to actual GameObjects in your Canvas hierarchy
   - Refer to the component's documentation for exact element types required