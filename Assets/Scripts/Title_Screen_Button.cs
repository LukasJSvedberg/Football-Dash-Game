using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Screen_Button : MonoBehaviour
{ 
    Player_Movement playerController;
    [SerializeField] GameObject player;
    private Vector3 ObjectPos;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    private BoxCollider2D box2d;
    Start_Button Start_Pressed;
    [SerializeField] GameObject pressed;
    Deploy_Missile missileval;
    [SerializeField] GameObject val;
    Stats_Button_Script stats_Button;
    [SerializeField] GameObject button;
    Shop_Button_Script shop_Button;
    [SerializeField] GameObject S_button;
    Statistics_Script statistics_Script;
    [SerializeField] GameObject stats_script;
    // Start is called before the first frame update
    void Start()
    {
        statistics_Script = stats_script.GetComponent<Statistics_Script>();
        shop_Button = S_button.GetComponent<Shop_Button_Script>();
        stats_Button = button.GetComponent<Stats_Button_Script>();
        Start_Pressed = pressed.GetComponent<Start_Button>();
        box2d = GetComponent<BoxCollider2D>();
        spawner = spawn.GetComponent<Spawner>();
        playerController = player.GetComponent<Player_Movement>();
        missileval = val.GetComponent<Deploy_Missile>();
        ObjectPos = new Vector3(0, 0, 20);
        transform.position = ObjectPos;
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerController.stopper == true && spawner.GameStart == true) || stats_Button.statScreen == true || shop_Button.shopScreen == true)
        {
            ObjectPos = new Vector3(0, -6, -10);
            transform.position = ObjectPos;
            box2d.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            ObjectPos = new Vector3(0, 0, 20);
            transform.position = ObjectPos;
            box2d.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    private void OnMouseDown()
    {
        spawner.GameStart = false;
        Start_Pressed.Button_Pressed = false;
        missileval.score = -2;
        stats_Button.statScreen = false;
        stats_Button.changer = false;
        shop_Button.shopScreen= false;
        shop_Button.changer = false;
        statistics_Script.gameObject.SetActive(false);

    }
}
