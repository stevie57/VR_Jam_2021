using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectState_Burning : WorldObjectState
{
    public override void EnterState(WorldHandler worldHandler)
    {
        worldHandler.BurningGO.SetActive(true);
        worldHandler.Duration = 2f;
        worldHandler.RequiredElement = ElementTypes.Water;
        worldHandler.WorldValue++;
    }

    public override void ExitState(WorldHandler worldHandler)
    {
        worldHandler.BurningGO.SetActive(false);
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
            worldHandler.TransistionToState(worldHandler.WorldSowing);
        }
    }
}
