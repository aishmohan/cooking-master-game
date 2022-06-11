using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Global variables
    public TextMeshPro vegetableText;   // indicator for food picked up
    public int playerNumber = 1;
    public float speed = 6.0f;
    public float timeRemaining = 120f;  // total time remaining in game
    
    private int score = 0;
    private List<string> foods;         // list of food currently picked up
    private bool choppingFood = false;  // true if at chopping board; false otherwise
    private float chopTimeLeft = 5f;    // total amount of time left to finish chopping items


    /** Start is called before the first frame update
     *  Clears text for indicator at start of game
     */
    void Start()
    {
        foods = new List<string>();
        updatePlayerIndicator();
    }

    /** Update is called once per frame
     *  Updates the positions of the players
     */
    void Update()
    {
        if (choppingFood && chopTimeLeft > 0)       // prevent player from moving when chopping and count down time
        {
            chopTimeLeft -= Time.deltaTime;
        }
        else if (choppingFood && chopTimeLeft <= 0) // allow player to start moving again once finished chopping
        {
            choppingFood = false;
            chopTimeLeft = 5f;
        }
        else if (!choppingFood)                     // move the player accoding to input
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

    public void startChopping()
    {
        choppingFood = true;
    }

    public void addFood(string item)
    {
        if (foods.Count < 2)
        {
            foods.Add(item);
        }

        updatePlayerIndicator();
    }

    public void addAllFood(List<string> allFood)
    {
        foods.AddRange(allFood);
        updatePlayerIndicator();
    }

    public List<string> getFood()
    {
        return foods;
    }

    public void removeFood()
    {
        foods.RemoveAt(0);
        updatePlayerIndicator();
    }

    public void removeAllFood()
    {
        foods.Clear();
        updatePlayerIndicator();
    }

    private void updatePlayerIndicator()
    {
        string foodPickedUp = "";
        for (int index = 0; index < foods.Count; index++)
        {
            foodPickedUp += foods[index];   // add all the food the player is carrying

            if (index != foods.Count - 1)
                foodPickedUp += " ; ";
        }

        vegetableText.text = foodPickedUp;  // update the display text for the indicator
    }
}