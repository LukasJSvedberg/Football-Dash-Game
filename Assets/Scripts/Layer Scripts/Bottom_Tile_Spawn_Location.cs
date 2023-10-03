using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Tile_Spawn_Location : MonoBehaviour
{
    private Vector3 screenBounds;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        position = new Vector3(0, screenBounds.y / 10 * 9, 0);
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
