using UnityEngine;
using System.Collections.Generic;

public class WorkerAI_TaskManager : MonoBehaviour 
{
    public Dictionary<Worker, string> currentTasks = new Dictionary<Worker, string>();
    
    void Start()
    {
        Debug.Log("WorkerAI_TaskManager initialized");
    }
    
    void Update()
    {
        // Task management logic
    }
    
    public void AssignTask(Worker worker, string task)
    {
        currentTasks[worker] = task;
        Debug.Log($"Assigned task '{task}' to worker {worker.workerName}");
    }
    
    public string GetTaskForWorker(Worker worker)
    {
        if (currentTasks.ContainsKey(worker))
            return currentTasks[worker];
        return "No task assigned";
    }
    
    public void CompleteTask(Worker worker)
    {
        if (currentTasks.ContainsKey(worker))
        {
            Debug.Log($"Task completed for worker {worker.workerName}");
            currentTasks.Remove(worker);
        }
    }
}