using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementTypes { Fire, Earth, Water, Wind };
public enum DebugState { Watering, Blessing, Sowing, Burning, Clearing, Complete, None};
[SelectionBase]
public class WorldHandler : MonoBehaviour
{
    public ElementTypes RequiredElement;
    public DebugState CurrentDebugState;
    [SerializeField] private WorldObjectState _currentWorldState = null;
    public bool isWorldComplete = false;
    public int WorldValue;
    public float Duration;

    public readonly WorldObjectState_Blessing WorldBlessing = new WorldObjectState_Blessing();
    public readonly WorldObjectState_Complete WorldComplete = new WorldObjectState_Complete();
    public readonly WorldObjectState_Watering WorldWatering = new WorldObjectState_Watering();

    public GameObject BlessingGO;
    public GameObject CompleteGO;
    public GameObject WateringGO;

    [SerializeField] private BoxCollider _worldCollider;
    public ParticleSystem WorldCompletePS;
    public ParticleSystem FireParticleSystem;

    public Animator Animator;
    private void Awake()
    {
        BlessingGO.SetActive(false);
        CompleteGO.SetActive(false);
    }
    void Start()
    {
        SetStartState();
    }
    private void SetStartState()
    {
        if(CurrentDebugState != DebugState.None)
        {
            switch (CurrentDebugState)
            {
                case DebugState.Blessing:
                    TransistionToState(WorldBlessing);
                    break;
                case DebugState.Watering:
                    TransistionToState(WorldWatering);
                    break;
            }
            return;
        }
        
    }
    void Update()
    {
        _currentWorldState.Update(this);
    }
    public void TransistionToState(WorldObjectState state)
    {
        if (_currentWorldState != null)
            _currentWorldState.ExitState(this);
        _currentWorldState = state;
        _currentWorldState.EnterState(this);
    }
    public void DelayedExitAnimation()
    {
        Invoke("ExitAnimation", 1f);
    }
    private void ExitAnimation()
    {
        Animator.SetTrigger("isComplete");
    }

    public void DecreaseDuration(ElementHandler elemenetHandler)
    {
        if (elemenetHandler.ElementType == RequiredElement)
            Duration -= Time.deltaTime;
    }
}
