using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElementHandler : XRGrabInteractable
{
    [Header("Audio")]
    [SerializeField] private protected AudioHandlerWorld_SFX _clipsSFXSO;
    [SerializeField] private protected AudioSource _audioSource;

    [Header("Position Reset")]
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private protected LayerMask _layerMask;

    public ElementTypes ElementType;
    private protected void Start()
    {
        startPos = transform.position;
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        ResetPosition();
    }
    void ResetPosition()
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
        transform.position = startPos;
        transform.rotation = Quaternion.identity;
    }
}
