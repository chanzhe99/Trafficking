using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficUI : MonoBehaviour
{
    [SerializeField] Image currentLight;
    [SerializeField] TrafficLight trafficLightScript;

    private void Start()
    {
        currentLight.color = Color.red;
    }

    public void ChangeState()
    {
        currentLight.color = (currentLight.color == Color.red) ? Color.green : Color.red;

        if (currentLight.color == Color.green)
        {
            trafficLightScript.ChangeGo();
        }
        else
        {
            trafficLightScript.ChangeStop();
        }
    }

    public void GetTrafficLightScript(TrafficLight lightScript)
    {
        trafficLightScript = lightScript;
    }
}
