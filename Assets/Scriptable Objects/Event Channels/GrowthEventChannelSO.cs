using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Growth Event Channel")]
public class GrowthEventChannelSO : ScriptableObject
{
    public UnityAction<float> GrowthEvent;
    public void RaiseEvent(float value)
    {
        if (GrowthEvent != null)
        {
            GrowthEvent.Invoke(value);
        }
        else
        {
            Debug.LogWarning($"{this.name} event was requested but nobody picked it up");
        }
    }
}
