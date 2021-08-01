using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectState_Sowing : WorldObjectState
{
    public override void EnterState(WorldHandler worldHandler)
    {
        worldHandler.SowingGO.SetActive(true);
        worldHandler.Duration = 2f;
        worldHandler.RequiredElement = ElementTypes.Earth;
        worldHandler.WorldValue++;
    }
    public override void ExitState(WorldHandler worldHandler)
    {
        worldHandler.SowingGO.SetActive(false);
    }
    public override void Update(WorldHandler worldHandler)
    {
        CheckDuration(worldHandler);
    }
    private void CheckDuration(WorldHandler worldHandler)
    {
        if (worldHandler.Duration <= 0)
        {
            worldHandler.CorrectElementSound();
            worldHandler.TransistionToState(worldHandler.WorldWatering);
        }
    }
}
