using UnityEngine;
using System.Collections.Generic;

public enum ResourceType
{
    Regolith,        // Used for construction and base building
    Ice,             // The primary source of Oxygen and Water
    HeavyMetal,      // Used for high-level machinery (Gold/Steel transition)
    Consumables      // Food and Medical supplies
}

public class ResourceManager : MonoBehaviour
{
    private static Dictionary<ResourceType, float> _inventory = new Dictionary<ResourceType, float>();

    // Public properties to be read by UI (the Resource Bar)
    public static float GetAmount(ResourceType type)
    {
        if (!_inventory.ContainsKey(type)) _inventory[type] = 0f;
        return _inventory[type];
    }

    public static void AddResource(ResourceType type, float amount)
    {
        if (!_inventory.ContainsKey(type)) _inventory[type] = 0f;
        _inventory[type] += amount;
        Debug.Log($"Added {amount} of {type}. Total: {_inventory[type]}");
    }

    public static bool TryConsumeResource(ResourceType type, float amount)
    {
        if (!_inventory.ContainsKey(type)) _inventory[type] = 0f;
        
        if (_inventory[type] >= amount)
        {
            _inventory[type] -= amount;
            return true;
        }
        
        Debug.LogWarning($"Insufficient {type}! Needed: {amount}, Have: {_inventory[type]}");
        return false;
    }

    // This method is called by the logic that checks building "Construction Costs"
    public static bool ConfirmPurchase(ResourceType type, float amount)
    {
        if (TryConsumeResource(type, amount)) 
        {
            Debug.Log($"Purchased {amount} of {type}. Remaining: {_inventory[type]}");
            return true;
        }
        return false;
    }

    // Helper for the UI Bar to fetch all available resources at once
    public static Dictionary<ResourceType, float> GetAllInventory()
    {
        return new Dictionary<ResourceType, float>(_inventory);
    }
}
