using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] SpawnDirection spawnDirection;

    private List<SpawnUnit> spawnList;
    private float spawnTimer = 0;
    [SerializeField] List<GameObject> vehicleList;
    public TrafficLight spawnTraffic;

    private void Awake()
    {
        spawnList = new List<SpawnUnit>();
        vehicleList = new List<GameObject>();
        
    }

    

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Current spawn size: " + spawnList.Count);
        yield return StartCoroutine(Spawner());
    }

    public void AddToSpawnList(SpawnUnit vehicle)
    {
        spawnList.Add(vehicle);
    }

    public void AssignVehicles(GameObject vehicle)
    {
        vehicleList.Add(vehicle);
    }

    private IEnumerator Spawner()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            //float spawnTimer = Time.time;
            //spawnTimer = spawnList[i].spawnTime - spawnTimer;
            yield return new WaitForSeconds(spawnList[i].spawnTime);
            Debug.Log(this.name + " spawning at " + spawnTimer + " delay");
            vehicleList[i].gameObject.transform.position = this.transform.position;

            vehicleList[i].gameObject.SetActive(true);
            vehicleList[i].gameObject.GetComponent<Car>().curTraffic = spawnTraffic;
        }
    }

    // add in 3d box collider
    // if no vehicles are in and spawn timer has been reached
    // spawn vehicle
    // otherwise, hold it in list then spawn after conditions are met
}

public enum SpawnDirection
{
    NORTH,
    SOUTH,
    EAST,
    WEST
}
