using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Button_Script : MonoBehaviour
{
    private Vector3 mousePos;

    private BoxCollider2D box2d;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    Play_Again_Script Play_Again;
    [SerializeField] GameObject play;
    Player_Movement playerController;
    [SerializeField] GameObject player;
    Stats_Button_Script stats_Button;
    [SerializeField] GameObject button;
    All_Foots all_foots;
    [SerializeField] GameObject footballs;
    public bool shopScreen;
    public bool changer;
    Player_Money player_Money;
    [SerializeField] GameObject money;
    private void Start()
    {
        shopScreen = false;
        all_foots = footballs.GetComponent<All_Foots>();
        stats_Button = button.GetComponent<Stats_Button_Script>();
        playerController = player.GetComponent<Player_Movement>();
        Play_Again = play.GetComponent<Play_Again_Script>();
        spawner = spawn.GetComponent<Spawner>();
        mousePos = new Vector3(-15, -6, -1);
        transform.position = mousePos;
        changer = false;
        box2d = GetComponent<BoxCollider2D>();
        player_Money = money.GetComponent<Player_Money>();


    }
    private void Update()
    {
        if (spawner.GameStart == false && changer == false && stats_Button.statScreen == false)
        {
            box2d.enabled = true;
            mousePos = new Vector3(-15, -6, -1);
            transform.position = mousePos;
            changer = true;
        }

        if (spawner.GameStart == true || stats_Button.statScreen == true)
        {
            changer = false;
            mousePos = new Vector3(-15, -6, -1000);
            transform.position = mousePos;
            box2d.enabled = false;

        }
        if (shopScreen == true)
        {
            all_foots.gameObject.SetActive(true);
            player_Money.text.gameObject.SetActive(true);
        }
        else
        {
            all_foots.gameObject.SetActive(false);
            player_Money.text.gameObject.SetActive(false);
        }

    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {

        mousePos = new Vector3(-15, -6, -1000);
        transform.position = mousePos;
        box2d.enabled = false;
        shopScreen = true;

    }
}
