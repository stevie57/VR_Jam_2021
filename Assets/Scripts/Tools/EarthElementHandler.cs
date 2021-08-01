using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EarthElementHandler : ElementHandler
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _rayLength;
    [SerializeField] private bool isActivated;
    [SerializeField] private Transform _rayStart;
    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        _particleSystem.Play();
        PlaySFX();
        isActivated = true;
    }
    private void PlaySFX()
    {
        AudioClip clip = _clipsSFXSO.RandomClip(_clipsSFXSO.EarthClips);
        _audioSource.clip = clip;
        _audioSource.Play();
    }
    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
        _particleSystem.Stop();
        _audioSource.Stop();
        isActivated = false;
    }
    private void Update()
    {
        if (isActivated)
            RayCastCheck();
    }
    private void RayCastCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(_rayStart.transform.position, _rayStart.transform.forward, out hit, _rayLength, _layerMask))
        {
            Debug.DrawRay(_rayStart.transform.position, _rayStart.transform.forward * hit.distance, Color.yellow);
            Debug.Log($"Did Hit and it is {hit.transform.gameObject.name}");
            hit.transform.gameObject.GetComponent<WorldHandler>().DecreaseDuration(this);
        }
        else
        {
            Debug.DrawRay(_rayStart.transform.position, _rayStart.transform.forward * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
