using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenuV2 : MonoBehaviour
{
    public GameManagerEventChannelSO _level1Button;
    public GameManagerEventChannelSO _level2Button;
    public GameManagerEventChannelSO _level3Button;
    public GameManagerEventChannelSO _level4Button;
    public GameManagerEventChannelSO _endlessButton;
    public GameManagerEventChannelSO QuitButton;

    private Canvas _canvas;
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main;
    }

    public void OnLevel1Button()
    {
        _level1Button.RaiseEvent();
    } 
    public void OnLevel2Button()
    {
        _level2Button.RaiseEvent();
    }

    public void OnLevel3Button()
    {
        _level3Button.RaiseEvent();
    }
    public void OnLevel4Button()
    {
        _level4Button.RaiseEvent();
    }
    public void OnEndlessButton()
    {
        _endlessButton.RaiseEvent();
    }
    public void OnQuitButton()
    {
        QuitButton.RaiseEvent();
    }
}
