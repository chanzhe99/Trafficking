using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TrafficLightController : MonoBehaviour //, IPointerClickHandler
{
    public Image buttonImage;

    public bool isRed = true;
    public bool changingLights = false;
    public Sprite greenButton;
    public Sprite redButton;
    

    [SerializeField] private TrafficLight[] trafficLights;
    [SerializeField] private List<TrafficLightPhase> phase;

    [SerializeField] private TrafficLightController[] controllers;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
       // SetAllRed();
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
        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].isRed = true;
            controllers[i].buttonImage.sprite = controllers[i].redButton;
        }

        for (int i = 0; i < trafficLights.Length; i++)
        {
            trafficLights[i].ChangeStop();
            trafficLights[i].canRightTurn = false;
            trafficLights[i].canLeftTurn = false;
            trafficLights[i].canStraightTurn = false;
        }
    }

    public void ChangeLights()
    {
        SetAllRed();
        if (!changingLights)
        {
            for(int i =0; i< controllers.Length; i ++)
            {
                if(controllers[i].changingLights)
                {
                    return;
                }
            }
            changingLights = true;
            StartCoroutine(DelayLights());
        }
    }

    IEnumerator DelayLights()
    {
        buttonImage.color = Color.yellow;
        yield return new WaitForSeconds(1f);
        buttonImage.color = Color.white;
        buttonImage.sprite = greenButton;
        SetLightDir();
        changingLights = false;

    }

    private void SetLightDir()
    {
        buttonImage.sprite = greenButton;
        for (int i = 0; i < phase.Count; i++)
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

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    SetAllRed();
    //    for (int i=0; i<phase.Count; i++)
    //    {
    //        // LEFT TURN
    //        if (phase[i].canGoLeft)
    //            trafficLights[i].canLeftTurn = true;
    //        else
    //            trafficLights[i].canLeftTurn = false;

    //        // RIGHT TURN
    //        if (phase[i].canGoRight)
    //            trafficLights[i].canRightTurn = true;
    //        else
    //            trafficLights[i].canRightTurn = false;

    //        // STRAIGHT
    //        if (phase[i].canGoStraight)
    //            trafficLights[i].canStraightTurn = true;
    //        else
    //            trafficLights[i].canStraightTurn = false;

    //        trafficLights[i].ChangeGo();
    //    }
    //}
}

[System.Serializable]
public struct TrafficLightPhase
{
    public bool canGoLeft;
    public bool canGoRight;
    public bool canGoStraight;
}