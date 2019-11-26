using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightLighting : MonoBehaviour
{
    [SerializeField] Timer levelTimer;

    private Light dayLight;
    private float startTime = 0f;
    private float endTime = 0f;
    private Color startColor;
    [SerializeField]private Color endColor;
    private Quaternion startRot;
    private Quaternion endRot;

    private void Start()
    {
        startTime = 0f;
        endTime = levelTimer.GetLevelTime();
        dayLight = GetComponent<Light>();
        startColor = Color.white;
        //endColor = new Color(1f, 0.901960784f, 0.62745098f);
        startRot = Quaternion.Euler(70f, 330f, 0f);
        endRot = Quaternion.Euler(152f, 330f, 0f);
        StartCoroutine(StartCycle());
    }

    private IEnumerator StartCycle()
    {
        
        while ((startTime / endTime) < 1)
        {
            
            float fracComplete = startTime / endTime;
            Debug.Log("running " + fracComplete);
            transform.rotation = Quaternion.Lerp(startRot, endRot, fracComplete);
            dayLight.color = Color.Lerp(startColor, endColor, fracComplete);
           
            startTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
