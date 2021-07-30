using UnityEngine;

[System.Serializable]
public abstract class WorldObjectState
{
    public abstract void Start(WorldHandler worldHandler);
    public abstract void EnterState(WorldHandler worldHandler);
    public abstract void ExitState(WorldHandler worldHandler);
    public abstract void Update(WorldHandler worldHandler);
    //public abstract void CheckColllision(WorldHandler worldHandler, Collision collision);
    public abstract void CheckTrigger(WorldHandler worldHandler, Collider other);
}
