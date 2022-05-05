using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    // Global variables
    public float speed = 6.0f;
    public int playerNumber = 1;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position; // get the position of the player

        if ((Input.GetKey("w") && playerNumber == 1) || (Input.GetKey(KeyCode.UpArrow) && playerNumber == 2))
        {
            pos.y += speed * Time.deltaTime;
        }
        if ((Input.GetKey("s") && playerNumber == 1) || (Input.GetKey(KeyCode.DownArrow) && playerNumber == 2))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if ((Input.GetKey("d") && playerNumber == 1) || (Input.GetKey(KeyCode.RightArrow) && playerNumber == 2))
        {
            pos.x += speed * Time.deltaTime;
        }
        if ((Input.GetKey("a") && playerNumber == 1) || (Input.GetKey(KeyCode.LeftArrow) && playerNumber == 2))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;   // update the position of the player
    }
}
