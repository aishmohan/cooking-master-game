using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bin : MonoBehaviour
{
    // Global variables
    public TextMeshProUGUI binText;
    public float timeToChop = 5f;   // amount of time needed to chop this food


    /** Detects collisions with other objects
     */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            player.addFood(binText.text);
        }
    }
}
