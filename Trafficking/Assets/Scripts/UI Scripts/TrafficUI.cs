using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficUI : MonoBehaviour
{
    [SerializeField] Image currentLight;

    private void Start()
    {
        currentLight.color = Color.red;
    }

    public void ChangeState()
    {
        currentLight.color = (currentLight.color == Color.red) ? Color.green : Color.red;
    }
}
