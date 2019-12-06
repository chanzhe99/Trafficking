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
        AudioManager.instance.Play("Menu Button SFX");
        SettingsPanelUI.SetActive(true);
    }

    public void CloseSettings()
    {
        AudioManager.instance.Play("Menu Button SFX");
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
        AudioManager.instance.Play("Menu Button SFX");
        SceneManager.LoadScene("LevelSelectMenu");
    }

    public void QuitGame()
    {
        AudioManager.instance.Play("Menu Button SFX");
        Debug.Log("Quit");
        Application.Quit();
    }
}
