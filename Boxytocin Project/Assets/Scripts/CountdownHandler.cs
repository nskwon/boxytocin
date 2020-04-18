using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownHandler : MonoBehaviour
{
    private TMPro.TMP_Text timeText;
    public float timeLeft;
    public static bool gameOver;

    void Start()
    {
        timeText = GetComponent<TMPro.TMP_Text>();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = "Time: " + (int)timeLeft;
        isGameOver();
        if (gameOver)
        {
            Time.timeScale = 0f;
            if (Player1Script.player1Score > Player2Script.player2Score)
            {
                timeText.text = "PLAYER 1 WINS! You're such a noob Player 2!";
            }
            else if (Player2Script.player2Score > Player1Script.player1Score)
            {
                timeText.text = "PLAYER 2 WINS! You're such a noob Player 1!";
            }
            else
            {
                timeText.text = "You both tied? Wow you're both noobs! HAHA";
            }
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    void isGameOver()
    {
        if (timeLeft < 0)
        {
            gameOver = true;
        }
    }
}
