using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] static public int score;
    [HideInInspector] static public float points = 0;
    [HideInInspector] static public float multiplier;

    private float score1Star, score2Star;
    [SerializeField] Image[] scoreStars;
    [SerializeField] float score3Star;
    [SerializeField] TMP_Text multiplierText, scoreText/*pointsText,*/ ;
    [SerializeField] Slider scoreMeter;

    static bool hasImpatientCar;

    private void Start()
    {
        scoreMeter.maxValue = score3Star;
        score2Star = score3Star * 2 / 3;
        score1Star = score3Star * 1 / 3;

        for (int i = 0; i < scoreStars.Length; i++)
        {
            scoreStars[i].enabled = false;
        }

        ResetScoreManager();
    }

    static public void AddToScore()
    {
        points = 100 * multiplier;
        score += (int)points;
    }
    
    static public void DeductScore()
    {
        score -= 100;
    }

    public void ResetScoreManager()
    {
        score = 0;
        multiplier = 1.0f;
    }

    static public void AdjustMultiplier()
    {
        if (!hasImpatientCar)
        {
            multiplier += 0.1f;
        }
        else if (hasImpatientCar)
        {
            multiplier = 1.0f;
        }
    }

    static public void ImpatientCarOnScreen()
    {
        hasImpatientCar = true;
    }

    static public void ImpatientCarLeavesScreen()
    {
        hasImpatientCar = false;
    }

    private void Update()
    {
        scoreText.text = score.ToString("000,000");
        //pointsText.text = points.ToString("0f");
        multiplierText.text = multiplier.ToString("0.0x");

        scoreMeter.value = score;
        if(score >= score1Star && score < score2Star)
        {
            scoreStars[0].enabled = true;
            scoreStars[1].enabled = false;
            scoreStars[2].enabled = false;
        }
        else if(score >= score2Star && score < score3Star)
        {
            scoreStars[0].enabled = true;
            scoreStars[1].enabled = true;
            scoreStars[2].enabled = false;
        }
        else if(score >= score3Star)
        {
            scoreStars[0].enabled = true;
            scoreStars[1].enabled = true;
            scoreStars[2].enabled = true;
        }
        else
        {
            scoreStars[0].enabled = false;
            scoreStars[1].enabled = false;
            scoreStars[2].enabled = false;
        }
    }

    static int GetScore()
    {
        return (int)score;
    }

    public static int GetPoints()
    {
        return (int)points;
    }

    static float GetMultiplier()
    {
        return (float)multiplier;
    }
}
