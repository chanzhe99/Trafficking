using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanelUI;
    public GameObject MainMenuUI;

    public void OpenSettings()
    {
        SettingsPanelUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanelUI.SetActive(false);
    }

    public void OpenMainMenu()
    {
        MainMenuUI.SetActive(true);
    }

    public void CloseMainMenu()
    {
        MainMenuUI.SetActive(false);
    }

    //public enum Scene
    //{
        
    //}

    //public static void LoadMenu(Scene scene)
    //{
    //    SceneManager.LoadScene(scene.ToString());
    //}

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelectMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
