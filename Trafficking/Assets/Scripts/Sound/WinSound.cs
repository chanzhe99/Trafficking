using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSound : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.instance.Play("Victory SFX");
    }
}
