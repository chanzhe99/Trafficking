using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLights : MonoBehaviour
{
    public GameObject turnSignalLeft;
    public GameObject turnSignalRight;

    //public bool rightSignalON = false;
    //public bool leftSignalON = false;

    private void Start()
    {
        turnSignalRight.SetActive(false);
        turnSignalLeft.SetActive(false);
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    rightSignalON = true;
        //    leftSignalON = false;
        //    turnSignalRight.SetActive(true);
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    rightSignalON = false;
        //    leftSignalON = true;
        //    turnSignalLeft.SetActive(true);
        //}
        //else
        //{
        //    turnSignalRight.SetActive(false);
        //    turnSignalLeft.SetActive(false);
        //    rightSignalON = false;
        //    leftSignalON = false;
        //}
    }
    
    [ContextMenu("Left Signal")]
    public void leftSignal()
    {
        turnSignalLeft.SetActive(true);
        turnSignalRight.SetActive(false);
    }

    [ContextMenu("Right Signal")]
    public void rightSignal()
    {
        turnSignalLeft.SetActive(false);
        turnSignalRight.SetActive(true);
    }

    [ContextMenu("No Signal")]
    public void noSignal()
    {
        turnSignalLeft.SetActive(false);
        turnSignalRight.SetActive(false);
    }
}
