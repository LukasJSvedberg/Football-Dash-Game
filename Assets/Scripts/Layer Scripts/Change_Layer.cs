using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Profiling;
using UnityEngine;

public class Change_Layer : MonoBehaviour
{
    Player_Movement playerController;
    [SerializeField] GameObject player;
    Spawner spawner;
    [SerializeField] GameObject spawn;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.layer = 6;
        spawner = spawn.GetComponent<Spawner>();


    }
    void Awake()
    {
        playerController = player.GetComponent<Player_Movement>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (true)
        {
            if (spawner.GameStart == false || playerController.stopper == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (playerController.rb2D == enabled)
            {
                if (playerController.rb2D.velocity[1] > 0.1)
                {
                    gameObject.layer = 0;
                }
                else
                {
                    gameObject.layer = 6;
                }
            }
        }

        
    }
}
