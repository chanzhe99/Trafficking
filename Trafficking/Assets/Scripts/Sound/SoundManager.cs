using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public static void PlaySound()
    {
        GameObject soundGameObject = new GameObject("Sound System");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        //audioSource.PlayOneShot
    }
}
