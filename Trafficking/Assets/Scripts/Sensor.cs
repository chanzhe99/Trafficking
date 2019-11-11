using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    [SerializeField] GameObject lanePatience;
    Image patienceColour;
    Car carScript;

    private void Start()
    {
        patienceColour = lanePatience.GetComponent<Image>();
    }

    void OnTriggerEnter(Collider col)
    {
        checkPatience(col);
    }

    private void checkPatience(Collider col)
    {
        if(col.gameObject.CompareTag("Car"))
        {

            if (col.gameObject.GetComponent<Car>().patience > 7)
            {
                patienceColour.color = Color.green;
                var patienceAlpha = patienceColour.color;
                patienceAlpha.a = 0.1f;
                patienceColour.color = patienceAlpha;
            }
            else if (col.gameObject.GetComponent<Car>().patience > 3 && col.gameObject.GetComponent<Car>().patience < 8)
            {
                print("Car Detected");
                patienceColour.color = Color.yellow;
                var patienceAlpha = patienceColour.color;
                patienceAlpha.a = 0.1f;
                patienceColour.color = patienceAlpha;
            }
            else if (col.gameObject.GetComponent<Car>().patience < 4)
            {
                patienceColour.color = Color.red;
                var patienceAlpha = patienceColour.color;
                patienceAlpha.a = 0.1f;
                patienceColour.color = patienceAlpha;
            }
        }
    }

    public void GetCarScript(Car car)
    {
        carScript = car;
    }
}
