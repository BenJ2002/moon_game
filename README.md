# Moon Game - Mars Colony Simulation

A Unity-based real-time strategy game set on Mars, centered around resource gathering and colony construction.

## Project Structure

```
moon_game/
├── Assets/
│   ├── Scripts/
│   │   ├── Systems/
│   │   │   ├── Environment/
│   │   │   │   ├── TerrainSystem.cs
│   │   │   │   ├── MapSystem.cs
│   │   │   │   ├── NavigationSystem.cs
│   │   │   │   ├── BuildingSystem.cs
│   │   │   │   └── RegolithObject.cs
│   │   │   ├── UI/
│   │   │   │   └── UISystem.cs
│   │   │   ├── Audio/
│   │   │   │   └── AudioManager.cs
│   │   │   ├── Camera/
│   │   │   │   └── CameraController.cs
│   │   │   ├── SettingsSystem.cs
│   │   │   └── SaveSystem.cs
│   │   └── Components/
│   │       └── Objects/
│   │           └── RegolithObject.cs
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

## Core Systems

### 1. Environment Systems
- **TerrainSystem**: Manages terrain generation and resource distribution
- **MapSystem**: Handles map visualization and marker placement
- **NavigationSystem**: Controls agent movement and pathfinding
- **BuildingSystem**: Manages construction and building structures  
- **RegolithObject**: Represents collectible resources in the environment

### 2. User Interface System  
- **UISystem**: Main UI controller for game interface elements

### 3. Audio System
- **AudioManager**: Manages sound effects, music, and audio settings

### 4. Camera System
- **CameraController**: Controls camera movement and behavior

### 5. Settings System
- **SettingsSystem**: Manages game preferences and configuration

### 6. Save System
- **SaveSystem**: Handles saving and loading game state

### 7. Worker AI Systems
- **Worker**: Core worker class with health and carrying capacity
- **WorkerAI_Navigation**: Handles movement to destinations
- **WorkerAI_TaskManager**: Manages task assignment and completion
- **WorkerAIController**: Controls overall AI behavior for workers

### 8. Resource Management
- **ResourceManager**: Handles resource inventory and logic
- **ConstructionManager**: Manages building structures and costs

## How to Setup in Unity

1. **Project Structure**
   - Open the project in Unity
   - Make sure all scripts are imported correctly

2. **Setup GameManager**
   - Create a GameObject in your main scene
   - Attach `GameManager` component to it
   - Configure the game state variables

3. **Setup UI System**
   - Add a Canvas to your scene
   - Use the `UISystem` component to manage all UI elements

4. **Setup Environment Systems**
   - Create an empty GameObject and attach `TerrainSystem`, `MapSystem`, `NavigationSystem`, and `BuildingSystem`
   - Configure settings according to your needs

5. **Worker Setup** 
   - Create worker prefabs with `Worker`, `WorkerAI_Navigation`, `WorkerAI_TaskManager`, and `WorkerAIController` components
   - Place them in the scene and configure their behavior in the Inspector

6. **Camera Setup**
   - Add a Camera to your scene
   - Attach `CameraController` component to it
   - Assign a target object for the camera to follow

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