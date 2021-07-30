using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebugState{ Fire, Earth, Water, Wind, None };
public class WorldHandler : MonoBehaviour
{
    public DebugState CurrentDebugState;
    [SerializeField] private WorldObjectState _currentWorldState;

    public readonly WorldObjectState_Fire FireState = new WorldObjectState_Fire();
    public readonly WorldObjectState_Earth EarthState = new WorldObjectState_Earth();
    public readonly WorldObjectState_Water WaterState = new WorldObjectState_Water();
    public readonly WorldObjectState_Wind WindState = new WorldObjectState_Wind();
    
    [SerializeField] private BoxCollider _worldCollider;
    public ParticleSystem EarthParticleSystem;
    public ParticleSystem FireParticleSystem;

    void Start()
    {
        SetStartState();
        Debug.Log($"current world sate is {_currentWorldState}");
    }
    private void SetStartState()
    {
        switch (CurrentDebugState)
        {
            case DebugState.None:
                break;
            case DebugState.Fire:
                TransistionToState(FireState);
                break;
            case DebugState.Earth:
                TransistionToState(EarthState);
                break;
            case DebugState.Water:
                TransistionToState(WaterState);
                break;
            case DebugState.Wind:
                TransistionToState(WindState);
                break;
        }
    }

    void Update()
    {
        _currentWorldState.Update(this);
    }
    public void TransistionToState(WorldObjectState state)
    {
        _currentWorldState = state;
        _currentWorldState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"ontriggerEnter was fired and detecting {other.gameObject.name}");
        _currentWorldState.CheckTrigger(this, other);
    }
}
