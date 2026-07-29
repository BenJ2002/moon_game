using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace MoonGame.Systems.UI
{
    public class UISystem : MonoBehaviour
    {
        [Header("UI Elements")]
        public Text oxygenText;
        public Text radiationText;
        public Text regolithText;
        
        [Header("Resource Bars")]
        public Slider oxygenBar;
        public Slider radiationBar;
        public Slider regolithBar;
        
        [Header("Building Menu")]
        public GameObject buildingMenu;
        public Button[] buildingButtons;
        
        [Header("Worker Menu")]
        public GameObject workerMenu;
        public Button[] workerButtons;
        
        [Header("Game Status")]
        public Text gameStatusText;
        public Image statusIcon;
        
        [Header("Resource Display")]
        public Text resourceDisplayText;
        public List<Text> resourceValueTexts = new List<Text>();
        public List<Image> resourceIconImages = new List<Image>();
        
        private GameManager gameManager;
        private ResourceManager resourceManager;
        
        void Start()
        {
            InitializeUI();
            SetupEventListeners();
        }
        
        private void InitializeUI()
        {
            gameManager = FindObjectOfType<GameManager>();
            resourceManager = FindObjectOfType<ResourceManager>();
            
            if (gameManager == null)
                Debug.LogError("GameManager not found!");
                
            if (resourceManager == null)
                Debug.LogError("ResourceManager not found!");
                
            UpdateResourceDisplay();
            UpdateGameStatus();
        }
        
        private void SetupEventListeners()
        {
            // Setup event listeners for UI interactions
            if (buildingMenu != null)
            {
                foreach (Button button in buildingButtons)
                {
                    if (button != null)
                    {
                        button.onClick.AddListener(() => OnBuildingButtonClicked());
                    }
                }
            }
            
            if (workerMenu != null)
            {
                foreach (Button button in workerButtons)
                {
                    if (button != null)
                    {
                        button.onClick.AddListener(() => OnWorkerButtonClicked());
                    }
                }
            }
        }
        
        public void UpdateResourceDisplay()
        {
            if (resourceManager == null) return;
            
            if (oxygenText != null)
                oxygenText.text = "Oxygen: " + gameManager.oxygenLevel.ToString("F0") + "L";
                
            if (radiationText != null)
                radiationText.text = "Radiation: " + gameManager.radiationDose.ToString("F1") + "uSv/h";
                
            if (regolithText != null)
                regolithText.text = "Regolith: " + ResourceManager.GetAmount(ResourceType.Regolith).ToString("F0") + "kg";
                
            // Update progress bars
            if (oxygenBar != null)
                oxygenBar.value = gameManager.oxygenLevel / 500f;
                
            if (radiationBar != null)
                radiationBar.value = gameManager.radiationDose / 2.5f;
                
            if (regolithBar != null)
                regolithBar.value = ResourceManager.GetAmount(ResourceType.Regolith) / 1000f; // Assume max is 1000kg
        }
        
        public void UpdateGameStatus()
        {
            string status = "COLONY STATUS:\n";
            
            if (gameManager.shieldIntegrity)
                status += "Shield: [ACTIVE]\n";
            else
                status += "Shield: [INACTIVE]\n";
                
            if (gameManager.miningEnabled)
                status += "Mining: [ENABLED]\n";
            else
                status += "Mining: [DISABLED]\n";
                
            if (gameManager.engineReady)
                status += "Engine: [READY]\n";
            else
                status += "Engine: [NOT READY]\n";
                
            if (gameStatusText != null)
                gameStatusText.text = status;
        }
        
        private void OnBuildingButtonClicked()
        {
            Debug.Log("Building button clicked");
        }
        
        private void OnWorkerButtonClicked()
        {
            Debug.Log("Worker button clicked");
        }
        
        public void ShowBuildingMenu(bool show)
        {
            if (buildingMenu != null)
                buildingMenu.SetActive(show);
        }
        
        public void ShowWorkerMenu(bool show)
        {
            if (workerMenu != null)
                workerMenu.SetActive(show);
        }
        
        public void ShowNotification(string message, Color color)
        {
            Debug.Log("Notification: " + message);
        }
    }
}