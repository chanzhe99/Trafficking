using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] GameObject Countdown;
    [SerializeField] GameObject EndScreen;
    [SerializeField] GameObject PauseMenu;

    public void Update()
    {
        checkCountdown();
        checkEndScreen();
        checkPauseMenu();
    }

    private void checkCountdown()
    {
        if(Countdown.GetComponent<Countdown>().isStart == false)
        {
            Time.timeScale = 0.0f;
        }
        else if(Countdown.GetComponent<Countdown>().isStart == true)
        {
            Time.timeScale = 1.0f;
        }
    }

    private void checkEndScreen()
    {
        if(EndScreen.GetComponent<EndScreen>().isGameOver == true && Countdown.GetComponent<Countdown>().isStart == true)
        {
            PauseMenu.GetComponent<PauseMenu>().isPause = true;
            Time.timeScale = 0.0f;
        }
    }

    private void checkPauseMenu()
    {
        if(PauseMenu.GetComponent<PauseMenu>().isPause == true)
        {
            Time.timeScale = 0.0f;
        }
        else if(PauseMenu.GetComponent<PauseMenu>().isPause == false && Countdown.GetComponent<Countdown>().isStart == true)
        {
            Time.timeScale = 1.0f;
        }
    }
}
