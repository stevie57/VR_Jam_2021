using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Game Manager Event Channel")]
public class GameManagerEventChannelSO : ScriptableObject
{
    public UnityAction GameManagerEvent;
    public void RaiseEvent()
    {
        if (GameManagerEvent != null)
        {
            GameManagerEvent.Invoke();
        }
        else
        {
            Debug.LogWarning($"{this.name} event was requested but nobody picked it up");
        }
    }
}
