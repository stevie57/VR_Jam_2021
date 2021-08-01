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

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _errorCount = 0;
    [SerializeField] private AudioHandlerWorld_SFX _audioClipsSO;

    public GameManagerEventChannelSO GrowthEvent;

    public Animator Animator;
    private void Awake()
    {
        WateringGO.SetActive(false);
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
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        int randomNumber = UnityEngine.Random.Range(0, 1);
        Debug.Log($"random number is {randomNumber}");        
        CurrentDebugState = (DebugState)randomNumber;
        SetStartState();
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
        Invoke("ExitAnimation", 2f);
    }
    private void ExitAnimation()
    {
        Animator.SetTrigger("isComplete");
    }
    public void DecreaseDuration(ElementHandler elemenetHandler)
    {
        if (elemenetHandler.ElementType == RequiredElement)
            Duration -= Time.deltaTime;
        else
            IncorrectElement();
    }

    private void IncorrectElement()
    {
        if (!_audioSource.isPlaying)
            _audioSource.clip = _audioClipsSO.RandomClip(_audioClipsSO.WorldErrorClips);
        _audioSource.Play();
        _errorCount++;
    }
    public void CorrectElementSound()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_audioClipsSO.RandomClip(_audioClipsSO.WorldCorrectClips));
    }
}
