using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PatienceUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI patience;
    Image patienceColour;
    Car carScript;

    private void Start()
    {
        patienceColour = this.GetComponent<Image>();
    }

    private void Update()
    {
        if(carScript.patience > 7)
        {
            patienceColour.color = Color.green;
        }
        else if(carScript.patience > 3 && carScript.patience < 8)
        {
            patienceColour.color = Color.yellow;
        }
        else if(carScript.patience < 4)
        {
            patienceColour.color = Color.red;
        }

        patience.text = carScript.patience.ToString();
    }

    public void GetCarScript(Car car)
    {
        carScript = car;
    }
}
