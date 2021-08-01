using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebugState{ Clearing, Burning, Sowing, Watering, Blessing, Complete, None};
[SelectionBase]
public class WorldHandler : MonoBehaviour
{
    public DebugState CurrentDebugState;
    [SerializeField] private WorldObjectState _currentWorldState = null;
    public bool isWorldComplete = false;
    public int WorldValue;
    public float Duration;

    public readonly WorldObjectState_Blessing WorldBlessing = new WorldObjectState_Blessing();
    public readonly WorldObjectState_Complete WorldComplete = new WorldObjectState_Complete();

    public GameObject BlessingGO;
    public GameObject CompleteGO;

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
        switch (CurrentDebugState)
        {
            case DebugState.None:
                break;
            case DebugState.Blessing:
                TransistionToState(WorldBlessing);
                break;
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
    private void OnTriggerEnter(Collider other)
    {
        if(!isWorldComplete)
            _currentWorldState.CheckTrigger(this, other);
    }
    public void DelayedExitAnimation()
    {
        Invoke("ExitAnimation", 1f);
    }
    private void ExitAnimation()
    {
        Animator.SetTrigger("isComplete");
    }

    public void DecreaseDuration()
    {
        Duration -= Time.deltaTime;
    }
}
