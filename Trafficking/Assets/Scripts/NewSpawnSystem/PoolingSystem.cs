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
    [SerializeField] SpawnSystem spawnSys2;
    [SerializeField] SpawnSystem spawnSys3;
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


    private void SpawnPool()
    {
        for (int i = 0; i < 12; i++)
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
        obj.SetActive(false);
        spawnSys.AddToSlow(spawn);
        spawnSys2.AddToSlow(spawn);
        spawnSys3.AddToSlow(spawn);
       
    }

    public void SpawnMed()
    {
        GameObject obj1 = Instantiate((med1), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj1, carScript = obj1.GetComponent<Car>() };
        obj1.SetActive(false);
        spawnSys.AddToMed(spawn);
        spawnSys2.AddToMed(spawn);
        spawnSys3.AddToMed(spawn);
        GameObject obj2 = Instantiate((med2), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj2, carScript = obj2.GetComponent<Car>() };
        obj2.SetActive(false);
        spawnSys.AddToMed(spawn);
        spawnSys2.AddToMed(spawn);
        spawnSys3.AddToMed(spawn);
        GameObject obj3 = Instantiate((med3), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj3, carScript = obj3.GetComponent<Car>() };
        obj3.SetActive(false);
        spawnSys.AddToMed(spawn);
        spawnSys2.AddToMed(spawn);
        spawnSys3.AddToMed(spawn);
        GameObject obj4 = Instantiate((med4), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj4, carScript = obj4.GetComponent<Car>() };
        obj4.SetActive(false);
        spawnSys.AddToMed(spawn);
        spawnSys2.AddToMed(spawn);
        spawnSys3.AddToMed(spawn);
    }

    public void SpawnFast()
    {
        GameObject obj5 = Instantiate((fast), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj5, carScript = obj5.GetComponent<Car>() };
        obj5.SetActive(false);
        spawnSys.AddToFast(spawn);
        spawnSys2.AddToFast(spawn);
        spawnSys3.AddToFast(spawn);
    }

}
