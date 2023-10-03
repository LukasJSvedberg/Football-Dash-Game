using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Button : MonoBehaviour
{
    private Vector3 mousePos;
    public bool Button_Pressed;
    private BoxCollider2D box2d;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    Play_Again_Script Play_Again;
    [SerializeField] GameObject play;
    Player_Movement playerController;
    [SerializeField] GameObject player;
    Stats_Button_Script stats_Button;
    [SerializeField] GameObject button;
    Shop_Button_Script shop_Button;
    [SerializeField] GameObject S_button;

    private void Start()
    {
        shop_Button = S_button.GetComponent<Shop_Button_Script>();
        stats_Button = button.GetComponent<Stats_Button_Script>();
        playerController = player.GetComponent<Player_Movement>();
        Play_Again = play.GetComponent<Play_Again_Script>();
        spawner = spawn.GetComponent<Spawner>();
        mousePos = new Vector3(0, -6, -1);
        transform.position = mousePos;
        Button_Pressed = false;
        box2d = GetComponent<BoxCollider2D>();
         
    }
    private void Update()
    {
        if (spawner.GameStart == false && stats_Button.statScreen == false && shop_Button.shopScreen == false) 
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            mousePos = new Vector3(0, -6, -1);
            transform.position = mousePos;
            box2d.enabled= true;
            
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            mousePos = new Vector3(0, -9, -1000);
            transform.position = mousePos;
            box2d.enabled = false;
        }
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Button_Pressed = true;
        playerController.PlayerStartingPos = new Vector3(0, 0, 0);
        playerController.transform.position = playerController.PlayerStartingPos;
        box2d.enabled = false;
        playerController.stopper = false;

    }
}
