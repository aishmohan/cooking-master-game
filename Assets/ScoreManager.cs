using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Global variables
    public static ScoreManager instance;

    public TextMeshProUGUI time1Text;
    public TextMeshProUGUI time2Text;
    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;
    public TextMeshProUGUI winText;
    public SpriteRenderer winSquare;

    private int score1 = 0;             // score for player one
    private int score2 = 0;
    private float time1 = 90f;         // time left for player one
    private float time2 = 90f;


    /** Awake is called on awakening before Start
     */
    private void Awake()
    {
        instance = this;

        winText.enabled = false;
        winSquare.enabled = false;
    }

    /** Update is called once per frame
     *  Reduces the time left and updates the time displays
     */
    void Update()
    {
        if (time1 <= 0 && time2 <= 0)       // end the game
        {
            Time.timeScale = 0;

            winText.text = "Player " + (score1 > score2 ? "one" : "two") + " wins!";
            winText.enabled = true;
            winSquare.enabled = true;
        }
        else                                // continue the game
        {
            if (time1 > 0)
            {
                time1 -= Time.deltaTime;
            }

            if (time2 > 0)
            {
                time2 -= Time.deltaTime;
            }
        }

        displayTimes();
    }

    public void addTime(int playerNumber)
    {
        if (playerNumber == 1)
        {
            time1 += 20;
        }
        else if (playerNumber == 2)
        {
            time2 += 20;
        }
    }

    /** Adds points to a player's score
     *  @param playerNumber the number of the player to add points to
     */
    public void addPoints(int playerNumber, bool isBonus)
    {
        if (playerNumber == 1)
        {
            score1 += (isBonus ? 20 : 100);
        }
        else if (playerNumber == 2)
        {
            score2 += (isBonus ? 20 : 100);
        }
        
        displayScores();
    }

    public void deductPoints(int playerNumber, bool isTrashed)
    {
        if (playerNumber == 1)
        {
            score1 -= (isTrashed ? 10 : 100);
        }
        else if (playerNumber == 2)
        {
            score2 -= (isTrashed ? 10 : 100);
        }

        displayScores();
    }
    
    /** Updates the score displayed for both players
     */
    private void displayScores()
    {
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }

    /** Updates the time displayed for both players
     *  Time is rounded up to nearest int
     */
    private void displayTimes()
    {
        time1Text.text = ((int)Mathf.Ceil(time1)).ToString();
        time2Text.text = ((int)Mathf.Ceil(time2)).ToString();
    }
}
