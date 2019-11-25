using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private float points;
    private float multiplier;

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
        ResetScoreManager();
    }

    public void AddToScore()
    {
        points = 100 * multiplier;
        score += (int)points;
    }

    public int GetScore()
    {
        return (int)score;
    }

    public int GetPoints()
    {
        return (int)points;
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
}
