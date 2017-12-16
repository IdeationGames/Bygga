using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo : MonoBehaviour
{
    private static int gameScore = 0;

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

        Debug.Log(gameScore);
    }

    public static int getGameScore()
    {
        return gameScore;
    }
}
