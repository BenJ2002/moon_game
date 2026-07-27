using UnityEngine;
using System.Collections.Generic;

public class WorkerAI_TaskManager : MonoBehaviour 
{
    public List<Worker> workers;
    private Dictionary<Worker, string> currentTasks = new Dictionary<Worker, string>();
    
    void Start() 
    {
        AssignTasks();
    }
    
    private void AssignTasks() 
    {
        foreach (Worker worker in workers) 
        {
            AssignTask(worker);
        }
    }
    
    private void AssignTask(Worker worker) 
    {
        // Assign a random task for now
        currentTasks[worker] = "Gather Regolith";
        Debug.Log($"Assigned {currentTasks[worker]} task to Worker {worker.workerName} at position {worker.transform.position}");
    }
    
    public bool CheckCompletion(Worker worker, string result) 
    {
        if (!currentTasks.ContainsKey(worker)) 
        {
            return false;
        }
        
        string assignedTask = currentTasks[worker];
        if (assignedTask.ToLower() == result.ToLower()) 
        {
            UnassignTask(worker);
            Debug.Log($"Worker {worker.workerName} completed {result} task at position {worker.transform.position}");
            return true;
        }
        return false;
    }
    
    private void UnassignTask(Worker worker) 
    {
        currentTasks.Remove(worker);
        AssignTask(worker); // Reassign a new task if needed
    }
}