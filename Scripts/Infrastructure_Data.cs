using UnityEngine;

[System.Serializable]
public struct StructureData
{
    public string id;
    public string name;
    public float baseCost; // Total amount of "Resource" needed for completion (integrated with manager)
    public float maintenanceCost; // Amount consumed per minute
    public float productionRate; // Value gained per minute (e.g., Oxygen, Fuel)
}

public static class StructureTypes
{
    // Base Layer Structures
    public static readonly StructureData O2_SCRUBBER = new StructureData { id = "o2_scrubber", name = "Oxygen Scrubber", baseCost = 500f, maintenanceCost = 10f, productionRate = 0.5f };
    public static readonly StructureData RE_REFINERY = new StructureData { id = "refinery", name = "Regolith Refinery", baseCost = 800f, maintenanceCost = 20f, productionRate = 1.2f };

    // Expansion Level Structures
    public static readonly StructureData POWER_ARRAY = new StructureData { id = "power_array", name = "Solar Array", baseCost = 1000f, maintenanceCost = 5f, productionRate = 10f };
}
