using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimerHandler : MonoBehaviour
{
    private Timer timer;
    public float LevelDuration;

    public GameObject GameUI;
    public GameObject LevelUI;
    void Start()
    {
        LevelUI.SetActive(false);
        GameUI.SetActive(true);
        timer = GetComponent<Timer>();
        timer.StartTimer(LevelDuration);
    }

    public void TimedOut()
    {
        LevelUI.SetActive(true);
        GameUI.SetActive(false);
    }


}
