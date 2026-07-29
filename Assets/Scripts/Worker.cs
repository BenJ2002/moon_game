using UnityEngine;
using System.Collections.Generic;

public class Worker : MonoBehaviour 
{
    public string workerName = "Worker";
    public ResourceType carriedResource = ResourceType.Regolith;
    public float carryingCapacity = 100f;
    public float currentCarryAmount = 0f;
    public float health = 100f;
    public bool isIdle = true;
    
    void Start()
    {
        Debug.Log($"Worker {workerName} created with carrying capacity of {carryingCapacity}");
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