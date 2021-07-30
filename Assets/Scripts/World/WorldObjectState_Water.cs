using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectState_Water : WorldObjectState
{
    //public override void CheckColllision(WorldHandler worldHandler, Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("WaterElement"))
    //        worldHandler.greenParticleSystem.Play();
    //}

    public override void EnterState(WorldHandler worldHandler)
    {

    }

    public override void CheckTrigger(WorldHandler worldHandler, Collider other)
    {
        if (other.gameObject.CompareTag("WaterElement"))
            worldHandler.TransistionToState(worldHandler.EarthState);
    }

    public override void Start(WorldHandler worldHandler)
    {

    }

    public override void Update(WorldHandler worldHandler)
    {
       
    }
}
