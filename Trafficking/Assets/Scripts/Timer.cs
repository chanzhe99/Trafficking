using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    private float startTime;
    public float rTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float t = startTime - Time.timeSinceLevelLoad;
        rTime = startTime - Time.timeSinceLevelLoad;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = minutes + ":" + seconds;
    }
}
