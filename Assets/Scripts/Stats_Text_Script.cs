using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Stats_Text_Script : MonoBehaviour
{
    public TextMeshProUGUI Player_Stats;
    Stats_Button_Script stats_Button;
    [SerializeField] GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        stats_Button = button.GetComponent<Stats_Button_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_Stats.text = ("High Score: " + PlayerPrefs.GetInt("Highscore", 1).ToString() + "<br>" + "Games played: " + PlayerPrefs.GetInt("TotalGames") + "<br>" + "Total Score: " + PlayerPrefs.GetInt("TotalScore"));

        if (stats_Button.statScreen == false)
        {
            Player_Stats.enabled = false;
        }
        else
        {
            Player_Stats.enabled = true;
        }
    }
}
