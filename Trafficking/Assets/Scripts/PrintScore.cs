using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        scoreText.text = Score.Instance.meter.ToString();
    }
}
