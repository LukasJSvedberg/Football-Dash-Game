using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Football_Script : MonoBehaviour
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
    public string actual_tag;
    void Start()
    {
        player_Movement = player.GetComponent<Player_Movement>();
        shop_Button_Script = shop.GetComponent<Shop_Button_Script>();
        actual_tag = PlayerPrefs.GetString("tag", "Not Bought");
    }

    // Update is called once per frame
    void Update()
    {
        if (shop_Button_Script.shopScreen == true)
        {
            football.tag = actual_tag;
        }
        else
        {
            football.tag = "Untagged";
        }
    }

    private void OnMouseDown()
    {
        player_Movement.spriteRenderer.sprite = newSprite;
        PlayerPrefs.SetString("tag", "Bought");

        actual_tag = PlayerPrefs.GetString("tag", "Not Bought");
        
        
    }
    private void OnMouseUp()
    {
    }
}
