using UnityEngine;
using System.Collections.Generic;

namespace MoonGame.Systems.Environment
{
    public class BuildingSystem : MonoBehaviour
    {
        [Header("Building Settings")]
        public List<BuildingBlueprint> buildingBlueprints = new List<BuildingBlueprint>();
        public Dictionary<string, BuildingInstance> builtBuildings = new Dictionary<string, BuildingInstance>();
        
        [Header("Construction")]
        public float constructionTime = 5f;
        public bool isConstructing = false;
        
        void Start()
        {
            InitializeBuildingSystem();
        }
        
        private void InitializeBuildingSystem()
        {
            Debug.Log("Building System initialized with " + buildingBlueprints.Count + " blueprints");
        }
        
        public BuildingBlueprint GetBuildingBlueprint(string name)
        {
            foreach (BuildingBlueprint blueprint in buildingBlueprints)
            {
                if (blueprint.name == name)
                    return blueprint;
            }
            return null;
        }
        
        public bool CanBuild(string buildingName, Vector3 position)
        {
            BuildingBlueprint blueprint = GetBuildingBlueprint(buildingName);
            if (blueprint == null)
                return false;
                
            // Check if player has required resources
            foreach (var cost in blueprint.costs)
            {
                if (ResourceManager.GetAmount(cost.resourceType) < cost.amount)
                    return false;
            }
            
            // Check if build location is valid (terrain check, etc.)
            return true;
        }
        
        public void StartConstruction(string buildingName, Vector3 position)
        {
            if (!CanBuild(buildingName, position))
                return;
                
            isConstructing = true;
            
            BuildingBlueprint blueprint = GetBuildingBlueprint(buildingName);
            if (blueprint == null)
                return;
                
            // Deduct resources for construction
            foreach (var cost in blueprint.costs)
            {
                ResourceManager.TryConsumeResource(cost.resourceType, cost.amount);
            }
            
            Debug.Log("Started construction of " + buildingName + " at position: " + position);
        }
        
        public void CompleteConstruction(string buildingName, Vector3 position)
        {
            isConstructing = false;
            
            // Create the actual building instance
            BuildingInstance instance = new BuildingInstance();
            instance.name = buildingName;
            instance.position = position;
            instance.buildTime = Time.time;
            
            builtBuildings[buildingName + "_" + position.ToString()] = instance;
            
            Debug.Log("Completed construction of " + buildingName);
        }
        
        public void UpgradeBuilding(string buildingName)
        {
            // Implementation for upgrading existing buildings
            Debug.Log("Upgrading building: " + buildingName);
        }
    }

    [System.Serializable]
    public class BuildingBlueprint
    {
        public string name;
        public string description;
        public Vector3 size;
        public float constructionTime;
        public List<ResourceCost> costs;
        public List<string> requires;
        public bool isUpgradable;
        
        public BuildingBlueprint()
        {
            costs = new List<ResourceCost>();
            requires = new List<string>();
            isUpgradable = false;
        }
    }

    [System.Serializable]
    public class BuildingInstance
    {
        public string name;
        public Vector3 position;
        public float buildTime;
        public bool isUpgraded;
        public int level = 1;
        
        public BuildingInstance()
        {
            BuildTime = Time.time;
        }
    }

    [System.Serializable]
    public class ResourceCost
    {
        public ResourceType resourceType;
        public float amount;
        
        public ResourceCost(ResourceType type, float amt)
        {
            resourceType = type;
            amount = amt;
        }
    }
}