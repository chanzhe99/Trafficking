using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject endScreenUI;
    [SerializeField] Timer timerUI;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject Win;

    public bool isGameOver = false;

    private void Update()
    {
        if (ScoreManager.instance.score < 0.0f)
        {
            isGameOver = true;
            endScreenUI.SetActive(true);
            Lose.SetActive(true);
        }
        else if (timerUI.rTime <= 0.0f)
        {
            if (ScoreManager.instance.score >= 0.0f)
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
        ScoreManager.instance.score = 0;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreManager.instance.score = 0;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Score.Instance.meter = 100f;
    }
}
