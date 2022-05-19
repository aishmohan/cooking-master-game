using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoppingBoard : MonoBehaviour
{
    // Global variables
    public TextMeshPro itemsText;   // indicator for items on chopping board

    private List<string> itemsList; // list of items on chopping board
    private string items;           // items on chopping board

    // Start is called before the first frame update
    void Start()
    {
        itemsList = new List<string>();
        items = "";
        updateBoardIndicator();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            List<string> foodList = player.getFoodList();

            if (itemsList.Count == 0 && foodList.Count > 0)
            {
                itemsList.Add(foodList[0]);
                items = player.getFood();
                player.removeFood();
            }
            else if (itemsList.Count < 3 && foodList.Count > 0)
            {
                itemsList.Add(foodList[0]);
                items += player.getFood();
                player.removeFood();
            }

            updateBoardIndicator();
        }
    }

    private void updateBoardIndicator()
    {
        itemsText.text = items;
    }
}
