using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Countdown countdown;
    [SerializeField] EndScreen endScreen;
    [SerializeField] GameObject PauseMenu;

    public void Update()
    {
        checkCountdown();
        checkEndScreen();
        checkPauseMenu();
    }

    private void checkCountdown()
    {
        if(countdown.isStart == false)
        {
            Time.timeScale = 0.0f;
        }
        else if(countdown.isStart == true)
        {
            Time.timeScale = 1.0f;
        }
    }

    private void checkEndScreen()
    {
        if(endScreen.isGameOver == true && countdown.isStart == true)
        {
            AudioManager.instance.StopPlaying("Busy Street SFX");
            AudioManager.instance.StopPlaying("Traffic Jam SFX");
            PauseMenu.GetComponent<PauseMenu>().isPause = true;
            Time.timeScale = 0.0f;
        }
    }

    private void checkPauseMenu()
    {
        if(PauseMenu.GetComponent<PauseMenu>().isPause == true)
        {
            Time.timeScale = 0.0f;
            AudioManager.instance.Pause("Busy Street SFX");
            AudioManager.instance.Pause("Traffic Jam SFX");

        }
        else if(PauseMenu.GetComponent<PauseMenu>().isPause == false && countdown.isStart == true)
        {
            Time.timeScale = 1.0f;
        }
    }
}
