using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] private float levelTime;
    [HideInInspector] public float rTime;
    float t;
    string minutes, seconds;

    private void Start()
    {
        rTime = levelTime;
    }

    void Update()
    {
        t = levelTime - Time.timeSinceLevelLoad;
        rTime = levelTime - Time.timeSinceLevelLoad;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;
    }

    public float GetLevelTime()
    {
        return levelTime;
    }
}
