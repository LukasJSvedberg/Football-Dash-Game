using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    private Vector3 mousePos;

    Shop_Button_Script shop_Button;
    [SerializeField] GameObject S_button;

    private void Start()
    {
        shop_Button = S_button.GetComponent<Shop_Button_Script>();
        transform.position = mousePos;
        
        

    }
    private void Update()
    {
        if (shop_Button.shopScreen == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            mousePos = new Vector3(7, 9 + 1/2, 0);
            transform.position = mousePos;
            
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            mousePos = new Vector3(15, -6, -1000);
            transform.position = mousePos;
           

        }

    }
    // Start is called before the first frame update
}
