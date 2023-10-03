using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Moving_Background : MonoBehaviour
{
    Deploy_Missile backgroundSpeed;
    private float length, startPos;
    public float parallaxEffect;
    private float count;
    public GameObject cam;

    [SerializeField] GameObject backSpeed;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    Player_Movement playerController;
    [SerializeField] GameObject player;

    private void Start()
    {

        spawner = spawn.GetComponent<Spawner>();
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        count = 0f;
        backgroundSpeed = backSpeed.GetComponent <Deploy_Missile>();
        playerController = player.GetComponent<Player_Movement>();

    }

    private void FixedUpdate()
    {
        {
            if (spawner.GameStart == false)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }


            if (playerController.stopper == false)
            {
                count += backgroundSpeed.div_missile_speed / 20;



                transform.position = new Vector3(((startPos + -(parallaxEffect) * count / 100)), transform.position.y, transform.position.z);


                if (transform.position.x < startPos - length)
                {
                    count = 0f;
                    transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
                }
            }
            else
            {
                count = 0f;
            }
        }
    


    }

}
