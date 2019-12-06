using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    public bool isPause;

    public void OpenPauseMenu()
    {
        AudioManager.instance.Play("Menu Button SFX");
        if (PoolingSystem.Instance.activeCarNumbers <= 17)
            AudioManager.instance.Pause("Busy Street SFX");
        else
            AudioManager.instance.Pause("Traffic Jam SFX");
        PauseMenuUI.SetActive(true);
        isPause = true;
    }

    public void OpenSettings()
    {
        AudioManager.instance.Play("Menu Button SFX");
    }

    public void ReloadLevel()
    {
        AudioManager.instance.Play("Menu Button SFX");
        AudioManager.instance.StopPlaying("Level BGM");
        AudioManager.instance.Play("Level BGM");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score.Instance.meter = 100f;
    }

    public void ReturnToMainMenu()
    {
        AudioManager.instance.Play("Menu Button SFX");
        AudioManager.instance.StopPlaying("Level BGM");
        AudioManager.instance.Play("Main Menu BGM");
        SceneManager.LoadScene("MainMenu");
        //Score.Instance.meter = 100f;
    }

    public void Back()
    {
        AudioManager.instance.Play("Menu Button SFX");
        if (PoolingSystem.Instance.activeCarNumbers <= 17)
            AudioManager.instance.Unpause("Busy Street SFX");
        else
            AudioManager.instance.Unpause("Traffic Jam SFX");
        AudioManager.instance.Unpause("Busy Street SFX");
        PauseMenuUI.SetActive(false);
        isPause = false;
    }
}
