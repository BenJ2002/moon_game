using UnityEngine;
using System.Collections.Generic;

public class ConstructionManager : MonoBehaviour 
{
    public List<StructureData> availableStructures;
    public Dictionary<ResourceType, float> constructionCosts;
    
    void Start() 
    {
        InitializeConstructionCosts();
    }
    
    private void InitializeConstructionCosts() 
    {
        // Initialize default construction costs
        constructionCosts = new Dictionary<ResourceType, float>();
        constructionCosts[ResourceType.Regolith] = 10f;
        constructionCosts[ResourceType.Ice] = 5f;
        constructionCosts[ResourceType.HeavyMetal] = 15f;
        constructionCosts[ResourceType.Consumables] = 8f;
    }
    
    public bool CanAffordConstruction(string structureName) 
    {
        // Find the structure data
        StructureData structure = availableStructures.Find(s => s.name == structureName);
        
        if (structure == null) 
        {
            Debug.LogError($"Structure {structureName} not found!");
            return false;
        }
        
        // Check if we have enough resources
        foreach (var cost in constructionCosts) 
        {
            float availableAmount = ResourceManager.GetAmount(cost.Key);
            if (availableAmount < cost.Value) 
            {
                Debug.LogWarning($"Insufficient {cost.Key} to build {structureName}. Need: {cost.Value}, Have: {availableAmount}");
                return false;
            }
        }
        
        return true;
    }
    
    public void StartConstruction(string structureName) 
    {
        if (CanAffordConstruction(structureName)) 
        {
            // Deduct costs
            foreach (var cost in constructionCosts) 
            {
                ResourceManager.TryConsumeResource(cost.Key, cost.Value);
            }
            
            Debug.Log($"Started construction of {structureName}");
        }
    }
    
    public void CompleteConstruction(string structureName) 
    {
        Debug.Log($"Completed construction of {structureName}");
        // Add structure to player's built structures or trigger other events
    }
}