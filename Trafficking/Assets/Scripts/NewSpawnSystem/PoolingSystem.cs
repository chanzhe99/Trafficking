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
    [SerializeField] Canvas patienceCanvas;
    [SerializeField] GameObject slow;
    [SerializeField] GameObject med1;
    [SerializeField] GameObject med2;
    [SerializeField] GameObject med3;
    [SerializeField] GameObject med4;
    [SerializeField] GameObject fast;
    [SerializeField] List<SpawnSystem> spawnSys;
    //[SerializeField] LevelData data;

    SpawnSystemUnit spawn;

    private GameObject spawnParent;
    public int activeCarNumbers;

    public List<GameObject> pooledObjects;
    public static PoolingSystem Instance;

    // Simpleton instancing
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    private void FixedUpdate()
    {
        if (activeCarNumbers > 15)
        {
            if (AudioManager.instance.CheckIfPlaying("Traffic Jam SFX") == false)
            {
                if (AudioManager.instance.CheckIfPlaying("Busy Street SFX") == true)
                    AudioManager.instance.StopPlaying("Busy Street SFX");
                AudioManager.instance.Play("Traffic Jam SFX");
            }
            else
            {
                AudioManager.instance.Unpause("Traffic Jam SFX");
            }
        }
        else
        {
            if (AudioManager.instance.CheckIfPlaying("Busy Street SFX") == false)
            {
                if (AudioManager.instance.CheckIfPlaying("Traffic Jam SFX") == true)
                    AudioManager.instance.StopPlaying("Traffic Jam SFX");
                AudioManager.instance.Play("Busy Street SFX");
            }
            else
            {
                AudioManager.instance.Unpause("Busy Street SFX");
            }
        }
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
        obj.GetComponent<SpawnPatienceUI>().SetCanvas(patienceCanvas);
        obj.SetActive(false);
        for(int i=0; i< spawnSys.Count; i++)
        {
            spawnSys[i].AddToSlow(spawn);
        }       
    }

    public void SpawnMed()
    {
        GameObject obj1 = Instantiate((med1), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj1, carScript = obj1.GetComponent<Car>() };
        obj1.GetComponent<SpawnPatienceUI>().SetCanvas(patienceCanvas);
        obj1.SetActive(false);
        for (int i = 0; i < spawnSys.Count; i++)
        {
            spawnSys[i].AddToMed(spawn);
        }
        GameObject obj2 = Instantiate((med2), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj2, carScript = obj2.GetComponent<Car>() };
        obj2.GetComponent<SpawnPatienceUI>().SetCanvas(patienceCanvas);
        obj2.SetActive(false);
        for (int i = 0; i < spawnSys.Count; i++)
        {
            spawnSys[i].AddToMed(spawn);
        }
        GameObject obj3 = Instantiate((med3), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj3, carScript = obj3.GetComponent<Car>() };
        obj3.GetComponent<SpawnPatienceUI>().SetCanvas(patienceCanvas);
        obj3.SetActive(false);
        for (int i = 0; i < spawnSys.Count; i++)
        {
            spawnSys[i].AddToMed(spawn);
        }
        GameObject obj4 = Instantiate((med4), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj4, carScript = obj4.GetComponent<Car>() };
        obj4.GetComponent<SpawnPatienceUI>().SetCanvas(patienceCanvas);
        obj4.SetActive(false);
        for (int i = 0; i < spawnSys.Count; i++)
        {
            spawnSys[i].AddToMed(spawn);
        }
    }

    public void SpawnFast()
    {
        GameObject obj5 = Instantiate((fast), new Vector3(0, 0, 0), Quaternion.identity);
        spawn = new SpawnSystemUnit { car = obj5, carScript = obj5.GetComponent<Car>() };
        obj5.GetComponent<SpawnPatienceUI>().SetCanvas(patienceCanvas);
        obj5.SetActive(false);
        for (int i = 0; i < spawnSys.Count; i++)
        {
            spawnSys[i].AddToFast(spawn);
        }
    }

}
