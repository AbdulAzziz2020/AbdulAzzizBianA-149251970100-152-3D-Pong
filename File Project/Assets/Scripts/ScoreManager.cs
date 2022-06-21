using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [Header("Score Text")]
    public int maxScore = 15;

    public TMP_Text scorePlayer1Text;
    public TMP_Text scorePlayer2Text;
    public TMP_Text scorePlayer3Text;
    public TMP_Text scorePlayer4Text;

    private void Update()
    {
        CalculateScorePlayer1();
        CalculateScorePlayer2();
        CalculateScorePlayer3();
        CalculateScorePlayer4();
    }

    #region Calculate Player Score
    void CalculateScorePlayer1()
    {
        if(Data.scorePlayer1 != maxScore)
        {
            scorePlayer1Text.text = "Player 1 \n" + Data.scorePlayer1.ToString();
        } else {
            scorePlayer1Text.text = "Player 1 \n Game Over!";
            Data.isEndForPlayer1 = false;
        }
    }

    void CalculateScorePlayer2()
    {
        if (Data.scorePlayer2 != maxScore)
        {
            scorePlayer2Text.text = "Player 2 \n" + Data.scorePlayer2.ToString();
        }
        else
        {
            scorePlayer2Text.text = "Player 2 \n Game Over!";
            Data.isEndForPlayer2 = false;
        }
    }

    void CalculateScorePlayer3()
    {
        if (Data.scorePlayer3 != maxScore)
        {
            scorePlayer3Text.text = "Player 3 \n" + Data.scorePlayer3.ToString();
        }
        else
        {
            scorePlayer3Text.text = "Player 3 \n Game Over!";
            Data.isEndForPlayer3 = false;
        }
    }

    void CalculateScorePlayer4()
    {
        if (Data.scorePlayer4 != maxScore)
        {
            scorePlayer4Text.text = "Player 4 \n" + Data.scorePlayer4.ToString();
        }
        else
        {
            scorePlayer4Text.text = "Player 4 \n Game Over!";
            Data.isEndForPlayer4 = false;
        }
    }
    #endregion
}