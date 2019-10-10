using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficUI : MonoBehaviour
{
    [SerializeField] GameObject currentState;
    [SerializeField] GameObject changeState;

    [SerializeField] Image currentLight;
    [SerializeField] Image redLight;
    [SerializeField] Image greenLight;
    [SerializeField] Image leftLight;
    [SerializeField] Image rightLight;

    private void Start()
    {
        if (!currentState.activeSelf) currentState.SetActive(true);
        if (changeState.activeSelf) changeState.SetActive(false);
        currentLight.color = redLight.color;
        currentLight.sprite = redLight.sprite;
        currentLight.rectTransform.rotation = redLight.rectTransform.rotation;
    }

    public void OpenChangeStateUI()
    {
        currentState.SetActive(false);
        changeState.SetActive(true);
    }

    public void CloseChangeStateUI()
    {
        changeState.SetActive(false);
        currentState.SetActive(true);
    }

    public void ChangeStateRed()
    {
        currentLight.color = redLight.color;
        currentLight.sprite = redLight.sprite;
        currentLight.rectTransform.rotation = redLight.rectTransform.rotation;
    }

    public void ChangeStateGreen()
    {
        currentLight.color = greenLight.color;
        currentLight.sprite = greenLight.sprite;
        currentLight.rectTransform.rotation = greenLight.rectTransform.rotation;
    }

    public void ChangeStateLeft()
    {
        currentLight.color = leftLight.color;
        currentLight.sprite = leftLight.sprite;
        currentLight.rectTransform.rotation = leftLight.rectTransform.rotation;
    }

    public void ChangeStateRight()
    {
        currentLight.color = rightLight.color;
        currentLight.sprite = rightLight.sprite;
        currentLight.rectTransform.rotation = rightLight.rectTransform.rotation;
    }
}
