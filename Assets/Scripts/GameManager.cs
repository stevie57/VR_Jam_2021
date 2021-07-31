using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DebugLevel { MainMenu, Level, EndLevel};
public class GameManager : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private float _levelDuration;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameManagerEventChannelSO _timedOut;
    [SerializeField] private Scene _currentScene;

    [Header("Debug Settings")]
    [SerializeField] private bool isDebug;
    [SerializeField] DebugLevel _debugLevel;

    private void Start()
    {
        if (isDebug)
            LoadSceneDebug();
        else
            LoadLevel(MainMenuCoroutine());
    }
    public void TimedOut()
    {
        Debug.Log($"Time has run out");
        _timedOut.RaiseEvent();
    }
    private void LoadSceneDebug()
    {
        switch (_debugLevel)
        {
            case DebugLevel.MainMenu:
                LoadLevel(MainMenuCoroutine());
                break;
            case DebugLevel.Level:
                LoadLevel(LevelCoroutine());
                break;
            case DebugLevel.EndLevel:
                LoadLevel(EndLevelCoroutine());
                break;
        }
    }
    private void LoadLevel(IEnumerator levelCoroutine)
    {
        if (_currentScene != null)
            UnloadPrevious(_currentScene);
        StartCoroutine(levelCoroutine);
    }
    private IEnumerator MainMenuCoroutine()
    {
        yield return SceneManager.LoadSceneAsync("MainMenuUI", LoadSceneMode.Additive);
        _currentScene = SceneManager.GetSceneByName("MainMenuUI");
        SceneManager.SetActiveScene(_currentScene);
    }
    private IEnumerator LevelCoroutine()
    {
        yield return SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
        _currentScene = SceneManager.GetSceneByName("Level");
        SceneManager.SetActiveScene(_currentScene);
        StartLevelTimer();
    }
    private IEnumerator EndLevelCoroutine()
    {
        yield return SceneManager.LoadSceneAsync("EndLevel", LoadSceneMode.Additive);
        _currentScene = SceneManager.GetSceneByName("EndLevel");
        SceneManager.SetActiveScene(_currentScene);
    }

    private void StartLevelTimer()
    {
        _timer.StartTimer(_levelDuration);
    }
    private void UnloadPrevious(Scene scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
