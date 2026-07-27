using UnityEngine;

public class Worker : MonoBehaviour
{
    public string workerName;
    public int workerId;
    public float health;
    public float maxHealth;
    public ResourceType carriedResource;
    public float carryingAmount;
    
    void Start()
    {
        health = maxHealth;
        carriedResource = ResourceType.Regolith;
        carryingAmount = 0f;
    }
    
    void Update()
    {
        // Basic worker behavior
        if (health <= 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Debug.Log($"{workerName} has died.");
        Destroy(gameObject);
    }
    
    public void CarryResource(ResourceType resource, float amount)
    {
        carriedResource = resource;
        carryingAmount = amount;
    }
    
    public bool IsFull()
    {
        return carryingAmount >= 100f; // Assuming max capacity of 100 units
    }
}