using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenuUI;

    private void Update()
    {
        checkResolution();
    }

    private void checkResolution()
    {
        if (Screen.width == 1280 && Screen.height == 800)
        {
            MainMenuUI.GetComponent<AspectRatioFitter>().aspectRatio = 1.6f;
        }
        else if(Screen.width == 1024 && Screen.height == 600)
        {
            MainMenuUI.GetComponent<AspectRatioFitter>().aspectRatio = 1.71f;
        }
        else if(Screen.width == 972 && Screen.height == 486)
        {
            MainMenuUI.GetComponent<AspectRatioFitter>().aspectRatio = 2f;
        }
        else if(Screen.width == 864 && Screen.height == 486)
        {
            MainMenuUI.GetComponent<AspectRatioFitter>().aspectRatio = 1.78f;
        }
        else if(Screen.width == 2048 && Screen.height == 1536)
        {
            MainMenuUI.GetComponent<AspectRatioFitter>().aspectRatio = 1.34f;
        }
    }
}
