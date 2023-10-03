using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Play_Again_Script : MonoBehaviour
{
    Player_Movement playerController;
    [SerializeField] GameObject player;
    private Vector3 ObjectPos;
    public bool restart;
    private BoxCollider2D box2d;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    Deploy_Missile missileval;
    [SerializeField] GameObject val;
    Moving_Missile moving_Missile;
    [SerializeField] GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        moving_Missile = missile.GetComponent<Moving_Missile>();
        missileval = val.GetComponent<Deploy_Missile>();
        spawner = spawn.GetComponent<Spawner>();
        playerController = player.GetComponent<Player_Movement>();
        box2d = GetComponent<BoxCollider2D>();
        box2d.enabled = false;
        ObjectPos = new Vector3(0, 0, 20);
        transform.position = ObjectPos;
        restart = false;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (spawner.GameStart == false) 
        {
       
        ObjectPos = new Vector3(0, 0, 20);
        transform.position = ObjectPos;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
            
        }
        else if (playerController.stopper == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            ObjectPos = new Vector3(0, 0, -10);
            transform.position = ObjectPos;
            box2d.enabled = true;
            restart= false;
        }
        else 
        {
            restart= true;
            playerController.stopper = false;
            box2d.enabled = false;
        }
        



    }
    private void OnMouseDown()
    { 
        playerController.PlayerStartingPos = new Vector3(0, 0, 0);
        playerController.transform.position = playerController.PlayerStartingPos;
        box2d.enabled = false;
        ObjectPos = new Vector3(0, 0, 20);
        transform.position = ObjectPos;
        restart = true;
        playerController.stopper = false;
         


       
    }
}