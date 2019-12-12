using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PatienceUI : MonoBehaviour
{
    [SerializeField] Sprite boredSprite;
    [SerializeField] Sprite angrySprite;
    [SerializeField] TextMeshProUGUI scoreText;
    Image patienceImage;
    Car carScript;
    Color transparentColour;
    Color fillColour;

    private void Start()
    {
        patienceImage = this.GetComponent<Image>();
        fillColour = patienceImage.color;
        transparentColour = patienceImage.color;
        fillColour.a = 1f;
        transparentColour.a = 0f;

        patienceImage.color = transparentColour;
    }

    private void Update()
    {
        if(carScript.GetCarExit())
        {
            patienceImage.color = transparentColour;
            scoreText.text = ScoreManager.points.ToString("0");
        }
        else
        {
            if (carScript.patience > 7)
            {
                patienceImage.color = transparentColour;
            }
            else if (carScript.patience > 3 && carScript.patience < 8)
            {
                patienceImage.color = fillColour;
                patienceImage.sprite = boredSprite;
            }
            else if (carScript.patience < 4)
            {
                patienceImage.color = fillColour;
                patienceImage.sprite = angrySprite;
            }
        }
    }

    public void GetCarScript(Car car)
    {
        carScript = car;
    }
}
