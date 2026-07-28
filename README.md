# Moon Game - Complete Project Structure

This directory contains all the systems required for your Mars colony simulation game.

## Project Directory Structure

```
moon_game/
├── Assets/
│   ├── Scripts/
│   │   ├── Components/
│   │   │   └── Objects/
│   │   │       └── RegolithObject.cs
│   │   ├── Systems/
│   │   │   ├── Environment/ 
│   │   │   │   ├── TerrainSystem.cs
│   │   │   │   ├── MapSystem.cs
│   │   │   │   ├── NavigationSystem.cs
│   │   │   │   ├── BuildingSystem.cs
│   │   │   │   └── README.md
│   │   │   ├── UI/
│   │   │   │   ├── UISystem.cs
│   │   │   │   └── README.md
│   │   │   ├── Audio/
│   │   │   │   └── AudioManager.cs
│   │   │   ├── Camera/
│   │   │   │   └── CameraController.cs
│   │   │   ├── SettingsSystem.cs
│   │   │   ├── SaveSystem.cs  
│   │   │   └── README.md
│   │   └── Systems/README.md
│   ├── Scenes/
│   ├── Models/
│   ├── Textures/
│   └── Prefabs/
├── Scripts/
│   ├── GameManager.cs
│   ├── Infrastructure_Data.cs
│   ├── ResourceManager.cs
│   ├── Worker.cs
│   ├── WorkerAI_Navigation.cs
│   ├── WorkerAI_TaskManager.cs
│   ├── WorkerAIController.cs
│   └── ConstructionManager.cs
└── README.md
```

## Complete System Catalog

### 1. Core Game Systems
- **GameManager.cs** - Main game state controller
- **ResourceManager.cs** - Resource management system
- **ConstructionManager.cs** - Building construction logic
- **Infrastructure_Data.cs** - Structure definitions and data

### 2. Worker AI Systems  
- **Worker.cs** - Worker unit definition
- **WorkerAI_Navigation.cs** - Worker movement and pathfinding
- **WorkerAI_TaskManager.cs** - Task assignment and execution
- **WorkerAIController.cs** - Central worker AI control

### 3. Environment Systems (Assets/Scripts/Systems/Environment/)
- **TerrainSystem.cs** - Terrain generation and management
- **MapSystem.cs** - Map visualization and tracking  
- **NavigationSystem.cs** - Navigation and movement logic
- **BuildingSystem.cs** - Construction and building mechanics

### 4. User Interface Systems (Assets/Scripts/Systems/UI/)
- **UISystem.cs** - Main UI controller and display management

### 5. Audio Systems (Assets/Scripts/Systems/Audio/)
- **AudioManager.cs** - Sound effects, music, and audio mixing

### 6. Camera Systems (Assets/Scripts/Systems/Camera/)
- **CameraController.cs** - Camera movement and behavior  

### 7. Save/Load System (Assets/Scripts/Systems/)
- **SaveSystem.cs** - Game state persistence system

### 8. Settings System (Assets/Scripts/Systems/)
- **SettingsSystem.cs** - Player settings and preferences

### 9. Resource Objects (Assets/Scripts/Components/Objects/)
- **RegolithObject.cs** - Represent collected resources in the world

## Documentation

Each directory contains a `README.md` file with:
- Purpose and functionality
- Setup instructions for Unity integration
- Usage examples and best practices

## Integration Notes

All systems are designed to work seamlessly together through the GameManager which initializes and coordinates all components. The architecture allows for:
- Modular component design
- Easy extensibility
- Clean separation of concerns
- Full serialization support for save/load functionality