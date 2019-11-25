using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] private float startTime;
    [HideInInspector] public float rTime;
    float t;
    string minutes, seconds;

    private void Start()
    {
        rTime = startTime;
    }

    void Update()
    {
        t = startTime - Time.timeSinceLevelLoad;
        rTime = startTime - Time.timeSinceLevelLoad;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;
    }
}
