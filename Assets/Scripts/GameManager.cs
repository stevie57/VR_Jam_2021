using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float LevelDuration;
    [SerializeField] private Timer _timer;

    [SerializeField] private GameManagerEventChannelSO _timedOut;

    private void Start()
    {
        _timer.StartTimer(LevelDuration);
    }
    public void TimedOut()
    {
        Debug.Log($"Time has run out");
        _timedOut.RaiseEvent();
    }
}
