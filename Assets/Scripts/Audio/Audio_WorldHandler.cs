using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_WorldHandler : MonoBehaviour
{
    [SerializeField] private AudioEventChannelSO _worldEventSFX;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _worldEventSFX.WorldAudioEvent += PlayAudioFX;
    }

    private void OnDisable()
    {
        _worldEventSFX.WorldAudioEvent -= PlayAudioFX;
    }

    private void PlayAudioFX(Transform target, AudioClip clip)
    {
        transform.position = target.transform.position;
        _audioSource.PlayOneShot(clip);
    }
}
