using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Customer : MonoBehaviour
{
    // Global variables
    public TextMeshPro orderText;
    public Slider timerSlider;

    private List<string> order;
    private float timeRemaining; 
    private bool isAngry;


    // Start is called before the first frame update
    void Start()
    {
        order = generateOrder();
        timeRemaining = 30f * order.Count;
        isAngry = false;

        timerSlider.maxValue = timeRemaining;
        timerSlider.value = timeRemaining;
        updateOrderIndicator();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timerSlider.value = timeRemaining;

        if (timeRemaining <= 0)
        {
            Destroy(gameObject);
            ScoreManager.instance.deductPoints(1, false);
            ScoreManager.instance.deductPoints(2, false);
        }
    }

    private List<string> generateOrder()
    {
        List<string> newOrder = new List<string>();
        string[] choices = {"T", "C", "B", "S", "R", "O"};

        for (int index = 0; index < Random.Range(1,3); index++)
        {
            int randChoice;
            do
            {
                randChoice = Random.Range(0, choices.Length);
            }
            while (newOrder.Contains(choices[randChoice]));

            newOrder.Add(choices[randChoice]);
        }

        return newOrder;
    }

    private void updateOrderIndicator()
    {
        string orderStr = "";
        for (int index = 0; index < order.Count; index++)
        {
            orderStr += order[index];

            if (index != order.Count - 1)
                orderStr += ",";
        }

        orderText.text = orderStr;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            List<string> playerFoodList = player.getFood();
            bool comboMatches = true;

            if (playerFoodList.Count != order.Count)        // combination does not match order
                comboMatches = false;

            for (int index = 0; index < playerFoodList.Count; index++)
            {
                if (playerFoodList[index] != order[index])
                    comboMatches = false;
            }

            if (comboMatches)                               // combination matches order
            {
                Destroy(gameObject);
                ScoreManager.instance.addPoints(player.playerNumber, false);
                player.removeAllFood();
            }
        }
    }
}