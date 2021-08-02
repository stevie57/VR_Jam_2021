using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class WorldSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _worldPrefab;
    public Queue<GameObject> WorldPool = new Queue<GameObject>();
    [SerializeField] private int _amountToPool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int WorldStateRange;
    [SerializeField] List<GameObject> _worldList = new List<GameObject>();
    [SerializeField] private bool isSpawning = false;

    private void Start()
    {
        CreateWorldPool();
        SpawnWorld();
    }
    private void CreateWorldPool()
    {
        for(int i = 0; i < _amountToPool; i++)
        {
            GameObject worldGO = Instantiate(_worldPrefab);
            worldGO.SetActive(false);
            WorldHandler worldHandler = worldGO.GetComponent<WorldHandler>();
            worldHandler.WorldStateRange = WorldStateRange;
            _worldList.Add(worldGO);
            WorldPool.Enqueue(worldGO);
        }
    }
    public void SpawnWorld()
    {
        if (!isSpawning)
        {
            GameObject worldGO = WorldPool.Dequeue();
            if (worldGO == null)
                return;

            Rigidbody worldRB = worldGO.GetComponent<Rigidbody>();
            worldRB.velocity = Vector3.zero;
            worldRB.angularVelocity = Vector3.zero;
            worldGO.transform.position = _spawnPoint.transform.position;
            worldGO.transform.rotation = Quaternion.identity;
            WorldHandler worldHandler = worldGO.GetComponent<WorldHandler>();
            worldHandler.isWorldComplete = false;
            worldGO.SetActive(true);
        }
    }

    public void TurnOff()
    {
        foreach (GameObject world in _worldList)
            world.SetActive(false);
    }
}
