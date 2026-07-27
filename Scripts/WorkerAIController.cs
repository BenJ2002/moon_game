using UnityEngine;

public class WorkerAIController : MonoBehaviour 
{
    public Worker worker;
    public WorkerAI_Navigation navigation;
    public WorkerAI_TaskManager taskManager;
    
    private bool isWorking = false;
    private string currentTask;
    private Transform currentDestination;
    
    void Start() 
    {
        // Initialize the AI controller
        if (worker == null) 
        {
            worker = GetComponent<Worker>();
        }
        
        if (navigation == null) 
        {
            navigation = GetComponent<WorkerAI_Navigation>();
        }
        
        if (taskManager == null) 
        {
            taskManager = FindObjectOfType<WorkerAI_TaskManager>();
        }
    }
    
    void Update() 
    {
        if (!isWorking) 
        {
            // Assign a new task
            AssignNewTask();
        }
    }
    
    private void AssignNewTask() 
    {
        isWorking = true;
        currentTask = "Gather Regolith"; // Placeholder for more complex logic
        
        // Find a resource point to go to (this would be more complex in a real game)
        GameObject[] resourcePoints = GameObject.FindGameObjectsWithTag("ResourcePoint");
        
        if (resourcePoints.Length > 0) 
        {
            Transform randomPoint = resourcePoints[Random.Range(0, resourcePoints.Length)].transform;
            currentDestination = randomPoint;
            navigation.destination = currentDestination;
        }
    }
    
    public void TaskCompleted() 
    {
        isWorking = false;
        Debug.Log($"Worker {worker.workerName} completed task: {currentTask}");
    }
}