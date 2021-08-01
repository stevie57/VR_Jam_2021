using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelMenu : UI_MainMenu
{
    public GameManagerEventChannelSO MainMenuButton;
    public void OnMainMenu()
    {
        MainMenuButton.RaiseEvent();
    }
}
