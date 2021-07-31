using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/WorldAudio Event Channel")]
public class AudioEventChannelSO : ScriptableObject
{
    public UnityAction<Transform, AudioClip> WorldAudioEvent;

    public void RaiseEvent(Transform pos, AudioClip soundClip)
    {
        if(WorldAudioEvent != null)
        {
            WorldAudioEvent.Invoke(pos, soundClip);
        }
        else
        {
            Debug.LogWarning($"{this.name} event was requested but nobody picked it up");
        }
    }
}
