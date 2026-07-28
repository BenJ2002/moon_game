# Moon Game - Mars Colony Simulation

A Unity-based real-time strategy game set on Mars, centered around resource gathering and colony construction.

## Project Structure

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
- **Worker.cs** - Worker unit definition with health and carrying capacity
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

## How to Setup in Unity

1. **Initialize Your Project**
   - Open Unity and load your Mars Colony project
   - Ensure all scripts are copied to their correct location structure

2. **Create Core GameObjects**
   - **GameManager**: 
     - Create an empty GameObject (GameObject > Create Empty)
     - Name it "GameManager"
     - Attach `GameManager` component from Scripts folder  
   
   - **UI Manager**:
     - Create a Canvas (GameObject > UI > Canvas) and name it "GameUI"
     - Create an empty GameObject (GameObject > Create Empty) and name it "UIManager"  
     - Attach `UISystem` component to UIManager

   - **Audio Manager**: 
     - Create a GameObject and name it "AudioManager" 
     - Attach `AudioManager` component from Systems/Audio folder

   - **Camera Setup**:
     - Ensure you have a main camera in the scene
     - Select your camera and attach `CameraController` component 

3. **Environment Systems**
   - Follow the detailed setup instructions in each system's README:
     - Environment systems: TerrainSystem, MapSystem, NavigationSystem, BuildingSystem
     - SettingsSystem: Create "SettingsManager" GameObject
     - SaveSystem: Create "SaveManager" GameObject 
   
4. **Worker Setup** 
   - For each worker/agent you want to place in your scene:
     - Create a GameObject and name it appropriately like "Worker1"  
     - Attach the complete Worker AI component stack in this order:
       1. `Worker` component
       2. `WorkerAI_Navigation` component  
       3. `WorkerAI_TaskManager` component
       4. `WorkerAIController` component
     - Configure individual worker properties in the Inspector

5. **Resource Objects** 
   - Add 3D resource nodes to your scene:
     - Create a 3D GameObject (sphere, cube, etc.) for each resource type
     - Name it "ResourceNode" or similar  
     - Attach `RegolithObject` component from Components/Objects folder
     - Configure resource amounts and collection properties in Inspector

## Game Features

- Mars colony simulation with resource gathering mechanics
- Multi-era progression with unit and building unlocks
- AI opposition and complex worker behavior  
- Advanced UI systems for colony management
- Narrative-driven gameplay connected to variables 
- Real-time strategy elements
- Full save/load system with persistent game state  
- Audio system for immersive sound effects and music

## Development Roadmap

1. **Core Mechanics**: Resource gathering, worker AI, construction (DONE)
2. **UI/UX**: Complete interface design with status panels (DONE)  
3. **Narrative**: Develop story progression elements tied to game state (IN PROGRESS)
4. **Visuals**: Enhance art style and visual effects
5. **Multiplayer**: Add multiplayer cooperative and competitive modes
6. **Advanced AI**: More sophisticated worker behaviors and decision making  
7. **Expanded Building System**: Research, upgrades, production chains

## Contributing

To contribute:
1. Fork the repository
2. Create a feature branch  
3. Commit your changes 
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.