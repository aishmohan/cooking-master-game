using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plate : MonoBehaviour
{
    // Global variables
    public TextMeshPro itemText;
    public int plateNumber;

    private string item;


    // Start is called before the first frame update
    void Start()
    {
        item = "";
        updatePlateIndicator();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player.playerNumber != plateNumber)
                return;
            List<string> playerFoodList = player.getFood();

            if (playerFoodList.Count == 1 && item == "")        // drop off a food from player onto plate
            {
                item = player.getFood()[0];
                player.removeFood();
            }
            else if (playerFoodList.Count == 0 && item != "")   // pick up food from plate
            {
                player.addFood(item);
                item = "";
            }

            updatePlateIndicator();
        }
    }

    private void updatePlateIndicator()
    {
        itemText.text = item;
    }
}