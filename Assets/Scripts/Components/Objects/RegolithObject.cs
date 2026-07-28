using UnityEngine;
using System.Collections;

namespace MoonGame.Components.Objects
{
    public class RegolithObject : MonoBehaviour
    {
        [Header("Resource Properties")]
        public ResourceType resourceType = ResourceType.Regolith;
        public float resourceAmount = 100f;
        public float depletionRate = 1f;
        
        [Header("Visual Settings")]
        public Material resourceMaterial;
        public float maxSize = 2f;
        public float minSize = 0.5f;
        public float currentSize;
        
        [Header("Collection Settings")]
        public float collectionRadius = 2f;
        public bool isDepleted = false;
        public float depletionTime = 0f;
        
        private GameManager gameManager;
        private ResourceManager resourceManager;
        private Renderer objectRenderer;
        
        void Start()
        {
            InitializeObject();
        }
        
        private void InitializeObject()
        {
            // Setup initial size
            currentSize = Random.Range(minSize, maxSize);
            transform.localScale = Vector3.one * currentSize;
            
            // Get references to managers
            gameManager = FindObjectOfType<GameManager>();
            resourceManager = FindObjectOfType<ResourceManager>();
            objectRenderer = GetComponent<Renderer>();
            
            if (resourceManager == null)
                Debug.LogError("ResourceManager not found!");
                
            if (gameManager == null)
                Debug.LogError("GameManager not found!");
        }
        
        void Update()
        {
            // Handle visual effects or animations here if needed
        }
        
        public void CollectResource(float amount)
        {
            if (isDepleted) return;
            
            if (amount > resourceAmount)
                amount = resourceAmount;
                
            // Give resources to the player
            ResourceManager.AddResource(resourceType, amount);
            
            // Reduce available resource
            resourceAmount -= amount;
            
            // Update visual representation based on remaining amount
            UpdateVisuals();
            
            Debug.Log("Collected " + amount + " units of " + resourceType);
            
            if (resourceAmount <= 0)
            {
                DepleteResource();
            }
        }
        
        private void UpdateVisuals()
        {
            // Scale down based on remaining resources
            float scale = Mathf.Max(0.1f, resourceAmount / 100f);
            transform.localScale = Vector3.one * currentSize * scale;
            
            // Change color based on depletion level (optional)
            if (objectRenderer != null && resourceMaterial != null)
            {
                Color newColor = resourceMaterial.color;
                newColor.a = Mathf.Clamp(resourceAmount / 100f, 0.2f, 1f);
                objectRenderer.material.color = newColor;
            }
        }
        
        public void DepleteResource()
        {
            isDepleted = true;
            
            // Trigger depletion effects or animations
            Debug.Log("Resource " + resourceType + " depleted");
            
            if (gameManager != null)
            {
                // Update game state variables
                if (resourceType == ResourceType.Regolith)
                    gameManager.regolithCollected += 100f; // Placeholder for actual collection
            }
            
            // Destroy the object after depletion
            StartCoroutine(DestroyObject());
        }
        
        private IEnumerator DestroyObject()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
        
        public bool CanCollect(float amount)
        {
            return !isDepleted && resourceAmount >= amount;
        }
        
        public float GetRemainingAmount()
        {
            return resourceAmount;
        }
        
        public Vector3 GetPosition()
        {
            return transform.position;
        }
        
        public ResourceType GetResourceType()
        {
            return resourceType;
        }
    }
}