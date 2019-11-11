
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnRate { Low, Med, High};
public struct Timeline
{
    public int Seconds;
    public SpawnRate ratePrio;
    public float slowRate;
    public float medRate;
    public float fastRate;
}

public class SpawnSystem : MonoBehaviour
{
    List<SpawnSystemUnit> fast;
    List<SpawnSystemUnit> slow;
    List<SpawnSystemUnit> medium;
    [SerializeField]float minLow, maxLow, minMed, maxMed, minHigh, maxHigh = 0f;
    
    [SerializeField] List<Timeline> Event;
    Timeline curTime;
    float startTime;
    Coroutine spawning;
    float junc1, junc2, junc3;
    
    // colors are for the exits/entrances, not the Car's colors themselves
    //public enum spawnColor { Red, Green, Blue, Orange, Yellow, Purple }; 
    public TrafficLight spawnTraffic;

    private void Awake()
    {
        fast = new List<SpawnSystemUnit>();
        medium = new List<SpawnSystemUnit>();
        slow = new List<SpawnSystemUnit>();
    }

    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        SpawnCars();
    }

    void SpawnCars()
    {
        if(Time.time - startTime <curTime.Seconds)
        {
            if(curTime.ratePrio == SpawnRate.Low)
            {
                if (spawning == null) StartCoroutine(SpawnVehicle(Random.Range(minLow, maxLow)));
            }
            else if(curTime.ratePrio == SpawnRate.Med)
            {
                if (spawning == null) StartCoroutine(SpawnVehicle(Random.Range(minMed, maxMed)));
            }
            else if (curTime.ratePrio == SpawnRate.High)
            {
                if (spawning == null) StartCoroutine(SpawnVehicle(Random.Range(minHigh, maxHigh)));
            }
        }
    }

    Car.CarColor CheckTargetJunc()
    {
        float rand = Random.Range(0.0f, 1.0f);
        if (rand >= 0 && rand < junc1)
        {
            return Car.CarColor.Green;
        }
        else if (rand >= junc1 && rand < junc2)
        {
            return Car.CarColor.Yellow;
        }
        else if(rand>= junc2 && rand <=1.0)
        {
            return Car.CarColor.Blue;
        }
        return Car.CarColor.Green;
    }

    IEnumerator SpawnVehicle(float sec)
    {
        Debug.Log("RunningIEnumerator");

        yield return new WaitForSeconds(sec);
        float rand = Random.Range(0.0f, 1.0f);
        if(rand < curTime.slowRate && rand >= 0)
        {
            for(int i=0; i < slow.Count; i++)
            {
                if(!slow[i].car.activeInHierarchy)
                {
                    slow[i].car.SetActive(true);
                    slow[i].car.transform.position = spawnTraffic.transform.position;
                    slow[i].car.transform.rotation = spawnTraffic.transform.rotation;
                    slow[i].carScript.curTraffic = spawnTraffic;                   
                    slow[i].carScript.carColor = CheckTargetJunc();
                    yield return null;
                }
            }
            PoolingSystem.Instance.SpawnSlow();
            slow[slow.Count-1].car.SetActive(true);
            slow[slow.Count-1].car.transform.position = spawnTraffic.transform.position;
            slow[slow.Count - 1].car.transform.rotation = spawnTraffic.transform.rotation;
            slow[slow.Count - 1].carScript.curTraffic = spawnTraffic;
            slow[slow.Count - 1].carScript.carColor = CheckTargetJunc();
            yield return null;
        }
        else if (rand >= curTime.slowRate && rand < curTime.medRate)
        {
            for (int i = 0; i < medium.Count; i++)
            {
                if (!medium[i].car.activeInHierarchy)
                {
                    medium[i].car.SetActive(true);
                    medium[i].car.transform.position = spawnTraffic.transform.position;
                    medium[i].car.transform.rotation = spawnTraffic.transform.rotation;
                    medium[i].carScript.curTraffic = spawnTraffic;
                    medium[i].carScript.carColor = CheckTargetJunc();
                    yield return null;
                }
            }
            PoolingSystem.Instance.SpawnMed();
            medium[medium.Count - 1].car.SetActive(true);
            medium[medium.Count - 1].car.transform.position = spawnTraffic.transform.position;
            medium[medium.Count - 1].car.transform.rotation = spawnTraffic.transform.rotation;
            medium[medium.Count - 1].carScript.curTraffic = spawnTraffic;
            medium[medium.Count - 1].carScript.carColor = CheckTargetJunc();
            yield return null;
        }
        else if (rand>=curTime.medRate && rand <= 1)
        {
            for (int i = 0; i < fast.Count; i++)
            {
                if (!fast[i].car.activeInHierarchy)
                {
                    fast[i].car.SetActive(true);
                    fast[i].car.transform.position = spawnTraffic.transform.position;
                    fast[i].car.transform.rotation = spawnTraffic.transform.rotation;
                    fast[i].carScript.curTraffic = spawnTraffic;
                    fast[i].carScript.carColor = CheckTargetJunc();
                    yield return null;
                }
            }
            PoolingSystem.Instance.SpawnFast();
            fast[fast.Count - 1].car.SetActive(true);
            fast[fast.Count - 1].car.transform.position = spawnTraffic.transform.position;
            fast[fast.Count - 1].car.transform.rotation = spawnTraffic.transform.rotation;
            fast[fast.Count - 1].carScript.curTraffic = spawnTraffic;
            fast[fast.Count - 1].carScript.carColor = CheckTargetJunc();
            yield return null;
        }
    }

    public void AddToSlow(SpawnSystemUnit vehicle)
    {
        slow.Add(vehicle);
    }

    public void AddToMed(SpawnSystemUnit vehicle)
    {
        medium.Add(vehicle);
    }
    public void AddToFast(SpawnSystemUnit vehicle)
    {
        fast.Add(vehicle);
    } 
}