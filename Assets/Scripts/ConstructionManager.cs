using UnityEngine;
using System.Collections.Generic;

public class ConstructionManager : MonoBehaviour
{
    public Dictionary<string, float> constructionCosts = new Dictionary<string, float>();
    
    void Start() 
    {
        // Define initial construction costs
        constructionCosts["Habitat"] = 200f;
        constructionCosts["SolarPanel"] = 150f;
        constructionCosts["Refinery"] = 300f;
        constructionCosts["MiningStation"] = 400f;
        constructionCosts["ResearchLab"] = 500f;
        
        Debug.Log("ConstructionManager initialized with starting costs");
    }
    
    public void StartConstruction(string structureName) 
    {
        Debug.Log($"Started construction of {structureName}");
        // Additional logic for construction here
    }
}