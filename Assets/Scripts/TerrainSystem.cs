using UnityEngine;
using System.Collections.Generic;

namespace MoonGame.Systems.Environment
{
    [System.Serializable]
    public class TerrainChunk
    {
        public Vector3 position;
        public int chunkId;
        public float height;
        public ResourceType resourceType;
        public bool isWalkable;
        
        public TerrainChunk(Vector3 pos, int id)
        {
            position = pos;
            chunkId = id;
            height = 0f;
            resourceType = ResourceType.Regolith;
            isWalkable = true;
        }
    }

    public class TerrainSystem : MonoBehaviour
    {
        [Header("Terrain Settings")]
        public int terrainWidth = 100;
        public int terrainHeight = 100;
        public float terrainScale = 1f;
        public float heightMultiplier = 10f;
        
        [Header("Resource Distribution")]
        public List<ResourceSpawn> resourceSpawns = new List<ResourceSpawn>();
        
        private TerrainChunk[,] terrainChunks;
        
        void Start()
        {
            InitializeTerrain();
            GenerateResources();
        }
        
        private void InitializeTerrain()
        {
            terrainChunks = new TerrainChunk[terrainWidth, terrainHeight];
            
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int z = 0; z < terrainHeight; z++)
                {
                    Vector3 position = new Vector3(x * terrainScale, 0, z * terrainScale);
                    int chunkId = x * terrainHeight + z;
                    terrainChunks[x, z] = new TerrainChunk(position, chunkId);
                }
            }
        }
        
        private void GenerateResources()
        {
            foreach (ResourceSpawn spawn in resourceSpawns)
            {
                if (spawn.resourceType == ResourceType.Regolith)
                {
                    // Logic for placing regolith resources
                    Debug.Log("Generating " + spawn.resourceType + " resources");
                }
                else if (spawn.resourceType == ResourceType.WaterIce)
                {
                    // Logic for placing water ice resources
                    Debug.Log("Generating " + spawn.resourceType + " resources");
                }
                else if (spawn.resourceType == ResourceType.MetalOre)
                {
                    // Logic for placing metal ore resources
                    Debug.Log("Generating " + spawn.resourceType + " resources");
                }
            }
        }
        
        public TerrainChunk GetTerrainChunk(int x, int z)
        {
            if (x >= 0 && x < terrainWidth && z >= 0 && z < terrainHeight)
            {
                return terrainChunks[x, z];
            }
            return null;
        }
        
        public Vector3 GetWorldPosition(int x, int z)
        {
            return new Vector3(x * terrainScale, 0, z * terrainScale);
        }
    }

    [System.Serializable]
    public class ResourceSpawn
    {
        public ResourceType resourceType;
        public int amount;
        public float spawnRate; // Chance of spawning per chunk (0-1)
        public Vector3 position;
        
        public ResourceSpawn(ResourceType type, int amount, float rate)
        {
            resourceType = type;
            this.amount = amount;
            spawnRate = rate;
        }
    }
}