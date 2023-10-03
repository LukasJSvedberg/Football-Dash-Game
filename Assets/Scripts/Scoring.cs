using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    Player_Movement scoreCounter;
    [SerializeField] GameObject score;
    public TextMeshProUGUI scoreText;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    Deploy_Missile missileval;
    [SerializeField] GameObject val;
   
    private int gamesPlayed;
    private int totalScore;
    private int currentCoins;
    private bool onlyOnce;

    private void Start()
    {
        missileval = val.GetComponent<Deploy_Missile>();
        spawner = spawn.GetComponent<Spawner>();
        scoreCounter = score.GetComponent<Player_Movement>();

        onlyOnce = true;
        
    }
    void Update()
    {
        
        if (spawner.GameStart == false)
        {
            scoreText.enabled= false;
        }
        else
        {
            scoreText.enabled= true;
        }
        if (scoreCounter.stopper == false)
        {
            if (missileval.score > PlayerPrefs.GetInt("Highscore", 0))
            {
                scoreText.color = Color.green;
            }
            else
            {
                scoreText.color = Color.blue;
            }
            if (missileval.score > 0)
            { 
                scoreText.text = ("Score: " + missileval.score.ToString());
            }
            else
            {
                scoreText.text = ("Score: 0");
            }
            onlyOnce = true;
        }
        if (scoreCounter.stopper == true)
        {
  
            if (onlyOnce == true)
            {
                totalScore= PlayerPrefs.GetInt("TotalScore");
                currentCoins = PlayerPrefs.GetInt("Money");
                gamesPlayed = PlayerPrefs.GetInt("TotalGames") + 1;
                PlayerPrefs.SetInt("TotalGames", gamesPlayed);
                if (missileval.score > 0)
                {
                    PlayerPrefs.SetInt("TotalScore", totalScore + missileval.score);
                    PlayerPrefs.SetInt("Money", currentCoins + missileval.score);
                }
                onlyOnce = false;
            }
             
            
            if (missileval.score > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", missileval.score);
                scoreText.color = Color.green;
            }
            
        }
        
    }
}
