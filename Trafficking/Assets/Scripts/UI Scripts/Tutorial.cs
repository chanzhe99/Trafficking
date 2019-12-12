using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> Page;
    public int currentPanel = 1;

    public void ActivateTutorial()
    {
        currentPanel = 1;
        AudioManager.instance.Play("Menu Button SFX");
        Page[1].SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.Play("Menu Button SFX");
        if (currentPanel < Page.Count)
        {
            Page[currentPanel].SetActive(false);
            Page[currentPanel + 1].SetActive(true);
            currentPanel++;
        }
        else if (currentPanel >= 5)
        {
            Page[currentPanel].SetActive(false);
        }
    }
}
