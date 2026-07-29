using UnityEngine;
using System.Collections.Generic;

namespace MoonGame.Systems.Environment
{
    public class NavigationSystem : MonoBehaviour
    {
        [Header("Navigation Settings")]
        public float agentSpeed = 5f;
        public float destinationThreshold = 1f;
        
        [Header("Pathfinding")]
        public bool useAStar = true;
        public LayerMask obstacleLayer;
        
        [Header("Waypoint System")]
        public List<Vector3> waypoints = new List<Vector3>();
        public int currentWaypointIndex = 0;
        
        private Transform targetTransform;
        private Vector3 targetPosition;
        private bool isMoving = false;
        private Worker worker;
        
        void Start()
        {
            worker = GetComponent<Worker>();
            
            if (worker == null)
                Debug.LogError("Worker component required for NavigationSystem");
                
            SetupPathfinding();
        }
        
        void Update()
        {
            if (!isMoving) return;
            
            if (targetTransform != null)
            {
                targetPosition = targetTransform.position;
            }
            
            MoveTowardsTarget();
        }
        
        private void SetupPathfinding()
        {
            // Initialize pathfinding settings
            Debug.Log("Navigation system initialized");
        }
        
        public void SetDestination(Vector3 destination)
        {
            this.targetPosition = destination;
            this.targetTransform = null;
            isMoving = true;
        }
        
        public void SetDestination(Transform target)
        {
            this.targetTransform = target;
            this.targetPosition = target.position;
            isMoving = true;
        }
        
        private void MoveTowardsTarget()
        {
            if (Vector3.Distance(transform.position, targetPosition) <= destinationThreshold)
            {
                OnDestinationReached();
                return;
            }
            
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * agentSpeed * Time.deltaTime;
        }
        
        private void OnDestinationReached()
        {
            isMoving = false;
            Debug.Log("Destination reached by " + worker.workerName);
            
            // Trigger any event or task completion here
            if (worker != null)
            {
                // Notify worker AI that destination is reached
                WorkerAIController controller = worker.GetComponent<WorkerAIController>();
                if (controller != null)
                {
                    controller.TaskCompleted();
                }
            }
        }
        
        public void AddWaypoint(Vector3 waypoint)
        {
            waypoints.Add(waypoint);
        }
        
        public void ClearWaypoints()
        {
            waypoints.Clear();
            currentWaypointIndex = 0;
        }
        
        public Vector3 GetCurrentWaypoint()
        {
            if (waypoints.Count > 0 && currentWaypointIndex < waypoints.Count)
                return waypoints[currentWaypointIndex];
            else
                return transform.position;
        }
        
        public void MoveToNextWaypoint()
        {
            if (currentWaypointIndex < waypoints.Count - 1)
            {
                currentWaypointIndex++;
                SetDestination(GetCurrentWaypoint());
            }
            else
            {
                // Reached end of waypoints
                isMoving = false;
            }
        }
        
        public bool IsMoving()
        {
            return isMoving;
        }
    }
}