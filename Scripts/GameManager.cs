using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Narrative & Environment Variables (from "Moon Life" Storyline)
    public float oxygenLevel = 500f; // in Liters
    public float radiationDose = 0f; // in uSv/h
    public float regolithCollected = 0f; // in kg

    // Advancement State
    public bool shieldIntegrity = false;
    public bool miningEnabled = false;
    public bool engineReady = false;
    public bool probePrepared = false;
    public bool missionCompleted = false;

    // Resource Values (Converted for Game Mechanics)
    public float foodCount = 0f;
    public float woodCount = 0f;
    public float goldCount = 0f;
    public float fuelStored = 0f;
    public float powerOutput = 0f; // kW

    // List of log entries for UI/Narrative display
    public List<string> storyLogs = new List<string>();
    
    public ConstructionManager constructionManager;
    public ResourceManager resourceManager;

    void Start()
    {
        InitializeGame();
        SetupManagers();
    }

    void Awake()
    {
        // Log: "Day 1: The lander has touched down. Oxygen tanks deployed; first night silent and cold."
        storyLogs.Add("Day 1: The lander has touched down. Oxygen tanks deployed; first night silent and cold.");
        LogCurrentStory();
    }

    void InitializeGame()
    {
        // Set initial conditions for the "BaseSetup" phase
        Debug.Log("Game Initialized: BaseSetup Mode Active");
    }
    
    void SetupManagers()
    {
        // Get references to managers if they exist in the scene
        constructionManager = FindObjectOfType<ConstructionManager>();
        resourceManager = FindObjectOfType<ResourceManager>();
        
        // If we don't have managers, create new ones or assign defaults
        if (constructionManager == null)
        {
            constructionManager = gameObject.AddComponent<ConstructionManager>();
        }
        
        if (resourceManager == null)
        {
            resourceManager = gameObject.AddComponent<ResourceManager>();
        }
    }

    void Update()
    {
        CheckEnvironmentConditions();
    }

    private void CheckEnvironmentConditions()
    {
        // Handle Oxygen Warning
        if (oxygenLevel < 50f)
        {
            TriggerCutscene("OxygenLow");
        }

        // Handle Radiation Spikes
        if (radiationDose > 2.5f)
        {
            TriggerCutscene("RadiationBurst");
        }

        // State Transitions based on Storyline requirements
        CheckStateTransitions();
    }

    private void CheckStateTransitions()
    {
        if (!shieldIntegrity && !miningEnabled && regolithCollected >= 500)
        {
            shieldIntegrity = true;
            Debug.Log("Requirement Met: Shield Integrity established.");
        }

        // Logic for fuel usage and engine prep based on story logic
        if (shieldIntegrity && fuelStored >= 200)
        {
            engineReady = true;
            Debug.Log("Engine Ready state unlocked.");
        }
    }

    public void TriggerCutscene(string type)
    {
        Debug.Log("Triggering Cutscene: " + type);
        // Unity logic to switch scenes or play cinematic goes here
    }

    private void LogCurrentStory()
    {
        foreach (var log in storyLogs)
        {
            Debug.Log("[STORY LOG]: " + log);
        }
    }
}
