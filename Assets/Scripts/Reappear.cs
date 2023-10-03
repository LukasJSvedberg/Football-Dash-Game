using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reappear : MonoBehaviour
{
    Shop_Button_Script shop_Button;
    [SerializeField] GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        shop_Button = button.GetComponent<Shop_Button_Script>();
    }

    // Update is called once per frame
    void Update()
    {
       ;

        if (shop_Button.shopScreen == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
