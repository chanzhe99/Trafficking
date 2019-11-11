using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnSystemUnit
{
    public GameObject car;
    public Car carScript;
}

public class PoolingSystem : MonoBehaviour
{
    [SerializeField] GameObject slow;
    [SerializeField] GameObject med1;
    [SerializeField] GameObject med2;
    [SerializeField] GameObject med3;
    [SerializeField] GameObject med4;
    [SerializeField] GameObject fast;
    [SerializeField] SpawnSystem spawnSys;
    //[SerializeField] LevelData data;

    SpawnSystemUnit spawn;

    private GameObject spawnParent;

    public List<GameObject> pooledObjects;
    public static PoolingSystem Instance;

    // Simpleton instancing
    void Awake()
    {
        if (Instance == null)
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
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag))
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetSpecificObject(GameObject toBeCompared)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (GameObject.ReferenceEquals(pooledObjects[i], toBeCompared))
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    // Pools all vehicles at a location
    private void SpawnPool()
    {
        for(int i=0; i<12; i++)
        {
            SpawnSlow();
            SpawnMed();
            SpawnFast();
        }
    }

    public void SpawnSlow()
    {
        GameObject obj = Instantiate(slow, new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj, carScript = obj.GetComponent<Car>() };
        spawnSys.AddToSlow(spawn);
    }

    public void SpawnMed()
    {
        GameObject obj1 = Instantiate((med1), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj1, carScript = obj1.GetComponent<Car>() };
        spawnSys.AddToMed(spawn);
        GameObject obj2 = Instantiate((med2), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj2, carScript = obj2.GetComponent<Car>() };
        spawnSys.AddToMed(spawn);
        GameObject obj3 = Instantiate((med3), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj3, carScript = obj3.GetComponent<Car>() };
        spawnSys.AddToMed(spawn);
        GameObject obj4 = Instantiate((med4), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj4, carScript = obj4.GetComponent<Car>() };
        spawnSys.AddToMed(spawn);
    }

    public void SpawnFast()
    {
        GameObject obj5 = Instantiate((fast), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj5, carScript = obj5.GetComponent<Car>() };
        spawnSys.AddToFast(spawn);
    }

    // sets vehicles to their spawnpoints
  


}
