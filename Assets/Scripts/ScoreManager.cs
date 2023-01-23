using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private static int PlayerScore = 0;
    private static int OpponentPlayerScore = 0;
    [SerializeField] private  int scoreValue;
   [ SerializeField] private TMP_Text scoreText, FinalScore;
    [SerializeField] private TMP_Text multiPlayerScoreTmp, oppenentScoreTmp;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void InitScore()
    {
       
        if (!uiManager.GetMultiplayerStatus())
        {
            PlayerScore = 0;
            scoreText.text = PlayerScore.ToString();
        }
        else
        {
            StartCoroutine(Countdown(90));
            PlayerScore = 0;
            OpponentPlayerScore = 0;
            multiPlayerScoreTmp.text = PlayerScore.ToString();
            oppenentScoreTmp.text = OpponentPlayerScore.ToString();

        }

    }
    public void UpdateScore()
    {
        if (!uiManager.GetMultiplayerStatus())
        {
            PlayerScore += scoreValue;
            scoreText.text = PlayerScore.ToString();
            FinalScore.text = PlayerScore.ToString();
        }
        else
        {
            PlayerScore += scoreValue;
            multiPlayerScoreTmp.text = PlayerScore.ToString();
            FinalScore.text = PlayerScore.ToString();
        }
       
        
        
    }
    public void UpdateOpponentScore()
    {
        OpponentPlayerScore += scoreValue;
        oppenentScoreTmp.text = PlayerScore.ToString();
        FinalScore.text = PlayerScore.ToString();
    }
   public void CheckGameOver()
    {
        if(PlayerScore>OpponentPlayerScore)
        uiManager.ShowGameOver("YOU WIN");
        else
            uiManager.ShowGameOver("YOU LOSE");
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while(counter > 0) {
            yield return new WaitForSeconds(1);
            counter--;
        }
        CheckGameOver();
    }
}
