using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] SpawnDirection spawnDirection;
    [SerializeField] List<GameObject> vehicleList;
    
    private RaycastHit hit;
    private bool isSpawnPointClear = false;
    private bool isCarSpawned;
    private List<SpawnUnit> spawnList;

    public TrafficLight spawnTraffic;

    private void Awake()
    {
        spawnList = new List<SpawnUnit>();
        vehicleList = new List<GameObject>();
    }

    IEnumerator Start()
    {
        isSpawnPointClear = true;
        //yield return new WaitForSeconds(3);
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
            isCarSpawned = false;
            while (!isCarSpawned)
            {
                yield return new WaitForSeconds(spawnList[i].spawnTime);
                ShootRayCast();
                if (isSpawnPointClear)
                {
                    //Debug.Log(this.name + " spawning at " + spawnList[i].spawnTime + " delay");
                    vehicleList[i].gameObject.transform.position = this.transform.position;
                    SpawnRotation(i);

                    vehicleList[i].gameObject.SetActive(true);
                    vehicleList[i].gameObject.GetComponent<Car>().curTraffic = spawnTraffic;
                    isCarSpawned = true;
                }
                else
                {
                    isCarSpawned = false;
                    Debug.Log("Spawn point not clear. Wait.");
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }

    private void SpawnRotation(int vehicleNumber)
    {
        if (spawnDirection == SpawnDirection.NORTH)
        {
            vehicleList[vehicleNumber].gameObject.transform.rotation = Quaternion.Euler(-90,0, 0);
        }
        else if(spawnDirection == SpawnDirection.EAST)
        {
            vehicleList[vehicleNumber].gameObject.transform.rotation = Quaternion.Euler(-90, 0, 90);
        }
        else if (spawnDirection == SpawnDirection.SOUTH)
        {
            vehicleList[vehicleNumber].gameObject.transform.rotation = Quaternion.Euler(-90, 0, 180);
        }
        else if (spawnDirection == SpawnDirection.WEST)
        {
            vehicleList[vehicleNumber].gameObject.transform.rotation = Quaternion.Euler(-90, 0, 270);
        }
    }

    private void ShootRayCast()
    {
        if (spawnDirection == SpawnDirection.NORTH)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.red);
            if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0,0,90)), 3, 8))
            {
                isSpawnPointClear = false;
            }
            else
            {
                isSpawnPointClear = true;
            }
        }
        else if (spawnDirection == SpawnDirection.EAST)
        {
            Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.right) * 3, Color.red);
            if (Physics.Raycast(this.transform.position, transform.TransformDirection(new Vector3(0, 0, 90)), 3))
            {
                isSpawnPointClear = false;
            }
            else
            {
                isSpawnPointClear = true;
            }
        }
        else if (spawnDirection == SpawnDirection.SOUTH)
        {
            Debug.DrawRay(transform.position, -transform.TransformDirection(Vector3.forward) * 3, Color.red);
            if (Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.forward), 3))
            {
                isSpawnPointClear = false;
            }
            else
            {
                isSpawnPointClear = true;
            }
        }
        else if (spawnDirection == SpawnDirection.WEST)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 3, Color.red);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 3))
            {
                isSpawnPointClear = false;
            }
            else
            {
                isSpawnPointClear = true;
            }
        }
    }
}

public enum SpawnDirection
{
    NORTH,
    SOUTH,
    EAST,
    WEST
}
