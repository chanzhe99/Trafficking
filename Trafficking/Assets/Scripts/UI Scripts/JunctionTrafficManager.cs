using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunctionTrafficManager : MonoBehaviour
{
    [SerializeField] List<SpawnTrafficUI> trafficLights = new List<SpawnTrafficUI>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            trafficLights.Add(child.GetComponent<SpawnTrafficUI>());
        }
    }
}
