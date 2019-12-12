using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSound : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.instance.Play("Game Over SFX");
    }
}
