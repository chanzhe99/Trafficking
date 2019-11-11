using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject MusicButtonOn;
    [SerializeField] GameObject SFXButtonOn;
    [SerializeField] GameObject MusicButtonOff;
    [SerializeField] GameObject SFXButtonOff;

    public bool isMusicOn;
    public bool isSFXOn;

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
        isMusicOn = true;
    }

    public void OffMusic()
    {
        isMusicOn = false;
    }

    public void OnSFX()
    {
        isSFXOn = true;
    }

    public void OffSFX()
    {
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
}
