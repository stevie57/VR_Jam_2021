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

    [SerializeField] private Scene _currentScene;

    [Header("Events")]
    [SerializeField] private GameManagerEventChannelSO _startButton;
    [SerializeField] private GameManagerEventChannelSO _timedOut;
    [SerializeField] private GameManagerEventChannelSO _mainMenu;
    [SerializeField] private GameManagerEventChannelSO _returnMainMenu;
    [SerializeField] private GameManagerEventChannelSO _quitButton;

    [Header("Debug Settings")]
    [SerializeField] private bool isDebug;
    [SerializeField] DebugLevel _debugLevel;

    [Header("Screen Fader")]
    public ScreenFade screenFade = null;
    private void Awake()
    {
        _currentScene = SceneManager.GetActiveScene();
    }
    private void OnValidate()
    {
        if (!screenFade)
            screenFade = FindObjectOfType<ScreenFade>();
    }
    private void OnEnable()
    {
        _startButton.GameManagerEvent += Start_LoadLevel;
        _timedOut.GameManagerEvent += Start_EndLevel;
        _returnMainMenu.GameManagerEvent += Start_MainMenu;
        _quitButton.GameManagerEvent += QuitGame;
    }
    private void OnDisable()
    {
        _startButton.GameManagerEvent -= Start_LoadLevel;
        _timedOut.GameManagerEvent -= Start_EndLevel;
        _returnMainMenu.GameManagerEvent -= Start_MainMenu;
        _quitButton.GameManagerEvent -= QuitGame;
    }
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
        if (_currentScene.name != "Main")
            UnloadPrevious(_currentScene);
        StartCoroutine(levelCoroutine);
    }
    private IEnumerator MainMenuCoroutine()
    {
        yield return SceneManager.LoadSceneAsync("MainMenuUI", LoadSceneMode.Additive);
        _currentScene = SceneManager.GetSceneByName("MainMenuUI");
        SceneManager.SetActiveScene(_currentScene);
        _mainMenu.RaiseEvent();
    }
    private IEnumerator LevelCoroutine()
    {
        yield return screenFade.FadeIn();
        yield return new WaitForSeconds(1f);


        yield return SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
        _currentScene = SceneManager.GetSceneByName("Level");
        SceneManager.SetActiveScene(_currentScene);
        yield return screenFade.FadeOut();
    }

    private IEnumerator LevelCoroutine(string level)
    {
        yield return screenFade.FadeIn();
        yield return new WaitForSeconds(1f);


        yield return SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        _currentScene = SceneManager.GetSceneByName(level);
        SceneManager.SetActiveScene(_currentScene);
        yield return screenFade.FadeOut();
    }

    private IEnumerator EndLevelCoroutine()
    {
        yield return screenFade.FadeIn();
        yield return new WaitForSeconds(1f);

        yield return SceneManager.LoadSceneAsync("EndLevel", LoadSceneMode.Additive);
        _currentScene = SceneManager.GetSceneByName("EndLevel");
        SceneManager.SetActiveScene(_currentScene);

        yield return screenFade.FadeOut();
    }
    private void Start_LoadLevel()
    {
        UnloadPrevious(_currentScene);
        StartCoroutine(LevelCoroutine());
    }

    private void Start_LoadLevelNumber(string level)
    {
        UnloadPrevious(_currentScene);
        StartCoroutine(LevelCoroutine(level));
    }

    private void StartLevelTimer()
    {
        _timer.StartTimer(_levelDuration);
    }
    private void UnloadPrevious(Scene scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
    private void Start_EndLevel()
    {
        UnloadPrevious(_currentScene);
        LoadLevel(EndLevelCoroutine());
    }
    private void Start_MainMenu()
    {
        UnloadPrevious(_currentScene);
        LoadLevel(MainMenuCoroutine());
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
