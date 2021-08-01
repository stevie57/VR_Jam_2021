using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WindElementHandler : XRGrabInteractable
{
    [SerializeField] private ParticleSystem _particleSystem1;
    [SerializeField] private ParticleSystem _particleSystem2;
    [SerializeField] private AudioHandlerWorld_SFX _clipsSFXSO;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private bool isActivated;
    [SerializeField] private Transform _rayStart;
    private Vector3 startPos;

    [SerializeField] private float _sphereRadius;

    private void Start()
    {
        startPos = transform.position;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        transform.position = startPos;
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        PlayWindParticles();
        PlayWindSFX();
        isActivated = true;
    }

    private void PlayWindSFX()
    {
        AudioClip clip = _clipsSFXSO.RandomClip(_clipsSFXSO.WindClips);
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
        StopWindParticles();
        _audioSource.Stop();
        isActivated = false;
    }
    private void PlayWindParticles()
    {
        _particleSystem1.Play();
        _particleSystem2.Play();
    }
    private void StopWindParticles()
    {
        _particleSystem1.Stop();
        _particleSystem2.Stop();
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
            hit.transform.gameObject.GetComponent<WorldHandler>().DecreaseDuration();
        }
        else
        {
            Debug.DrawRay(_rayStart.transform.position, _rayStart.transform.forward * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void SphereCastCheck()
    {
        RaycastHit hit;
        if(Physics.SphereCast(_rayStart.transform.position, _sphereRadius, transform.forward, out hit, _rayLength, _layerMask))
        {         
            Debug.DrawRay(_rayStart.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log($"Did Hit and it is {hit.transform.gameObject.name}");
        }
        else
        {
            Debug.DrawRay(_rayStart.transform.position, transform.TransformDirection(Vector3.forward) * _rayLength, Color.white);
            Debug.Log("Did not Hit");
        }     
    }
}
