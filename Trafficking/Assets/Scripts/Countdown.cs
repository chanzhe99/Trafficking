using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TMP_Text countdownText;
    [SerializeField] GameObject counterdownTimer;
    [SerializeField] GameObject level;
    [SerializeField] GameObject satisfactionMeter;
    [SerializeField] GameObject timer;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 3.0f;
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        startTime -= (0.75f / 120);
        float t = startTime;

        if(t > 0)
        {
            string seconds = (t % 60).ToString("f0");
            countdownText.text = seconds;
        }
        else if( t <= 0)
        {
            counterdownTimer.SetActive(false);
            Time.timeScale = 1f;
            level.SetActive(true);
            satisfactionMeter.SetActive(true);
            timer.SetActive(true);
        }

    }
}
