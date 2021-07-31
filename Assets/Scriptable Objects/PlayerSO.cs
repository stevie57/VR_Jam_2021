using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Misc/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public int Score;
    public int HighScore;
    public UI_Score ScoreUI;
    private void OnEnable()
    {
        //ResetScore();
    }
    public void IncreaseScore(int value)
    {
        Score += value;
        ScoreUI.DisplayScore();
        Debug.Log($"score ui should be updating");
    }
    public void ResetScore()
    {
        Score = 0;
    }
}
