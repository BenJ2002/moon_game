using UnityEngine;
using System.IO;

namespace MoonGame.Systems.Settings
{
    [System.Serializable]
    public class GameSettings
    {
        public bool soundEnabled = true;
        public bool musicEnabled = true;
        public float volume = 0.8f;
        public float musicVolume = 0.7f;
        public int difficulty = 1; // 0: Easy, 1: Normal, 2: Hard
        public bool tutorialMode = true;
        public string language = "English";
        public bool fullscreen = false;
        public int resolutionWidth = 1920;
        public int resolutionHeight = 1080;
        public float sensitivity = 1.0f;
        public bool showNotifications = true;
        
        // Save settings to file
        public void SaveToFile(string filePath)
        {
            string json = JsonUtility.ToJson(this, true);
            File.WriteAllText(filePath, json);
            Debug.Log("Settings saved to: " + filePath);
        }
        
        // Load settings from file
        public static GameSettings LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonUtility.FromJson<GameSettings>(json);
            }
            
            // Return default settings if file doesn't exist
            return new GameSettings();
        }
    }

    public class SettingsSystem : MonoBehaviour
    {
        [Header("Settings")]
        public GameSettings currentSettings;
        
        private string settingsFilePath;
        private bool isInitialized = false;
        
        void Awake()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            if (isInitialized) return;
            
            // Setup file path for saving settings
            settingsFilePath = Path.Combine(Application.persistentDataPath, "game_settings.json");
            
            // Load existing settings or create default ones
            currentSettings = GameSettings.LoadFromFile(settingsFilePath);
            
            isInitialized = true;
            
            Debug.Log("Game Settings System Initialized");
        }
        
        public void SaveSettings()
        {
            if (!isInitialized) Initialize();
            
            currentSettings.SaveToFile(settingsFilePath);
        }
        
        public void LoadSettings()
        {
            if (!isInitialized) Initialize();
            
            currentSettings = GameSettings.LoadFromFile(settingsFilePath);
        }
        
        public void SetSoundEnabled(bool enabled)
        {
            currentSettings.soundEnabled = enabled;
            SaveSettings();
        }
        
        public void SetMusicEnabled(bool enabled)
        {
            currentSettings.musicEnabled = enabled;
            SaveSettings();
        }
        
        public void SetVolume(float volume)
        {
            currentSettings.volume = Mathf.Clamp01(volume);
            SaveSettings();
        }
        
        public void SetDifficulty(int difficulty)
        {
            currentSettings.difficulty = Mathf.Clamp(difficulty, 0, 2);
            SaveSettings();
        }
        
        public void SetLanguage(string language)
        {
            currentSettings.language = language;
            SaveSettings();
        }
    }
}