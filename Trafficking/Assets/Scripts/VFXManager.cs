using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] GameObject VFX1;
    [SerializeField] GameObject VFX1a1;
    [SerializeField] GameObject VFX1a2;
    [SerializeField] GameObject VFX2;
    [SerializeField] GameObject VFX2a1;
    [SerializeField] GameObject VFX2a2;
    [SerializeField] GameObject VFX3;
    [SerializeField] GameObject VFX3a1;
    [SerializeField] GameObject VFX3a2;

    [SerializeField] GameObject Pattern1;
    [SerializeField] GameObject Pattern2;
    [SerializeField] GameObject Pattern3;

    TrafficLightController buttonColor1;
    TrafficLightController buttonColor2;
    TrafficLightController buttonColor3;

    MeshRenderer patternColor1;

    private void Start()
    {
        buttonColor1 = Pattern1.GetComponent<TrafficLightController>();
        buttonColor2 = Pattern2.GetComponent<TrafficLightController>();
        buttonColor3 = Pattern3.GetComponent<TrafficLightController>();
    }

    void Update()
    {
        checkPattern();
    }

    private void checkPattern()
    {
        if(buttonColor1.changingLights == true)
        {
            VFX1.SetActive(true);
            VFX2.SetActive(false);
            VFX3.SetActive(false);

            StartCoroutine(DelaySwitch());
        }
        else if(buttonColor2.changingLights == true)
        {
            VFX1.SetActive(false);
            VFX2.SetActive(true);
            VFX3.SetActive(false);

            StartCoroutine(DelaySwitch());
        }
        else if (buttonColor3.changingLights == true)
        {
            VFX1.SetActive(false);
            VFX2.SetActive(false);
            VFX3.SetActive(true);

            StartCoroutine(DelaySwitch());
        }
    }

    IEnumerator DelaySwitch()
    {
        VFX1a1.GetComponent<MeshRenderer>().material.color = new Color(255f, 255f, 0f);
        VFX1a2.GetComponent<MeshRenderer>().material.color = new Color(255f, 255f, 0f);
        VFX2a1.GetComponent<MeshRenderer>().material.color = new Color(255f, 255f, 0f);
        VFX2a2.GetComponent<MeshRenderer>().material.color = new Color(255f, 255f, 0f);
        VFX3a1.GetComponent<MeshRenderer>().material.color = new Color(255f, 255f, 0f);
        VFX3a2.GetComponent<MeshRenderer>().material.color = new Color(255f, 255f, 0f);
        yield return new WaitForSeconds(1f);
        VFX1a1.GetComponent<MeshRenderer>().material.color = new Color(0f, 255f, 0f);
        VFX1a2.GetComponent<MeshRenderer>().material.color = new Color(0f, 255f, 0f);
        VFX2a1.GetComponent<MeshRenderer>().material.color = new Color(0f, 255f, 0f);
        VFX2a2.GetComponent<MeshRenderer>().material.color = new Color(0f, 255f, 0f);
        VFX3a1.GetComponent<MeshRenderer>().material.color = new Color(0f, 255f, 0f);
        VFX3a2.GetComponent<MeshRenderer>().material.color = new Color(0f, 255f, 0f);
    }
}
