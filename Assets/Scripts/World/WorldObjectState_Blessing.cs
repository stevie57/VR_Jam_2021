using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectState_Blessing : WorldObjectState
{

    public override void EnterState(WorldHandler worldHandler)
    {
        worldHandler.BlessingGO.SetActive(true);
        worldHandler.Duration = 3f;
    }
    public override void ExitState(WorldHandler worldHandler)
    {
        worldHandler.BlessingGO.SetActive(false);
    }
    public override void CheckTrigger(WorldHandler worldHandler, Collider other)
    {
        if (other.gameObject.CompareTag("WindElement"))
            worldHandler.TransistionToState(worldHandler.WorldComplete);
    }
    public override void Start(WorldHandler worldHandler)
    {

    }
    public override void Update(WorldHandler worldHandler)
    {
        CheckDuration(worldHandler);
    }

    private void CheckDuration(WorldHandler worldHandler)
    {
        if(worldHandler.Duration <= 0)
            worldHandler.TransistionToState(worldHandler.WorldComplete);
    }
}
