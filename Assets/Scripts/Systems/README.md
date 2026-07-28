# Moon Game - Missing Systems

This directory contains additional systems needed to make the game fully functional.

## Files

- **BuildingSystem.cs** - Manages construction and building structures
- **SaveSystem.cs** - Handles saving and loading game state  
- **AudioManager.cs** - Manages audio effects, music, and sound settings
- **CameraController.cs** - Controls camera movement and behavior

## How to Add to Unity

1. Open your Unity project
2. Navigate to the "Assets" folder
3. Right-click and select "Create > Folder"
4. Name it "Systems"
5. Create a subfolder called "Environment" if it doesn't exist
6. Drag these files into the appropriate folders:
   - BuildingSystem.cs → Systems/Environment/
   - SaveSystem.cs → Systems/
   - AudioManager.cs → Systems/Audio/
   - CameraController.cs → Systems/Camera/

### Setup Instructions

1. **Building System**:
   - Attach `BuildingSystem` component to a GameObject in your scene
   - Populate the building blueprints with construction requirements
   - Configure costs, sizes, and requirements for each structure

2. **Save System**:
   - Attach `SaveSystem` component to a GameObject in your scene
   - Set save file name and auto-save settings
   - The system will automatically save and load game progress

3. **Audio Manager**:
   - Attach `AudioManager` component to a GameObject in your scene  
   - Connect audio source components (music, SFX, ambient)
   - Add audio clips to the appropriate lists

4. **Camera Controller**:
   - Attach `CameraController` component to your main camera
   - Assign a target (worker or colony center) to follow
   - Configure zoom and movement settings