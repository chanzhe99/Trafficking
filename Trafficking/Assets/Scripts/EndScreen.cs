using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject endScreenUI;
    [SerializeField] Timer timerUI;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject Win;
    [SerializeField] GameObject scoreManager;
    [SerializeField] TMP_Text pScore;
    [SerializeField] GameObject Star1;
    [SerializeField] GameObject Star2;
    [SerializeField] GameObject Star3;

    [HideInInspector] public bool isGameOver = false;

    private void Update()
    {
        if (ScoreManager.score < 0.0f)
        {
            isGameOver = true;
            endScreenUI.SetActive(true);
            Lose.SetActive(true);
            pScore.text = scoreManager.GetComponent<ScoreManager>().finalPoints.ToString("000,000");
        }
        else if (timerUI.rTime <= 0.0f)
        {
            if (ScoreManager.score >= 0.0f)
            {
                if(scoreManager.GetComponent<ScoreManager>().is1Star == false)
                {
                    isGameOver = true;
                    endScreenUI.SetActive(true);
                    Lose.SetActive(true);
                    pScore.text = scoreManager.GetComponent<ScoreManager>().finalPoints.ToString("000,000");
                }
                else if(scoreManager.GetComponent<ScoreManager>().is3Star == true)
                {
                    isGameOver = true;
                    endScreenUI.SetActive(true);
                    Win.SetActive(true);
                    Star1.SetActive(true);
                    Star2.SetActive(true);
                    Star3.SetActive(true);
                    pScore.text = scoreManager.GetComponent<ScoreManager>().finalPoints.ToString("000,000");
                }
                else if(scoreManager.GetComponent<ScoreManager>().is2Star == true)
                {
                    isGameOver = true;
                    endScreenUI.SetActive(true);
                    Win.SetActive(true);
                    Star1.SetActive(true);
                    Star2.SetActive(true);
                    pScore.text = scoreManager.GetComponent<ScoreManager>().finalPoints.ToString("000,000");
                }
                else if(scoreManager.GetComponent<ScoreManager>().is1Star == true)
                {
                    isGameOver = true;
                    endScreenUI.SetActive(true);
                    Win.SetActive(true);
                    Star1.SetActive(true);
                    pScore.text = scoreManager.GetComponent<ScoreManager>().finalPoints.ToString("000,000");
                }
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
