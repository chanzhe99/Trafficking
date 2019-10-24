using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatienceUI : MonoBehaviour
{
    [SerializeField] GameObject patienceUIPrefab;
    Canvas patienceUICanvas;
    GameObject patienceUI;

    private void Start()
    {
        patienceUICanvas = FindObjectOfType<Canvas>();
        patienceUI = Instantiate(patienceUIPrefab, patienceUICanvas.transform);
        patienceUI.GetComponent<PatienceUI>().GetCarScript(this.GetComponent<Car>());
    }

    private void Update()
    {
        patienceUI.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0f, 0f, 0f));
    }
}
