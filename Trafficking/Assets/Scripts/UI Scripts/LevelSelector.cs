using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] GameObject Level1;
    [SerializeField] GameObject Level2;
    [SerializeField] GameObject Level3;
    [SerializeField] GameObject Level4;
    [SerializeField] GameObject Level5;
    [SerializeField] GameObject LevelPanel;

    public void Select1()
    {
        AudioManager.instance.Play("Menu Button SFX");
        Level1.transform.localScale = new Vector3(2, 1, 1);
        Level2.transform.localScale = new Vector3(1, 1, 1);
        Level3.transform.localScale = new Vector3(1, 1, 1);
        Level4.transform.localScale = new Vector3(1, 1, 1);
        Level5.transform.localScale = new Vector3(1, 1, 1);
        LevelPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void Select2()
    {
        AudioManager.instance.Play("Menu Button SFX");
        Level1.transform.localScale = new Vector3(1, 1, 1);
        Level2.transform.localScale = new Vector3(2, 1, 1);
        Level3.transform.localScale = new Vector3(1, 1, 1);
        Level4.transform.localScale = new Vector3(1, 1, 1);
        Level5.transform.localScale = new Vector3(1, 1, 1);
        LevelPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void Select3()
    {
        AudioManager.instance.Play("Menu Button SFX");
        Level1.transform.localScale = new Vector3(1, 1, 1);
        Level2.transform.localScale = new Vector3(1, 1, 1);
        Level3.transform.localScale = new Vector3(2, 1, 1);
        Level4.transform.localScale = new Vector3(1, 1, 1);
        Level5.transform.localScale = new Vector3(1, 1, 1);
        LevelPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void Select4()
    {
        AudioManager.instance.Play("Menu Button SFX");
        Level1.transform.localScale = new Vector3(1, 1, 1);
        Level2.transform.localScale = new Vector3(1, 1, 1);
        Level3.transform.localScale = new Vector3(1, 1, 1);
        Level4.transform.localScale = new Vector3(2, 1, 1);
        Level5.transform.localScale = new Vector3(1, 1, 1);
        LevelPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void Select5()
    {
        AudioManager.instance.Play("Menu Button SFX");
        Level1.transform.localScale = new Vector3(1, 1, 1);
        Level2.transform.localScale = new Vector3(1, 1, 1);
        Level3.transform.localScale = new Vector3(1, 1, 1);
        Level4.transform.localScale = new Vector3(1, 1, 1);
        Level5.transform.localScale = new Vector3(2, 1, 1);
        LevelPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void LoadLevel1()
    {
        PlayLevelBGM();
        SceneManager.LoadScene("VSLevel1");
    }

    public void LoadLevel2()
    {
        PlayLevelBGM();
        SceneManager.LoadScene("VSLevel2");
    }

    public void LoadLevel3()
    {
        PlayLevelBGM();
        SceneManager.LoadScene("VSLevel3");
    }

    public void Back()
    {
        AudioManager.instance.Play("Menu Button SFX");
        SceneManager.LoadScene("MainMenu");
    }

    private void PlayLevelBGM()
    {
        AudioManager.instance.StopPlaying("Main Menu BGM");
        AudioManager.instance.Play("Level BGM");
        AudioManager.instance.Play("Busy Street SFX");
    }
}
