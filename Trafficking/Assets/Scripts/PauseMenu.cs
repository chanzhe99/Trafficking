using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;

    public void OpenPauseMenu()
    {
        PauseMenuUI.SetActive(true);
        if(Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
        }
    }

    public void OpenSettings()
    {

    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Back()
    {
        PauseMenuUI.SetActive(false);
        if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
        }
    }
}
