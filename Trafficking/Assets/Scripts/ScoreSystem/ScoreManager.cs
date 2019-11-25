using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public int score;
    private float points, multiplier;

    private float score1Star, score2Star;
    [SerializeField] Image[] scoreStars;
    [SerializeField] int scoreMeterMax;
    [SerializeField] TMP_Text scoreText, /*pointsText,*/ multiplierText;
    [SerializeField] Slider scoreMeter;

    private bool hasImpatientCar;

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        scoreMeter.maxValue = scoreMeterMax;
        score2Star = scoreMeterMax * 2 / 3;
        score1Star = scoreMeterMax * 1 / 3;

        for (int i = 0; i < scoreStars.Length; i++)
        {
            scoreStars[i].enabled = false;
        }

        ResetScoreManager();
    }

    public void AddToScore()
    {
        points = 100 * multiplier;
        score += (int)points;
    }
    
    public void DeductScore()
    {
        score -= 100;
    }

    public void ResetScoreManager()
    {
        score = 0;
        multiplier = 0.0f;

        
    }

    public void AdjustMultiplier()
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

    public void ImpatientCarOnScreen()
    {
        hasImpatientCar = true;
    }

    public void ImpatientCarLeavesScreen()
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
        else if(score >= score2Star && score < scoreMeterMax)
        {
            scoreStars[0].enabled = true;
            scoreStars[1].enabled = true;
            scoreStars[2].enabled = false;
        }
        else if(score >= scoreMeterMax)
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

    public int GetScore()
    {
        return (int)score;
    }

    public int GetPoints()
    {
        return (int)points;
    }

    public float GetMultiplier()
    {
        return (float)multiplier;
    }
}
