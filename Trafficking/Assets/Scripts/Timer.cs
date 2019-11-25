﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] private float startTime = 60.0f;
    [HideInInspector] public float rTime;

    // Update is called once per frame
    void Update()
    {
        float t = startTime - Time.timeSinceLevelLoad;
        rTime = startTime - Time.timeSinceLevelLoad;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;
    }
}
