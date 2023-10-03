using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private LayerMask jumpablePlatform;
    Deploy_Missile missileval;
    [SerializeField] GameObject val;
    public Rigidbody2D rb2D;
    private CapsuleCollider2D box2D;
    public Vector3 PlayerStartingPos;
    private float JumpVel;
    public float moveVertical;
    private bool noJump;
    private bool downlooptrue;
    public int score;
    private float distance;
    Spawner spawner;
    [SerializeField] GameObject spawn;
    public bool stopper;
    Play_Again_Script Play_Again;
    [SerializeField] GameObject play;
    private float count;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private int current_money;


    // Start is called before the first frame update
    void Start()
    {
        count = 0f;
        spawner = spawn.GetComponent<Spawner>();
        missileval = val.GetComponent<Deploy_Missile>();
        rb2D = GetComponent<Rigidbody2D>();  
        box2D = GetComponent<CapsuleCollider2D>();
        Play_Again = play.GetComponent<Play_Again_Script>();
        JumpVel = 52f;
        noJump = true;          
        downlooptrue = false;
        stopper = false;
        PlayerStartingPos = new Vector3(0, 0, 0);
        transform.position = PlayerStartingPos;
        score = missileval.score;

        StartCoroutine(Turn());
        

    }

    // Update i s called once per frame
    
    private void Update()
    {
      
        if (Input.GetKeyDown("m"))
        {
            current_money = PlayerPrefs.GetInt("Money", 0);
            PlayerPrefs.SetInt("Money", current_money + 100);
        }
        if (spawner.GameStart == false || Play_Again.restart == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            rb2D.velocity = new Vector2(0, 0);
            PlayerStartingPos = new Vector3(0, 0, 0);
            transform.position = PlayerStartingPos;
            
        }
        else if (spawner.GameStart == true && Play_Again.restart == true)
        {
            
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            moveVertical = Input.GetAxisRaw("Vertical");
            if (downlooptrue == false)
            {
                if (moveVertical > 0.1 && IsGrounded() && noJump)
                {
                    
                    rb2D.AddForce(new Vector2(0, JumpVel), ForceMode2D.Impulse);
                    
                }
                else if (moveVertical < -0.1 && IsGrounded() && noJump && gameObject.transform.position.y > -4)
                {
                    
                    downlooptrue = true;
                    distance = (transform.position.y);
                }
                

                if (rb2D.velocity[1] > 0.1)
                {
                    box2D.isTrigger = true;
                }
                else
                {
                    box2D.isTrigger = false;
                }

                if (moveVertical > 0.1 || moveVertical < -0.1)
                {
                    noJump = false;
                }
                else
                {
                    noJump = true;
                }
            }
            else
            {
                if (distance > transform.position.y + 4 || stopper == true)
                {
                    box2D.isTrigger = false;
                    downlooptrue = false;
                }
                else
                {
                    box2D.isTrigger = true;
                }
            }
        }
        
       
        
        
    }
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(box2D.bounds.center, box2D.bounds.size, 0f, Vector2.down, .1f, jumpablePlatform);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            stopper = true;
           


        }
    }
    IEnumerator Turn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.002f * missileval.respawnTime);
            if (spawner.GameStart == true && Play_Again.restart == true)
            {

                count += 1f;
                transform.eulerAngles = new Vector3(0, 0, -count);
            }
        }
        
    }

}
   