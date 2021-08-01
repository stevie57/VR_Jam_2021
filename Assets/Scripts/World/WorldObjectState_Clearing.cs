using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectState_Clearing : WorldObjectState
{
    public override void EnterState(WorldHandler worldHandler)
    {
        worldHandler.ClearingGO.SetActive(true);
        worldHandler.Duration = 2f;
        worldHandler.RequiredElement = ElementTypes.Fire;
        worldHandler.WorldValue++;
    }

    public override void ExitState(WorldHandler worldHandler)
    {
        worldHandler.ClearingGO.SetActive(false);
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
            worldHandler.TransistionToState(worldHandler.WorldBurning);
        }
    }
}
