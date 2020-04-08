using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler2 : MonoBehaviour
{
    private TMPro.TMP_Text scoreText;
    int score2;
    void Start()
    {
        scoreText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score2 = Player2Script.player2Score;
        scoreText.text = "Score: " + score2;
    }
}
