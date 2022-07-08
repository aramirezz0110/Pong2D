using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public int maxScoreToWin = 3;

    [SerializeField] private TMP_Text scorePlayer1Text;
    [SerializeField] private TMP_Text scorePlayer2Text;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetPlayer1Score(0);
        SetPlayer2Score(0);
    }
    private void Update()
    {
        
    }
    public void SetPointToPlayer(PlayerType playerType)
    {
        if(playerType == PlayerType.Player1)
        {
            IncreaseScorePlayer1();
        }
        else if(playerType == PlayerType.Player2)
        {
            IncreaseScorePlayer2();
        }
    }
    private void IncreaseScorePlayer1()
    {
        ++scorePlayer1;
        if (scorePlayer1 <= maxScoreToWin)
        {            
            SetPlayer1Score(scorePlayer1);
            if (scorePlayer1 == maxScoreToWin)
            {
                print("Player 1 wins!");
                Time.timeScale = 0;
            }
        }        
    }
    private void IncreaseScorePlayer2()
    {
        ++scorePlayer2;
        if (scorePlayer2 < maxScoreToWin)
        {            
            SetPlayer2Score(scorePlayer2);
            if (scorePlayer2 == maxScoreToWin)
            {
                print("Player 2 wins!");
                Time.timeScale = 0;
            }
        }
        
    }
    private void SetPlayer1Score(int score)
    {
        scorePlayer1Text.text = score.ToString();
    }
    private void SetPlayer2Score(int score)
    {
        scorePlayer2Text.text = score.ToString();
    }
}
