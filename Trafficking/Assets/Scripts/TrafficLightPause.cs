using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightLive : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform straight;
    public Transform entrance;
    public Transform stop;
    public Transform left;
    public Transform right;
    public Transform tempDelayRight;
    [SerializeField] public bool Left;
    [SerializeField] public bool Straight;
    [SerializeField] public bool Right;
    [SerializeField] public bool Stop;

    private void Start()
    {
        ChangeStop();
    }

    [ContextMenu("LEFT")]
    void ChangeLeft()
    {
        Left = true;
        Straight = false;
        Right = false;
        Stop = false;
    }
    [ContextMenu("RIGHT")]
    void ChangeRight()
    {
        Right = true;
        Left = false;
        Straight = false;
        Stop = false;
    }
    [ContextMenu("STRAIGHT")]
    void ChangeStraight()
    {
        Straight = true;
        Stop = false;
        Left = false;
        Right = false;
    }
    [ContextMenu("STOP")]
    void ChangeStop()
    {
        Stop = true;
        Right = false;
        Straight = false;
        Left = false;
    }
}
