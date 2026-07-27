using UnityEngine;

public class WorkerAI_Navigation : MonoBehaviour
{
    private const float movementSpeed = 5f;
    
    public Transform destination;
    public Worker worker;
    
    void Update()
    {
        if (destination != null)
        {
            float distanceToDestination = Vector3.Distance(transform.position, destination.position);
            
            if (distanceToDestination <= 1f)
            {
                // Destination reached. Perform the task.
                PerformTask();
            }
            else
            {
                MoveTowardsDestination();
            }
        }
    }

    private void MoveTowardsDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, movementSpeed * Time.deltaTime);
    }

    private void PerformTask()
    {
        Debug.Log($"Worker {worker.workerName} reached destination at {destination.position}. Performing task...");
        
        // Placeholder for actual task logic
        // Could be gathering resources, building structures, etc.
    }
}