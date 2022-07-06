using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoppingBoard : MonoBehaviour
{
    // Global variables
    public TextMeshPro itemsText;   // indicator for items on chopping board
    public int boardNumber;

    private List<string> itemsList; // list of items on chopping board


    // Start is called before the first frame update
    void Start()
    {
        itemsList = new List<string>();
        updateBoardIndicator();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player.playerNumber != boardNumber)
                return;
            List<string> playerFoodList = player.getFood();

            if (itemsList.Count == 0 && playerFoodList.Count > 0)       // drop off a food from player onto empty chopping board
            {
                itemsList.Add(playerFoodList[0]);
                player.removeFood();
                player.startChopping();
            }
            else if (itemsList.Count < 3 && playerFoodList.Count > 0)   // drop off a food from player onto partially filled chopping board
            {
                itemsList.Add(playerFoodList[0]);
                player.removeFood();
                player.startChopping();
            } 
            else if (itemsList.Count > 0 && playerFoodList.Count == 0)  // pick up food from chopping board
            {
                player.addAllFood(itemsList);
                itemsList.Clear();
            }

            updateBoardIndicator();
        }
    }

    private void updateBoardIndicator()
    {
        string foodOnBoard = "";
        for (int index = 0; index < itemsList.Count; index++)
        {
            foodOnBoard += itemsList[index];   // add all the food the board has

            if (index != itemsList.Count - 1)
                foodOnBoard += ",";
        }

        itemsText.text = foodOnBoard;
    }
}