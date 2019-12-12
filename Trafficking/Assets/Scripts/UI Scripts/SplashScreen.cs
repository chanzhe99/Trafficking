using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public CanvasGroup kduLogoCanvas;
    public CanvasGroup uowLogoCanvas;
    public CanvasGroup teamLogoCanvas;

    private void Start()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        for(float f = 0f; f < 1; f += Time.deltaTime)
        {
            kduLogoCanvas.alpha = f;
            yield return null;
        }
        kduLogoCanvas.alpha = 1;
        yield return new WaitForSeconds(1f);
        for (float f = 1f; f >= 0; f -= Time.deltaTime)
        {
            kduLogoCanvas.alpha = f;
            yield return null;
        }
        kduLogoCanvas.alpha = 0f;
        yield return new WaitForSeconds(1f);


        for(float f = 0f; f <= 1; f += Time.deltaTime)
        {
            uowLogoCanvas.alpha = f;
            yield return null;
        }
        uowLogoCanvas.alpha = 1;
        yield return new WaitForSeconds(1f);
        for (float f = 1f; f >= 0; f -= Time.deltaTime)
        {
            uowLogoCanvas.alpha = f;
            yield return null;
        }
        uowLogoCanvas.alpha = 0;
        yield return new WaitForSeconds(1f);
        
        for(float f = 0f; f <= 1; f += Time.deltaTime)
        {
            teamLogoCanvas.alpha = f;
            yield return null;
        }
        teamLogoCanvas.alpha = 1;
        yield return new WaitForSeconds(1f);
        for (float f = 1f; f >= 0; f -= Time.deltaTime)
        {
            teamLogoCanvas.alpha = f;
            yield return null;
        }
        teamLogoCanvas.alpha = 0;
        yield return new WaitForSeconds(1f);

        LoadTitle();
    }

    IEnumerator FadeInFadeOut(CanvasGroup canvas)
    {
        for (float f = 0f; f <= 1; f += Time.deltaTime)
        {
            canvas.alpha = f;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        //fade
        for (float f = 1f; f >= 0; f -= Time.deltaTime)
        {
            canvas.alpha = f;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        LoadTitle();
    }


    private void LoadTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }
}