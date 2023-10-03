using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class You_Died_Script : MonoBehaviour
{
    Player_Movement playerController;
    [SerializeField] GameObject player;
    private Vector3 ObjectPos;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    

    // Start is called before the first frame update
    void Start()
    {
        spawner = spawn.GetComponent<Spawner>();
        
        playerController = player.GetComponent<Player_Movement>();
        ObjectPos = new Vector3(0, 0, 20);
        transform.position = ObjectPos;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.stopper == true && spawner.GameStart == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            ObjectPos = new Vector3(0, 6, 0);
            transform.position = ObjectPos;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            ObjectPos = new Vector3(0, 0, 20);
            transform.position = ObjectPos;
        }

    }
}
