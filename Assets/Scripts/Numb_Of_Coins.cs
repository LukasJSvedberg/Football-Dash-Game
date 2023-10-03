using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Numb_Of_Coins : MonoBehaviour
{

    Shop_Button_Script shop_Button;
    [SerializeField] GameObject S_button;
    public TextMeshProUGUI Coin_Number;
    private void Start()
    {
        shop_Button = S_button.GetComponent<Shop_Button_Script>();
        Coin_Number.enabled = false;



    }
    private void Update()
    {
        if (shop_Button.shopScreen == true)
        {
            Coin_Number.enabled= true;
        }

        else
        {
            Coin_Number.enabled= false;
        }
        Coin_Number.text = (PlayerPrefs.GetInt("Money").ToString());

    }
    // Start is called before the first frame update
}