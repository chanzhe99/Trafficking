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
        if (ScoreManager.score < 0.0f)
        {
            isGameOver = true;
            AudioManager.instance.Play("Game Over SFX");
            endScreenUI.SetActive(true);
            Lose.SetActive(true);
        }
        else if (timerUI.rTime <= 0.0f)
        {
            if (ScoreManager.score >= 0.0f)
            {
                isGameOver = true;
                AudioManager.instance.Play("Victory SFX");
                endScreenUI.SetActive(true);
                Win.SetActive(true);
            }
        }
    }

    public void Retry()
    {
        AudioManager.instance.Play("Menu Button SFX");
        AudioManager.instance.StopPlaying("Level BGM");
        AudioManager.instance.Play("Level BGM");
        AudioManager.instance.StopPlaying("Busy Street SFX");
        AudioManager.instance.Play("Busy Street SFX");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager.score = 0;
    }

    public void LoadNextLevel()
    {
        AudioManager.instance.Play("Menu Button SFX");
        AudioManager.instance.StopPlaying("Level BGM");
        AudioManager.instance.Play("Level BGM");
        AudioManager.instance.StopPlaying("Busy Street SFX");
        AudioManager.instance.Play("Busy Street SFX");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreManager.score = 0;
    }

    public void ReturnToMainMenu()
    {
        AudioManager.instance.Play("Menu Button SFX");
        AudioManager.instance.StopPlaying("Level BGM");
        AudioManager.instance.Play("Main Menu BGM");
        SceneManager.LoadScene("MainMenu");
        Score.Instance.meter = 100f;
    }
}
