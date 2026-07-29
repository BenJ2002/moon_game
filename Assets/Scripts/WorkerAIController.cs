using UnityEngine;

public class WorkerAIController : MonoBehaviour
{
    public Worker worker;
    public WorkerAI_Navigation navComponent;
    public WorkerAI_TaskManager taskManager;
    
    [Header("Worker States")]
    public enum WorkerState
    {
        Idle,
        Moving,
        Working,
        Resting,
        Emergency
    }
    
    public WorkerState currentState = WorkerState.Idle;
    
    void Start()
    {
        Debug.Log("WorkerAIController initialized");
        
        // Get references to components (will be set in inspector or via code)
        if (worker == null) worker = GetComponent<Worker>();
        if (navComponent == null) navComponent = GetComponent<WorkerAI_Navigation>();
        if (taskManager == null) taskManager = GetComponent<WorkerAI_TaskManager>();
    }
    
    void Update()
    {
        switch (currentState)
        {
            case WorkerState.Idle:
                HandleIdle();
                break;
            case WorkerState.Moving:
                HandleMoving();
                break;
            case WorkerState.Working:
                HandleWorking();
                break;
        }
    }
    
    private void HandleIdle()
    {
        // Logic for when worker is idle
    }
    
    private void HandleMoving()
    {
        // Logic for when worker is moving to destination
    }
    
    private void HandleWorking()
    {
        // Logic for when worker is working
    }
}