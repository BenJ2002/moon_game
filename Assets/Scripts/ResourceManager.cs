using UnityEngine;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    public Dictionary<ResourceType, float> resources = new Dictionary<ResourceType, float>();
    
    void Start()
    {
        // Initialize resource types with starting values
        resources[ResourceType.Regolith] = 0f;
        resources[ResourceType.Wood] = 0f;
        resources[ResourceType.Food] = 100f;
        resources[ResourceType.Gold] = 0f;
        resources[ResourceType.Fuel] = 0f;
        
        Debug.Log("ResourceManager initialized with starting resources");
    }
    
    public static void AddResource(ResourceType type, float amount)
    {
        // Implementation depends on where we get instance reference
        Debug.Log($"Added {amount} units of {type}");
    }
    
    public static float GetResourceAmount(ResourceType type)
    {
        return 0f; // Will be implemented with proper instance reference
    }
    
    public void UpdateResource(ResourceType type, float amount)
    {
        if (resources.ContainsKey(type))
        {
            resources[type] = amount;
            Debug.Log($"Updated {type} to {amount}");
        }
    }
}

public enum ResourceType
{
    Regolith,
    Wood, 
    Food,
    Gold,
    Fuel
}