using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour {
    
    static int score;
    	
    public static int GetHighscore()
    {
        return score;
    }
	
    public static bool SetScore(int newScore)
    {
        if (newScore > score)
        {
            score = newScore;
            return true;
        }
        return false;
    }
}
