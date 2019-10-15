using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("POCTestingLevel");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
