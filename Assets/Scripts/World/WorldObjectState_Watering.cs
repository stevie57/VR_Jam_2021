using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectState_Watering : WorldObjectState
{
    public override void EnterState(WorldHandler worldHandler)
    {
        worldHandler.WateringGO.SetActive(true);
        worldHandler.Duration = 2f;
        worldHandler.RequiredElement = ElementTypes.Water;
    }
    public override void ExitState(WorldHandler worldHandler)
    {
        worldHandler.WateringGO.SetActive(false);
    }
    public override void Update(WorldHandler worldHandler)
    {
        if(worldHandler.Duration <= 0)
        {
            worldHandler.CorrectElementSound();
            worldHandler.TransistionToState(worldHandler.WorldBlessing);
        }
    }
}
