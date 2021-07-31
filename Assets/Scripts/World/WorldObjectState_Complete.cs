using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectState_Complete : WorldObjectState
{
    public override void EnterState(WorldHandler worldHandler)
    {
        worldHandler.WorldCompletePS.Play();
        worldHandler.CompleteGO.SetActive(true);
        worldHandler.isWorldComplete = true;
        worldHandler.DelayedExitAnimation();       
    }
    public override void ExitState(WorldHandler worldHandler)
    {

    }
    public override void CheckTrigger(WorldHandler worldHandler, Collider other)
    {

    }
    public override void Start(WorldHandler worldHandler)
    {

    }
    public override void Update(WorldHandler worldHandler)
    {

    }
}
