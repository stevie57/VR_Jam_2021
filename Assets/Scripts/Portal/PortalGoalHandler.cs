using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGoalHandler : MonoBehaviour
{
    [SerializeField] PlayerSO _playerSO;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Object at portal end detected and it is {other.gameObject.name}");
        
        WorldHandler worldHandler = other.GetComponent<WorldHandler>();
        Debug.Log($"worldhandler is currently {worldHandler}");
        if (worldHandler == null)
            return;

        if (worldHandler.isWorldComplete)
            _playerSO.IncreaseScore(worldHandler.WorldValue);
    }
}
