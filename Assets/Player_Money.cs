using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Money : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    Football_Script football_Script_1;
    [SerializeField] GameObject football_1;
    Football_Script football_Script_2;
    [SerializeField] GameObject football_2;
    Football_Script football_Script_3;
    [SerializeField] GameObject football_3;
    Football_Script football_Script_4;
    [SerializeField] GameObject football_4;
    Football_Script football_Script_5;
    [SerializeField] GameObject football_5;
    Football_Script football_Script_6;
    [SerializeField] GameObject football_6;
    private int currentCoins;


    void Start()
    {
        football_Script_1 = football_1.GetComponent<Football_Script>();
        football_Script_2 = football_2.GetComponent<Football_Script>();
        football_Script_3 = football_3.GetComponent<Football_Script>();
        football_Script_4 = football_4.GetComponent<Football_Script>();
        football_Script_5 = football_5.GetComponent<Football_Script>();
        football_Script_6 = football_6.GetComponent<Football_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PlayerPrefs.GetInt("Money").ToString();
        currentCoins = PlayerPrefs.GetInt("Money");

    }
}
