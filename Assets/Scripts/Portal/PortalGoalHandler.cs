using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGoalHandler : MonoBehaviour
{
    [SerializeField] private PlayerSO _playerSO;
    [SerializeField] private WorldSpawner _worldSpawner;

    private void Awake()
    {
        if (_worldSpawner == null)
            _worldSpawner = GetComponent<WorldSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Object at portal end detected and it is {other.gameObject.name}");
        
        WorldHandler worldHandler = other.GetComponent<WorldHandler>();
        Debug.Log($"worldhandler is currently {worldHandler}");
        if (worldHandler == null)
            return;

        if (worldHandler.isWorldComplete)
            _playerSO.IncreaseScore(worldHandler.WorldValue);

        other.gameObject.SetActive(false);
        _worldSpawner.WorldPool.Enqueue(other.gameObject);
        _worldSpawner.SpawnWorld();
    }
}
