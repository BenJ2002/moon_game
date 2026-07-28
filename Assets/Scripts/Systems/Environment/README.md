# Moon Game - Environment Systems

This directory contains the core environment-related systems for the Mars colony game.

## Files

- **TerrainSystem.cs** - Manages the terrain generation and chunk system.
- **MapSystem.cs** - Handles map visualization and marker placement.
- **NavigationSystem.cs** - Controls agent movement and pathfinding.
- **BuildingSystem.cs** - Manages construction and building structures.
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
   - BuildingSystem.cs
   - RegolithObject.cs

### Setup Instructions

1. **Terrain System**:
   - Create an empty GameObject in your main scene called "TerrainManager"
   - Attach `TerrainSystem` component to this GameObject
   - In the Inspector, configure all terrain settings as needed
   - Set up resource spawn points in the Resource Spawns list
   - TerrainSystem does not require any additional GameObjects to be placed

2. **Map System**:
   - Create an empty GameObject in your main scene called "MapManager"
   - Attach `MapSystem` component to this GameObject  
   - In the Inspector, configure map dimensions and colony parameters
   - Set references to any UI markers or visual elements as needed
   - Place resource and building markers manually in the scene or via script

3. **Navigation System**:
   - For each worker or agent GameObject that needs navigation:
     - Create a Worker/Agent GameObject (e.g., "Worker1") 
     - Attach `NavigationSystem` component to this GameObject
     - Configure navigation settings like obstacle layers, movement speed
     - Assign the destination Transform in Inspector when needed
     - The NavigationSystem works with existing Worker AI components

4. **Building System**:
   - Create an empty GameObject in your main scene called "ConstructionManager"
   - Attach `BuildingSystem` component to this GameObject
   - In the Inspector, configure building blueprints and construction requirements
   - Populate the cost requirements for each structure type
   - The system will automatically manage resource consumption during building

5. **Regolith Objects**:
   - Create a 3D object (e.g., sphere) in your scene for resources
   - Name this GameObject "ResourceNode" or similar
   - Attach `RegolithObject` component to the resource GameObject  
   - Configure the resource type, amount available, and collection properties in Inspector