using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    public bool GameStart;
    private Vector3 tempPos;
    Start_Button Start_Pressed;
    [SerializeField] GameObject pressed;
    Play_Again_Script Play_Again;
    [SerializeField] GameObject play;
    // Start is called before the first frame update
    void Start()
    {
        Play_Again = play.GetComponent<Play_Again_Script>();
        Start_Pressed = pressed.GetComponent<Start_Button>();
        GameStart = false;
        tempPos = new Vector3(0, -2, 10);
        transform.position = tempPos;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart == false)
        {
            tempPos = new Vector3(0, -2, 10);
            transform.position = tempPos;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Start_Pressed.Button_Pressed == true && GameStart == false)
        {
            GameStart= true;
            tempPos = new Vector3(0, 0, -1000);
            transform.position = tempPos;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
