using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Background_Script : MonoBehaviour
{
    Stats_Button_Script stats_Button;
    [SerializeField] GameObject button;
    Shop_Button_Script shop_Button;
    [SerializeField] GameObject S_button;
  
    private Vector3 ObjectPos;

    // Start is called before the first frame update
    void Start()
    {
        stats_Button = button.GetComponent<Stats_Button_Script>();
        shop_Button = S_button.GetComponent<Shop_Button_Script>();
        ObjectPos = new Vector3(0, 0, 20);
        transform.position = ObjectPos;
        gameObject.GetComponent<SpriteRenderer>().enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stats_Button.statScreen == true || shop_Button.shopScreen == true)  
        {
            ObjectPos = new Vector3(0, 0, 1);
            transform.position = ObjectPos;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            ObjectPos = new Vector3(0, 0, 20);
            transform.position = ObjectPos;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
