using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace MoonGame.Systems
{
    public class SaveSystem : MonoBehaviour
    {
        [Header("Save Settings")]
        public string saveFileName = "moon_game_save";
        public bool autoSave = true;
        public float autoSaveInterval = 300f; // 5 minutes
        
        private GameManager gameManager;
        private ResourceManager resourceManager;
        private ConstructionManager constructionManager;
        private WorkerAI_TaskManager taskManager;
        
        void Start()
        {
            InitializeSaveSystem();
            
            if (autoSave)
            {
                InvokeRepeating("AutoSave", autoSaveInterval, autoSaveInterval);
            }
        }
        
        private void InitializeSaveSystem()
        {
            gameManager = FindObjectOfType<GameManager>();
            resourceManager = FindObjectOfType<ResourceManager>();
            constructionManager = FindObjectOfType<ConstructionManager>();
            taskManager = FindObjectOfType<WorkerAI_TaskManager>();
            
            Debug.Log("Save System initialized");
        }
        
        public void SaveGame()
        {
            if (gameManager == null)
            {
                Debug.LogError("Cannot save - GameManager not found");
                return;
            }
            
            SaveData data = new SaveData();
            
            // Save game state variables
            data.oxygenLevel = gameManager.oxygenLevel;
            data.radiationDose = gameManager.radiationDose;
            data.regolithCollected = gameManager.regolithCollected;
            
            // Save advancement states
            data.shieldIntegrity = gameManager.shieldIntegrity;
            data.miningEnabled = gameManager.miningEnabled;
            data.engineReady = gameManager.engineReady;
            data.probePrepared = gameManager.probePrepared;
            data.missionCompleted = gameManager.missionCompleted;
            
            // Save resources
            data.resources = ResourceManager.GetAllInventory();
            
            // Serialize and save to file
            string json = JsonUtility.ToJson(data, true);
            string filePath = Path.Combine(Application.persistentDataPath, saveFileName + ".json");
            
            File.WriteAllText(filePath, json);
            Debug.Log("Game saved successfully to: " + filePath);
        }
        
        public void LoadGame()
        {
            string filePath = Path.Combine(Application.persistentDataPath, saveFileName + ".json");
            
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                
                // Load game state variables
                if (gameManager != null)
                {
                    gameManager.oxygenLevel = data.oxygenLevel;
                    gameManager.radiationDose = data.radiationDose;
                    gameManager.regolithCollected = data.regolithCollected;
                    
                    gameManager.shieldIntegrity = data.shieldIntegrity;
                    gameManager.miningEnabled = data.miningEnabled;
                    gameManager.engineReady = data.engineReady;
                    gameManager.probePrepared = data.probePrepared;
                    gameManager.missionCompleted = data.missionCompleted;
                }
                
                Debug.Log("Game loaded successfully from: " + filePath);
            }
            else
            {
                Debug.LogWarning("Save file not found, starting new game");
            }
        }
        
        private void AutoSave()
        {
            if (autoSave)
            {
                SaveGame();
            }
        }
        
        public void DeleteSave()
        {
            string filePath = Path.Combine(Application.persistentDataPath, saveFileName + ".json");
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Debug.Log("Save file deleted");
            }
        }
    }
    
    [System.Serializable]
    public class SaveData
    {
        // Game state variables
        public float oxygenLevel;
        public float radiationDose;
        public float regolithCollected;
        
        // Advancement states
        public bool shieldIntegrity;
        public bool miningEnabled;
        public bool engineReady;
        public bool probePrepared;
        public bool missionCompleted;
        
        // Resources
        public Dictionary<ResourceType, float> resources;
    }
}