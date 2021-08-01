using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameManagerEventChannelSO StartButton;
    public GameManagerEventChannelSO QuitButton; 
    private Canvas _canvas;
    private  void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main;
    }
    public void OnStartButton()
    {
        StartButton.RaiseEvent();
    }
    public void OnQuitButton()
    {
        QuitButton.RaiseEvent();
    }
}
