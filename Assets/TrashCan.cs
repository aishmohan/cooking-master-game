using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            
            if (player.getFood().Count > 0)
            {
                player.removeAllFood();
                ScoreManager.instance.deductPoints(player.playerNumber);
            }
        }
    }
}
