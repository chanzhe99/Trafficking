using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    //public float spawnRate = 5;
    public GameObject spawnPoint;
    private VehiclePoolManager pool;
    private List<GameObject> vehicleList;

    private void Start()
    {
        pool = GetComponentInParent<VehiclePoolManager>();
        vehicleList = pool.pooledObjects;
        
        //StartCoroutine(Spawner());
    }

    //private IEnumerator Spawner()
    //{
    //    for (int i=0; i < vehicleList.Count; i++)
    //    {
    //        vehicleList[i].gameObject.transform.position = spawnPoint.transform.position;
    //        vehicleList[i].gameObject.SetActive(true);
    //        Debug.Log("Spawning vehicle from list: " + i);
    //        yield return new WaitForSeconds(spawnRate);
    //    }
    //}
}
