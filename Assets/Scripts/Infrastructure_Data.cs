using System.Collections.Generic;
using UnityEngine;

public class Infrastructure_Data : MonoBehaviour 
{
    public static readonly StructureData RE_HABITAT = new StructureData { id = "habitat", name = "Habitat Module", baseCost = 200f, maintenanceCost = 10f };
    public static readonly StructureData RE_SOLAR_PANEL = new StructureData { id = "solar_panel", name = "Solar Array", baseCost = 150f, maintenanceCost = 5f };
    public static readonly StructureData RE_REFINERY = new StructureData { id = "refinery", name = "Regolith Refinery", baseCost = 800f, maintenanceCost = 20f };
    public static readonly StructureData RE_MINING_STATION = new StructureData { id = "mining_station", name = "Mining Station", baseCost = 400f, maintenanceCost = 15f };
    public static readonly StructureData RE_RESEARCH_LAB = new StructureData { id = "research_lab", name = "Research Laboratory", baseCost = 500f, maintenanceCost = 25f };

    public struct StructureData 
    {
        public string id;
        public string name;
        public float baseCost;
        public float maintenanceCost;
        public float productionRate;
        
        // Default constructor
        public StructureData(string id, string name, float baseCost, float maintenanceCost) 
        {
            this.id = id;
            this.name = name;
            this.baseCost = baseCost;
            this.maintenanceCost = maintenanceCost;
            this.productionRate = 1.0f; // Default rate
        }
    }
}