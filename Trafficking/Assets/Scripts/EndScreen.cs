using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject endScreenUI;
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject Win;

    public bool isGameOver = false;

    private void Update()
    {
        checkSatisfaction(); 
    }

    private void checkSatisfaction()
    {
        if(Score.Instance.meter <= 0.0f)
        {
            isGameOver = true;
            endScreenUI.SetActive(true);
            Lose.SetActive(true);
        }
        else if (Timer.GetComponent<Timer>().rTime <= 0)
        {
            if (Score.Instance.meter >= 0.0f)
            {
                isGameOver = true;
                endScreenUI.SetActive(true);
                Win.SetActive(true);
            } 
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score.Instance.meter = 100f;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Score.Instance.meter = 100f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Score.Instance.meter = 100f;
    }
}
