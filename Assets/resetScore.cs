using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetScore : MonoBehaviour
{
    [SerializeField] PlayerSO _playerSO;
    void Start()
    {
        _playerSO.ResetScore();
        _playerSO.IncreaseScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
