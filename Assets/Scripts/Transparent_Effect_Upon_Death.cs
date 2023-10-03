using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent_Effect_Upon_Death : MonoBehaviour
{
    Player_Movement playerController;
    [SerializeField] GameObject player;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    [SerializeField] BoxCollider2D box2D;
    public GameObject background;
    private Vector3 ObjectPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
        spawner = spawn.GetComponent<Spawner>();
        playerController = player.GetComponent<Player_Movement>();
        ObjectPos = new Vector3(0, 0, 20);
        transform.position = ObjectPos;
        box2D = GetComponent<BoxCollider2D>();
        box2D.enabled = false;
        background.layer = 0;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerController.stopper == true && spawner.GameStart == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            ObjectPos = new Vector3(0, 0, 1);
            transform.position = ObjectPos;
            background.layer = (0);
            box2D.enabled = true;
            
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            ObjectPos = new Vector3(-1, 0, 20);
            transform.position = ObjectPos;
            background.layer = (6);
            box2D.enabled = false;
        }
        
    }
}
