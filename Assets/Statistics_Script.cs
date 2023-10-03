using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Statistics_Script : MonoBehaviour
{
    // Start is called before the first frame update
    Stats_Button_Script stats_Button;
    [SerializeField] GameObject button;

    public TextMeshProUGUI text;
    private int gamesPlayed;
    private int totalScore;
    private int currentCoins;

    private Vector3 ObjectPos;
    
    void Start()
    {

        stats_Button = button.GetComponent<Stats_Button_Script>();
        ObjectPos = new Vector3(150, 400, 50);
        text.rectTransform.localPosition = ObjectPos;
        transform.position = ObjectPos;
        text.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (stats_Button.statScreen == true)
        {
            ObjectPos = new Vector3(0, 150, 200);
            text.rectTransform.localPosition = ObjectPos;
            text.gameObject.SetActive(true);
            text.text = "Statistics";
            totalScore = PlayerPrefs.GetInt("TotalScore");
            currentCoins = PlayerPrefs.GetInt("Money");
            gamesPlayed = PlayerPrefs.GetInt("TotalGames");
            text.text = "Total Score = " + totalScore + "<br>Number of games played = " + gamesPlayed;
        }
    }
}
