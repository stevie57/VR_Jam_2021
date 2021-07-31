using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameManagerEventChannelSO StartButton;
    public GameManagerEventChannelSO QuitButton;
    public void OnStartButton()
    {
        StartButton.RaiseEvent();
    }
    public void OnQuitButton()
    {
        QuitButton.RaiseEvent();
    }
}
