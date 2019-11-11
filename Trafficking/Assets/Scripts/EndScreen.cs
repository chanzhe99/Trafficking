using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject endScreenUI;

    private void Update()
    {
        checkSatisfaction();
    }

    private void checkSatisfaction()
    {
        if(Score.Instance.meter <= 0.0f)
        {
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;
            }
            Score.Instance.meter = 0.0f;
            endScreenUI.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("POCTestingLevel");
    }
}
