using UnityEngine;
using System.Collections.Generic;

namespace MoonGame.Systems.Environment
{
    public class MapSystem : MonoBehaviour
    {
        [Header("Map Settings")]
        public int mapWidth = 100;
        public int mapHeight = 100;
        public float tileScale = 1f;
        
        [Header("Colony Information")]
        public Vector3 colonyCenter = Vector3.zero;
        public float colonyRadius = 10f;
        
        [Header("Resource Markers")]
        public List<Marker> resourceMarkers = new List<Marker>();
        public List<Marker> buildingMarkers = new List<Marker>();
        public List<Marker> workerMarkers = new List<Marker>();
        
        void Start()
        {
            InitializeMap();
        }
        
        private void InitializeMap()
        {
            Debug.Log("Initializing Map System with dimensions: " + mapWidth + "x" + mapHeight);
            GenerateMarkers();
        }
        
        private void GenerateMarkers()
        {
            // Generate resource markers
            foreach (Marker marker in resourceMarkers)
            {
                Debug.Log("Resource marker at: " + marker.position);
            }
            
            // Generate building markers
            foreach (Marker marker in buildingMarkers)
            {
                Debug.Log("Building marker at: " + marker.position);
            }
            
            // Generate worker markers
            foreach (Marker marker in workerMarkers)
            {
                Debug.Log("Worker marker at: " + marker.position);
            }
        }
        
        public Vector3 GetWorldPosition(int x, int z)
        {
            return new Vector3(x * tileScale, 0, z * tileScale);
        }
        
        public bool IsWithinColonyBounds(Vector3 position)
        {
            float distance = Vector3.Distance(position, colonyCenter);
            return distance <= colonyRadius;
        }
        
        public void AddResourceMarker(ResourceType type, Vector3 position)
        {
            Marker marker = new Marker();
            marker.position = position;
            marker.type = "Resource";
            marker.resourceType = type;
            resourceMarkers.Add(marker);
            
            Debug.Log("Added resource marker for " + type + " at: " + position);
        }
        
        public void AddBuildingMarker(Vector3 position, string buildingType)
        {
            Marker marker = new Marker();
            marker.position = position;
            marker.type = "Building";
            marker.buildingType = buildingType;
            buildingMarkers.Add(marker);
            
            Debug.Log("Added building marker for " + buildingType + " at: " + position);
        }
    }

    [System.Serializable]
    public class Marker
    {
        public Vector3 position;
        public string type; // "Resource", "Building", "Worker"
        public ResourceType resourceType;
        public string buildingType;
        public bool isHighlighted;
        
        public Marker()
        {
            position = Vector3.zero;
            type = "";
            resourceType = ResourceType.Regolith;
            buildingType = "";
            isHighlighted = false;
        }
    }
}