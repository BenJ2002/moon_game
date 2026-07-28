using UnityEngine;

namespace MoonGame.Systems.Camera
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Settings")]
        public float moveSpeed = 10f;
        public float rotateSpeed = 100f;
        public float zoomSpeed = 5f;
        public float minZoom = 5f;
        public float maxZoom = 50f;
        
        [Header("Camera Bounds")]
        public Vector2 minXZ = new Vector2(-50, -50);
        public Vector2 maxXZ = new Vector2(50, 50);
        
        [Header("Target Settings")]
        public Transform target;
        public float followDistance = 10f;
        public float heightOffset = 5f;
        
        private Camera mainCamera;
        private bool isDragging = false;
        private Vector3 lastMousePosition;
        
        void Start()
        {
            InitializeCamera();
        }
        
        private void InitializeCamera()
        {
            mainCamera = GetComponent<Camera>();
            
            if (mainCamera == null)
            {
                Debug.LogError("Camera component not found on this object!");
                return;
            }
            
            // Set initial position
            if (target != null)
            {
                Vector3 position = target.position + new Vector3(0, heightOffset, -followDistance);
                transform.position = position;
            }
            
            Debug.Log("Camera Controller initialized");
        }
        
        void Update()
        {
            HandleInput();
            UpdateCameraPosition();
        }
        
        private void HandleInput()
        {
            // Zoom with scroll wheel
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                mainCamera.fieldOfView += scroll * zoomSpeed;
                mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 30, 90);
            }
            
            // Camera panning with right mouse button
            if (Input.GetMouseButtonDown(1))
            {
                isDragging = true;
                lastMousePosition = Input.mousePosition;
            }
            
            if (Input.GetMouseButtonUp(1))
            {
                isDragging = false;
            }
            
            if (isDragging)
            {
                Vector3 delta = Input.mousePosition - lastMousePosition;
                delta *= 0.5f; // Adjust sensitivity
                
                transform.Translate(-delta.x * Time.deltaTime * moveSpeed, 0, -delta.y * Time.deltaTime * moveSpeed);
                
                lastMousePosition = Input.mousePosition;
            }
        }
        
        private void UpdateCameraPosition()
        {
            if (target == null)
                return;
                
            // Calculate target position with offset
            Vector3 targetPosition = new Vector3(target.position.x, 
                                               target.position.y + heightOffset, 
                                               target.position.z - followDistance);
            
            // Apply camera movement
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            
            // Restrict camera to bounds
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minXZ.x, maxXZ.x),
                transform.position.y,
                Mathf.Clamp(transform.position.z, minXZ.y, maxXZ.y)
            );
            
            // Keep facing target (optional)
            transform.LookAt(target);
        }
        
        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
        
        public void SetFollowDistance(float distance)
        {
            followDistance = Mathf.Clamp(distance, 5f, 30f);
        }
        
        public void SetHeightOffset(float offset)
        {
            heightOffset = Mathf.Clamp(offset, 2f, 20f);
        }
        
        public Vector3 GetCameraPosition()
        {
            return transform.position;
        }
    }
}