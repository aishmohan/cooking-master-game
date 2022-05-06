using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTimerScript : MonoBehaviour
{
    // Global variables
    Image orderTimerBar;
//  public GameObject orderText;
    public float maxTime = 20f;
    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        orderTimerBar = GetComponent<Image> ();
    //  orderText.SetActive(true);
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime; // reduce the time left on the bar
            orderTimerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
