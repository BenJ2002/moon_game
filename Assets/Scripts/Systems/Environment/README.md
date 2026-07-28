# Moon Game - Environment Systems

This directory contains the core environment-related systems for the Mars colony game.

## Files

- **TerrainSystem.cs** - Manages the terrain generation and chunk system.
- **MapSystem.cs** - Handles map visualization and marker placement.
- **NavigationSystem.cs** - Controls agent movement and pathfinding.
- **RegolithObject.cs** - Represents resource gathering objects in the environment.

## How to Add to Unity

1. Open your Unity project
2. Navigate to the "Assets" folder
3. Right-click and select "Create > Folder"
4. Name it "Systems"
5. Create a subfolder called "Environment"
6. Drag these files into the "Environment" folder:
   - TerrainSystem.cs
   - MapSystem.cs
   - NavigationSystem.cs
   - RegolithObject.cs

### Setup Instructions

1. **Terrain System**:
   - Attach `TerrainSystem` component to a GameObject in your scene
   - Configure terrain settings in the Inspector
   - Add resource spawn points to the Resource Spawns list

2. **Map System**:
   - Attach `MapSystem` component to a GameObject in your scene
   - Set up map dimensions and colony parameters
   - Place resource and building markers manually or via script

3. **Navigation System**:
   - Attach `NavigationSystem` component to worker or agent GameObjects
   - Configure navigation settings and obstacle layers
   - Call `SetDestination()` method to move agents

4. **Regolith Objects**:
   - Create a 3D object (e.g., sphere) for your resource type
   - Attach `RegolithObject` component to the object
   - Configure resource properties in the Inspector