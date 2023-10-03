using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Missile : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed;
    private Vector2 screenBounds;
    public int missiles_dodged;
    public Vector3 teleport;
    
    
    


    // Start is called before the first frame update
    void Start()
    {

        missiles_dodged = 0;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < -screenBounds.x*1.5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 6)
        {
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
