using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTrafficUI : MonoBehaviour
{
    [SerializeField] GameObject trafficUIPrefab;
    Canvas trafficUICanvas;
    GameObject trafficUI;

    private void Start()
    {
        trafficUI = Instantiate(trafficUIPrefab, trafficUICanvas.transform);
    }

    private void Update()
    {
        trafficUI.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0f, 0f, 0f));
    }
}
