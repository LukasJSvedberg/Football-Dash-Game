using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Football_Script_5 : MonoBehaviour
{
    // Start is called before the first frame update
    Player_Movement player_Movement;
    [SerializeField] GameObject player;
    [SerializeField] GameObject football;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public BoxCollider2D box2D;
    Shop_Button_Script shop_Button_Script;
    [SerializeField] GameObject shop;
    public Sprite boughtSprite;
    public string actual_tag;
    private int current_money;
    Player_Money player_Money;
    [SerializeField] GameObject money;
    [SerializeField] GameObject associated_text;

    void Start()
    {
        player_Movement = player.GetComponent<Player_Movement>();
        player_Money = money.GetComponent<Player_Money>();
        shop_Button_Script = shop.GetComponent<Shop_Button_Script>();
        actual_tag = PlayerPrefs.GetString("tag_gold", "Not Bought");
    }

    // Update is called once per frame
    void Update()
    {
        if (shop_Button_Script.shopScreen == true)
        {
            football.tag = actual_tag;
            if (actual_tag == "Bought")
            {
                spriteRenderer.sprite = boughtSprite;
                associated_text.SetActive(false);
            }
        }
        else
        {
            football.tag = "Untagged";
        }
    }

    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("Money", 0) >= 1000 && football.tag == ("Not Bought")) 
        {
            print("Bought ball" + (PlayerPrefs.GetInt("Money", 0)).ToString());
            player_Movement.spriteRenderer.sprite = newSprite;
            current_money = PlayerPrefs.GetInt("Money", 0);
            PlayerPrefs.SetInt("Money", current_money - 1000);
            PlayerPrefs.SetString("tag_gold", "Bought");

            actual_tag = PlayerPrefs.GetString("tag_gold", "Not Bought");
        }
        else if (football.tag == ("Bought"))
        {
            player_Movement.spriteRenderer.sprite = newSprite;
            
        }
        else
        {
            print("Not enough money");
        }


    }
    private void OnMouseUp()
    {
    }
}