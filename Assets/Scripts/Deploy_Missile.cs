using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deploy_Missile : MonoBehaviour
{
    public GameObject missilePrefab;
    public float respawnTime;
    private Vector3 screenBounds;
    private float missile_speed;
    Player_Movement missileController;
    [SerializeField] GameObject missile;
    public int score;
    public float div_missile_speed;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    Player_Movement playerController;
    [SerializeField] GameObject player;
    public bool counter;
    Play_Again_Script Play_Again;
    [SerializeField] GameObject play;



    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<Player_Movement>();
        counter = false;
        spawner = spawn.GetComponent<Spawner>();
        missile_speed = 20f;
        respawnTime = 1f;
        score = -2;
        missileController = missile.GetComponent<Player_Movement>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Play_Again = play.GetComponent<Play_Again_Script>();

    }

    private void Update()
    {
       
        if (playerController.stopper == true) 
        {
            missile_speed = 20f;
            respawnTime= 1f;
            div_missile_speed = 20f;
            


        }
        if (spawner.GameStart == true && counter == false)
        {
            
            StartCoroutine(missileWave());
            counter = true;
            
        }
        if (playerController.stopper && counter == true) 
        {
            StopAllCoroutines();
            score = -2;
            counter = false;
        }
       
    }


    private void spawnMissile()
    {
        
        {
            
            GameObject a = Instantiate(missilePrefab) as GameObject;
            
            a.transform.position = new Vector3(screenBounds.x * 5 / 4, -(1) / 2 + (Random.Range(-1, 2) * 6), 1  );
            if (missile_speed < 40)
            {
                missile_speed += 0.4f;
                div_missile_speed = (Mathf.Round(missile_speed));
            }
           
            a.GetComponent<Moving_Missile>().speed = missile_speed;
            
            
        }
        
    }

    IEnumerator missileWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            

            if (missileController.rb2D == enabled)
            {
                score += 1;
                if (respawnTime > 0.4f)
                {
                    respawnTime -= 0.01f;
                }
            }

            spawnMissile();
           
        }
        
    }

    
}
