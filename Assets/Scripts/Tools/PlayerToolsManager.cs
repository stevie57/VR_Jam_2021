using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolsManager : MonoBehaviour
{
    [SerializeField] private GameManagerEventChannelSO _timedOut;

    [SerializeField] private List<GameObject> _playerToolsList = new List<GameObject>();

    private void OnEnable()
    {
        _timedOut.GameManagerEvent += DisablePlayerTools;
    }

    private void OnDisable()
    {
        _timedOut.GameManagerEvent -= DisablePlayerTools;
    }

    private void DisablePlayerTools()
    {
        foreach (GameObject tool in _playerToolsList)
            tool.SetActive(false);
    }
}
