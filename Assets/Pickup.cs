using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player.playerNumber != int.Parse(name.Split("-")[1]))
                return;

            if (name.Split("-")[0] == "PickupTime")
            {
                ScoreManager.instance.addTime(player.playerNumber);
            }
            else if (name.Split("-")[0] == "PickupSpeed")
            {
                player.speedUpPlayer();
            }
            else if (name.Split("-")[0] == "PickupScore")
            {
                ScoreManager.instance.addPoints(player.playerNumber, true);
            }

            Destroy(gameObject);
        }
    }
}
