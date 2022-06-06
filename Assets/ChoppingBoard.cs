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
    private string items;           // items on chopping board

    // Start is called before the first frame update
    void Start()
    {
        itemsList = new List<string>();
        items = "";
        updateBoardIndicator();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player.playerNumber != boardNumber)
                return;
            List<string> playerFoodList = player.getFoodList();

            if (itemsList.Count == 0 && playerFoodList.Count > 0)       // drop off food from player onto empty chopping board
            {
                itemsList.Add(playerFoodList[0]);
                items = player.getFood();
                player.removeFood();
            }
            else if (itemsList.Count < 3 && playerFoodList.Count > 0)   // drop off food from player onto partially filled chopping board
            {
                itemsList.Add(playerFoodList[0]);
                items += player.getFood();
                player.removeFood();
            } 
            else if (itemsList.Count > 0 && playerFoodList.Count == 0)  // pick up food from chopping board
            {
                player.addFood(itemsList[0]);
                itemsList.RemoveAt(0);
                items = "";
            }

            updateBoardIndicator();
        }
    }

    private void updateBoardIndicator()
    {
        itemsText.text = items;
    }
}
