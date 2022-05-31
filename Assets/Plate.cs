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

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player.playerNumber != plateNumber)
                return;
            List<string> foodList = player.getFoodList();

            if (foodList.Count == 1 && item == "")
            {
                item = player.getFood();
                player.removeFood();
            }

            updatePlateIndicator();
        }
    }

    private void updatePlateIndicator()
    {
        itemText.text = item;
    }
}
