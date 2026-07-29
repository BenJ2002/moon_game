using UnityEngine;

public class WorkerAI_Navigation : MonoBehaviour 
{
    public Transform destination;
    public float moveSpeed = 5f;
    public float reachDistance = 1f;
    
    void Start()
    {
        Debug.Log("WorkerAI_Navigation initialized");
    }
    
    void Update()
    {
        if (destination != null)
        {
            Vector3 direction = destination.position - transform.position;
            if (direction.magnitude > reachDistance)
            {
                transform.position += direction.normalized * moveSpeed * Time.deltaTime;
            }
        }
    }
}