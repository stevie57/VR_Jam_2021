using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private PlayerSO _playerSO;
    private void Awake()
    {
        _playerSO.ScoreUI = this;
    }
    void Start()
    {
        DisplayScore();
    }
    public void DisplayScore()
    {
        _scoreTMP.text = _playerSO.Score.ToString();
    }
}
