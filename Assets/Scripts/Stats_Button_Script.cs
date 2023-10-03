using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Button_Script : MonoBehaviour
{ 
    private Vector3 mousePos;
    
    private BoxCollider2D box2d;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    Play_Again_Script Play_Again;
    [SerializeField] GameObject play;
    Player_Movement playerController;
    [SerializeField] GameObject player;
    Shop_Button_Script shop_Button;
    [SerializeField] GameObject S_button;
    Statistics_Script statistics_Script;
    [SerializeField] GameObject stats_script;

    Player_Money player_Money;
    [SerializeField] GameObject money;


    public bool statScreen;
    public bool changer;
    private void Start()
    {
         
        shop_Button = S_button.GetComponent<Shop_Button_Script>(); 
        statScreen = false;
        playerController = player.GetComponent<Player_Movement>();
        statistics_Script = stats_script.GetComponent<Statistics_Script>();
        Play_Again = play.GetComponent<Play_Again_Script>();
        spawner = spawn.GetComponent<Spawner>();
        mousePos = new Vector3(15, -6, -1);
        transform.position = mousePos;
        changer = false;
        box2d = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        if (spawner.GameStart == false && changer== false && shop_Button.shopScreen == false)
        {
            box2d.enabled = true;
            mousePos = new Vector3(15, -6, -1);
            transform.position = mousePos;
            changer = true;
        }

        if (spawner.GameStart == true || shop_Button.shopScreen == true)
        {
            changer = false;
            mousePos = new Vector3(15, -6, -1000);
            transform.position = mousePos;
            box2d.enabled = false;

        }
        
        
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        
        mousePos = new Vector3(15, -6, -1000);
        transform.position = mousePos;
        box2d.enabled = false;
        statScreen = true;
        statistics_Script.text.gameObject.SetActive(true);
        player_Money.text.gameObject.SetActive(true);
        

    }
}