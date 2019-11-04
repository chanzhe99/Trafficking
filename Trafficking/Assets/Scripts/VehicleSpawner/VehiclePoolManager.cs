using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnUnit
{
    public GameObject vehicleType;
    public SpawnPoint spawnPoint;
    public float spawnTime;
    public spawnColor spawnPointColor;
    public enum spawnColor { Red, Green, Blue, Orange, Yellow, Purple };
}

public class VehiclePoolManager : MonoBehaviour
{
    //[SerializeField] LevelData data;
    [SerializeField] List<SpawnUnit> itemsToPool;

    private GameObject spawnParent;

    public List<GameObject> pooledObjects;
    public static VehiclePoolManager Instance;

    // Simpleton instancing
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        spawnParent = new GameObject("Spawn List");
        SpawnPool();
        SetSpawnPointColor();
        SpawnPointAssign();
    }

    public GameObject GetPooledObject(string tag)
    {
        for(int i = 0; i<pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag))
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetSpecificObject(GameObject toBeCompared)
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(GameObject.ReferenceEquals(pooledObjects[i], toBeCompared))
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    // Pools all vehicles at a location
    private void SpawnPool()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < itemsToPool.Count; i++)
        {
            GameObject obj = Instantiate(itemsToPool[i].vehicleType, new Vector3(0, 0, 0), itemsToPool[i].spawnPoint.transform.rotation);
            obj.transform.SetParent(spawnParent.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // sets vehicles to their spawnpoints
    private void SpawnPointAssign()
    {
        for(int i = 0; i < itemsToPool.Count; i++)
        {
            itemsToPool[i].spawnPoint.AddToSpawnList(itemsToPool[i]);
            itemsToPool[i].spawnPoint.AssignVehicles(pooledObjects[i]);
        }
    }

    private void SetSpawnPointColor()
    {
        for (int i = 0; i < itemsToPool.Count; i++)
        {
            switch (itemsToPool[i].spawnPointColor)
            {
                case SpawnUnit.spawnColor.Blue:
                    pooledObjects[i].GetComponent<Car>().carColor = Car.CarColor.Blue;
                    break;

                case SpawnUnit.spawnColor.Green:
                    pooledObjects[i].GetComponent<Car>().carColor = Car.CarColor.Green;
                    break;

                case SpawnUnit.spawnColor.Orange:
                    pooledObjects[i].GetComponent<Car>().carColor = Car.CarColor.Orange;
                    break;

                case SpawnUnit.spawnColor.Purple:
                    pooledObjects[i].GetComponent<Car>().carColor = Car.CarColor.Purple;
                    break;

                case SpawnUnit.spawnColor.Red:
                    pooledObjects[i].GetComponent<Car>().carColor = Car.CarColor.Red;
                    break;

                case SpawnUnit.spawnColor.Yellow:
                    pooledObjects[i].GetComponent<Car>().carColor = Car.CarColor.Yellow;
                    break;
            }

        }
    }
}
