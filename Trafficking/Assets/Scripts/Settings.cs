using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject MusicButtonOn;
    [SerializeField] GameObject SFXButtonOn;
    [SerializeField] GameObject MusicButtonOff;
    [SerializeField] GameObject SFXButtonOff;
    [SerializeField] GameObject Credits;

    [HideInInspector] public bool isMusicOn;
    [HideInInspector] public bool isSFXOn;

    private void Start()
    {
        isMusicOn = true;
        isSFXOn = true;
    }

    private void Update()
    {
        checkMusic();
        checkSFX();
    }

    public void OnMusic()
    {
        AudioManager.instance.OnVolume("Level BGM", 0.3f);
        AudioManager.instance.OnVolume("Main Menu BGM", 0.3f);

        AudioManager.instance.Play("Settings Button SFX");
        isMusicOn = true;
    }

    public void OffMusic()
    {
        AudioManager.instance.OffVolume("Level BGM", 0.0f);
        AudioManager.instance.OffVolume("Main Menu BGM", 0.0f);

        AudioManager.instance.Play("Settings Button SFX");
        isMusicOn = false;
    }

    public void OnSFX()
    {
        AudioManager.instance.OnVolume("Busy Street SFX", 0.5f);
        AudioManager.instance.OnVolume("Game Over SFX", 0.7f);
        AudioManager.instance.OnVolume("Honk SFX", 0.6f);
        AudioManager.instance.OnVolume("Menu Button SFX", 0.6f);
        AudioManager.instance.OnVolume("Settings Button SFX", 0.6f);
        AudioManager.instance.OnVolume("Star Stamp SFX", 0.6f);
        AudioManager.instance.OnVolume("Terminal Button SFX", 0.6f);
        AudioManager.instance.OnVolume("Traffic Jam SFX", 0.05f);
        AudioManager.instance.OnVolume("Victory SFX", 0.7f);
        AudioManager.instance.OnVolume("Points SFX", 0.5f);

        AudioManager.instance.Play("Settings Button SFX");
        isSFXOn = true;
    }

    public void OffSFX()
    {
        AudioManager.instance.OnVolume("Busy Street SFX", 0.0f);
        AudioManager.instance.OnVolume("Game Over SFX", 0.0f);
        AudioManager.instance.OnVolume("Honk SFX", 0.0f);
        AudioManager.instance.OnVolume("Menu Button SFX", 0.0f);
        AudioManager.instance.OnVolume("Settings Button SFX", 0.0f);
        AudioManager.instance.OnVolume("Star Stamp SFX", 0.0f);
        AudioManager.instance.OnVolume("Terminal Button SFX", 0.0f);
        AudioManager.instance.OnVolume("Traffic Jam SFX", 0.0f);
        AudioManager.instance.OnVolume("Victory SFX", 0.0f);
        AudioManager.instance.OnVolume("Points SFX", 0.0f);

        AudioManager.instance.Play("Settings Button SFX");
        isSFXOn = false;
    }

    public void checkMusic()
    {
        if(isMusicOn == true)
        {
            MusicButtonOn.SetActive(true);
            MusicButtonOff.SetActive(false);
        }
        else if(isMusicOn == false)
        {
            MusicButtonOff.SetActive(true);
            MusicButtonOn.SetActive(false);
        }
    }

    public void checkSFX()
    {
        if (isSFXOn == true)
        {
            SFXButtonOn.SetActive(true);
            SFXButtonOff.SetActive(false);
        }
        else if (isSFXOn == false)
        {
            SFXButtonOff.SetActive(true);
            SFXButtonOn.SetActive(false);
        }
    }

    public void openCredits()
    {
        Credits.SetActive(true);
    }

    public void closeCreddits()
    {
        Credits.SetActive(false);
    }
}
