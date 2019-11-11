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
        SceneManager.LoadScene("VSLevel1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("VSLevel2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("VSLevel3");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
