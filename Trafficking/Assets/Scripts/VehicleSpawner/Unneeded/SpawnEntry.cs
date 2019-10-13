using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnEntry
{
    //[SerializeField] VehicleType vehicleType;
    [SerializeField] GameObject vehicleType;
    [SerializeField] Vector3 spawnPoint;
    [SerializeField] float spawnTime;

    public GameObject GetVehicle()
    {
        return vehicleType;
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint;
    }
}
