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
            WorldPool.Enqueue(worldGO);
        }
    }
    public void SpawnWorld()
    {
        GameObject worldGO = WorldPool.Dequeue();
        if (worldGO == null)
            return;

        Rigidbody worldRB = worldGO.GetComponent<Rigidbody>();
        worldRB.velocity = Vector3.zero;
        worldRB.angularVelocity = Vector3.zero;
        worldGO.transform.position = _spawnPoint.transform.position;
        worldGO.transform.rotation = Quaternion.identity;
        worldGO.GetComponent<WorldHandler>().isWorldComplete = false;
        worldGO.SetActive(true);
    }
}
