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
        PauseMenuUI.SetActive(true);
        isPause = true;
    }

    public void OpenSettings()
    {

    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score.Instance.meter = 100f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Score.Instance.meter = 100f;
    }

    public void Back()
    {
        PauseMenuUI.SetActive(false);
        isPause = false;
    }
}
