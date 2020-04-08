using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler1 : MonoBehaviour
{
    private TMPro.TMP_Text scoreText;
    int score1;
    void Start()
    {
        scoreText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score1 = Player1Script.player1Score;
        scoreText.text = "Score: " + score1;
    }
}
