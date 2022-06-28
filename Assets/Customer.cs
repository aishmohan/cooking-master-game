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
        timeRemaining = 20f * order.Count;
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
}