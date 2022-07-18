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
    public Transform pickupTimeObj;
    public Transform pickupSpeedObj;
    public Transform pickupScoreObj;

    private List<string> order;
    private float timeRemaining; 
    private bool isAngry;
    private List<int> wrongMeals;

    // Start is called before the first frame update
    void Start()
    {
        order = generateOrder();
        timeRemaining = 30f * order.Count;
        isAngry = false;
        wrongMeals = new List<int>();

        timerSlider.maxValue = timeRemaining;
        timerSlider.value = timeRemaining;
        updateOrderIndicator();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= (isAngry ? Time.deltaTime * 1.7f : Time.deltaTime);
        timerSlider.value = timeRemaining;

        if (timeRemaining <= 0)
        {
            Destroy(gameObject);

            if (!isAngry)   // customer left not angry
            {
                ScoreManager.instance.deductPoints(1, false);
                ScoreManager.instance.deductPoints(2, false);
            }
            else            // customer left angry
            {
                if (wrongMeals.Contains(1))
                {
                    ScoreManager.instance.deductPoints(1, false);
                    ScoreManager.instance.deductPoints(1, false);
                }

                if (wrongMeals.Contains(2))
                {
                    ScoreManager.instance.deductPoints(2, false);
                    ScoreManager.instance.deductPoints(2, false);
                }
            }
        }
    }

    private List<string> generateOrder()
    {
        List<string> newOrder = new List<string>();
        string[] choices = {"T", "C", "B", "S", "R", "O"};

        for (int index = 0; index < Random.Range(1,4); index++)
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

            if (playerFoodList.Count != order.Count)        // check if combination matches order  
                comboMatches = false;
            else
            {
                for (int index = 0; index < playerFoodList.Count; index++)
                {
                    if (playerFoodList[index] != order[index])
                        comboMatches = false;
                }
            }

            if (comboMatches)                               // combination does match order
            {
                Destroy(gameObject);

                if (timeRemaining >= 0.7f * (30f * order.Count))    // spawn pickup
                {
                    int pickupType = Random.Range(1, 4);
                    Transform pickupObj = null;

                    if (pickupType == 1)
                        pickupObj = pickupTimeObj;
                    else if (pickupType == 2)
                        pickupObj = pickupSpeedObj;
                    else if (pickupType == 3)
                        pickupObj = pickupScoreObj;

                    Instantiate(pickupObj, new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(0.5f, -2.5f), pickupObj.position.z), pickupObj.rotation);
                    GameObject pickup = GameObject.Find(pickupObj.name + "(Clone)");
                    pickup.name = pickupObj.name + "-" + player.playerNumber;
                }

                ScoreManager.instance.addPoints(player.playerNumber, false);
                player.removeAllFood();
            }
            else                                            // combination does not match order
            {
                isAngry = true;

                GameObject body = GameObject.Find(gameObject.name + "/Face");
                body.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0, 0);
                body = GameObject.Find(gameObject.name + "/Body");
                body.GetComponent<SpriteRenderer>().color = new Color (0.5f, 0, 0);
                body = GameObject.Find(gameObject.name + "/Canvas/Slider/Fill Area/Fill");
                body.GetComponent<Image>().color = new Color (0.5f, 0, 0);

                wrongMeals.Add(player.playerNumber);
                player.removeAllFood();
            }
        }
    }
}