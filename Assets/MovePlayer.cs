using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovePlayer : MonoBehaviour
{
    // Global variables
    public TextMeshPro vegetableText;   // indicator for food picked up
    public int playerNumber = 1;
    public float speed = 6.0f;
    public float timeRemaining = 120f;  // total time remaining in game
    
    private int score = 0;
    private string foodPicked = "";     // list of food picked up
    private bool choppingFood = false;  // true if at chopping board; false otherwise
    private string foodOnPlate = "";    // name of food placed on plate near board
    private float chopTimeLeft = 5f;    // total amount of time left to finish chopping items


    /** Start is called before the first frame update
     *  Clears text for indicator at start of game
     */
    void Start()
    {
        vegetableText.text = "";
    }

    /** Update is called once per frame
     *  Updates the positions of the players
     */
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