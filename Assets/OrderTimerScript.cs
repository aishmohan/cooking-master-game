using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTimerScript : MonoBehaviour
{
    // Global variables
    public float maxTime = 120f;    // total amount of time to complete this order
    private Image orderTimerBar;
    private float timeLeft;         // amount of time remaining to complete order
    

    /** Start is called before the first frame update
     */
    void Start()
    {
        orderTimerBar = GetComponent<Image> ();
        timeLeft = maxTime;
    }

    /** Update is called once per frame
     *  Reduces the time left and updates the timer bar for the order
     */
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;                     // reduce the time left on the bar
            orderTimerBar.fillAmount = timeLeft / maxTime;  // fill the bar according to the time remaining
        }
    }
}
