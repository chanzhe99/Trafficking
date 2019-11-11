//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnSystem : MonoBehaviour
//{
//    [SerializeField] SpawnDirection spawnDirection;
//    //[SerializeField] spawnColor spawnPointColor;
//    [SerializeField] List<SpawnSystemUnit> fast;
//    [SerializeField] List<SpawnSystemUnit> slow;
//    [SerializeField] List<SpawnSystemUnit> medium;


//    // colors are for the exits/entrances, not the Car's colors themselves
//    //public enum spawnColor { Red, Green, Blue, Orange, Yellow, Purple }; 

//    private RaycastHit hit;
//    private bool isSpawnPointClear = false;
//    private bool isCarSpawned;
//    private List<SpawnUnit> spawnList;

//    public TrafficLight spawnTraffic;

//    private void Awake()
//    {
//        spawnList = new List<SpawnUnit>();
//        vehicleList = new List<GameObject>();
//        //SetSpawnPointColor();
//    }

//    IEnumerator Start()
//    {
//        isSpawnPointClear = true;
//        //yield return new WaitForSeconds(3);
//        yield return StartCoroutine(Spawner());
//    }

//    public void AddToSlow(SpawnSystemUnit vehicle)
//    {
//        slow.Add(vehicle);
//    }

//    public void AddToMed(SpawnSystemUnit vehicle)
//    {
//        medium.Add(vehicle);
//    }
//    public void AddToFast(SpawnSystemUnit vehicle)
//    {
//        fast.Add(vehicle);
//    }

//    private IEnumerator Spawner()
//    {
//        for (int i = 0; i < spawnList.Count; i++)
//        {
//            isCarSpawned = false;
//            while (!isCarSpawned)
//            {
//                yield return new WaitForSeconds(spawnList[i].spawnTime);
//                ShootRayCast();
//                if (isSpawnPointClear)
//                {
//                    //Debug.Log(this.name + " spawning at " + spawnList[i].spawnTime + " delay");
//                    vehicleList[i].gameObject.transform.position = this.transform.position;
//                    SpawnRotation(i);

//                    vehicleList[i].gameObject.SetActive(true);
//                    vehicleList[i].gameObject.GetComponent<Car>().curTraffic = spawnTraffic;
//                    isCarSpawned = true;
//                }
//                else
//                {
//                    isCarSpawned = false;
//                    Debug.Log("Spawn point not clear. Wait.");
//                    yield return new WaitForSeconds(0.1f);
//                }
//            }
//        }
//    }

//    private void SpawnRotation(int vehicleNumber)
//    {
//        if (spawnDirection == SpawnDirection.NORTH)
//        {
//            vehicleList[vehicleNumber].gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
//        }
//        else if (spawnDirection == SpawnDirection.EAST)
//        {
//            vehicleList[vehicleNumber].gameObject.transform.rotation = Quaternion.Euler(-90, 0, 90);
//        }
//        else if (spawnDirection == SpawnDirection.SOUTH)
//        {
//            vehicleList[vehicleNumber].gameObject.transform.rotation = Quaternion.Euler(-90, 0, 180);
//        }
//        else if (spawnDirection == SpawnDirection.WEST)
//        {
//            vehicleList[vehicleNumber].gameObject.transform.rotation = Quaternion.Euler(-90, 0, 270);
//        }
//    }

//    //private void SetSpawnPointColor()
//    //{
//    //    for (int i=0; i<vehicleList.Count; i++)
//    //    {
//    //        switch (spawnPointColor)
//    //        {
//    //            case spawnColor.Blue:
//    //                vehicleList[i].GetComponent<Car>().carColor = Car.CarColor.Blue;
//    //                break;

//    //            case spawnColor.Green:
//    //                vehicleList[i].GetComponent<Car>().carColor = Car.CarColor.Green;
//    //                break;

//    //            case spawnColor.Orange:
//    //                vehicleList[i].GetComponent<Car>().carColor = Car.CarColor.Orange;
//    //                break;

//    //            case spawnColor.Purple:
//    //                vehicleList[i].GetComponent<Car>().carColor = Car.CarColor.Purple;
//    //                break;

//    //            case spawnColor.Red:
//    //                vehicleList[i].GetComponent<Car>().carColor = Car.CarColor.Red;
//    //                break;

//    //            case spawnColor.Yellow:
//    //                vehicleList[i].GetComponent<Car>().carColor = Car.CarColor.Yellow;
//    //                break;
//    //        }

//    //    }
//    //}

//    private void ShootRayCast()
//    {
//        if (spawnDirection == SpawnDirection.NORTH)
//        {
//            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.red);
//            if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, 0, 90)), 3, 8))
//            {
//                isSpawnPointClear = false;
//            }
//            else
//            {
//                isSpawnPointClear = true;
//            }
//        }
//        else if (spawnDirection == SpawnDirection.EAST)
//        {
//            Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.right) * 3, Color.red);
//            if (Physics.Raycast(this.transform.position, transform.TransformDirection(new Vector3(0, 0, 90)), 3))
//            {
//                isSpawnPointClear = false;
//            }
//            else
//            {
//                isSpawnPointClear = true;
//            }
//        }
//        else if (spawnDirection == SpawnDirection.SOUTH)
//        {
//            Debug.DrawRay(transform.position, -transform.TransformDirection(Vector3.forward) * 3, Color.red);
//            if (Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.forward), 3))
//            {
//                isSpawnPointClear = false;
//            }
//            else
//            {
//                isSpawnPointClear = true;
//            }
//        }
//        else if (spawnDirection == SpawnDirection.WEST)
//        {
//            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 3, Color.red);
//            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 3))
//            {
//                isSpawnPointClear = false;
//            }
//            else
//            {
//                isSpawnPointClear = true;
//            }
//        }
//    }
//}
