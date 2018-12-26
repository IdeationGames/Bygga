using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalInfo : MonoBehaviour
{
    private static int gameScore = 0;
	private static int totalScore = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /*
    void updateGameScore(int addAmount)
    {
        gameScore += addAmount;
    }
    */

    public static void gameScoreFromDistance(float distance)
    {
        if (distance < 1.0f)
        {
            float reverse = 100 * (1.0f - distance);
            gameScore += (int) reverse;
        }
        else if (distance > 1.0f && distance < 2.0f)
        {
            gameScore += 5;
        }
    }

    public static int getGameScore()
    {
        return gameScore;
    }

	public static int getTotalScore()
	{
		return totalScore;
	}

	public static void resetGameScore()
	{
		gameScore = 0;
	}

	public static void resetTotalScore()
	{
		totalScore = 0;
	}

	public static void countScoreAndReset()
	{
		totalScore += gameScore;
		resetGameScore();
	}
}
