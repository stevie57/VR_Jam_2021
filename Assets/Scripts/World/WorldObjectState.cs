using UnityEngine;

[System.Serializable]
public abstract class WorldObjectState
{
    public abstract void EnterState(WorldHandler worldHandler);
    public abstract void ExitState(WorldHandler worldHandler);
    public abstract void Update(WorldHandler worldHandler);
}
