using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class TrafficLightController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TrafficLight[] trafficLights;
    [SerializeField] private List<TrafficLightPhase> phase;

    private void Start()
    {
        SetAllRed();
        //AssignInfo();
    }

    private void AssignInfo()
    {
        foreach(TrafficLight lights in trafficLights)
        {
            phase.Add(new TrafficLightPhase());
        }
    }

    private void SetAllRed()
    {
        for (int i=0; i<trafficLights.Length; i++)
        {
            trafficLights[i].ChangeStop();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetAllRed();
        for (int i=0; i<phase.Count; i++)
        {
            // LEFT TURN
            if (phase[i].canGoLeft)
                trafficLights[i].canLeftTurn = true;
            else
                trafficLights[i].canLeftTurn = false;

            // RIGHT TURN
            if (phase[i].canGoRight)
                trafficLights[i].canRightTurn = true;
            else
                trafficLights[i].canRightTurn = false;

            // STRAIGHT
            if (phase[i].canGoStraight)
                trafficLights[i].canStraightTurn = true;
            else
                trafficLights[i].canStraightTurn = false;

            trafficLights[i].ChangeGo();
        }
    }
}

[System.Serializable]
public struct TrafficLightPhase
{
    public bool canGoLeft;
    public bool canGoRight;
    public bool canGoStraight;
}