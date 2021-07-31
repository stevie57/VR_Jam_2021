using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _mainMenuBGClip;
    [SerializeField] private AudioClip _endLevelBGClip;
    [SerializeField] private AudioListSO _levelBGSO;

    [Header("Events")]
    [SerializeField] private GameManagerEventChannelSO _mainMenu;
    [SerializeField] private GameManagerEventChannelSO _level;
    [SerializeField] private GameManagerEventChannelSO _endLevel;

    private void OnEnable()
    {
        _mainMenu.GameManagerEvent += PlayMainMenuBG;
        _level.GameManagerEvent += PlayLevelBG;
        _endLevel.GameManagerEvent += PlayEndLevelBG;
    }
    private void OnDisable()
    {
        _mainMenu.GameManagerEvent -= PlayMainMenuBG;
        _level.GameManagerEvent -= PlayLevelBG;
        _endLevel.GameManagerEvent -= PlayEndLevelBG;
    }
    private void PlayMainMenuBG()
    {
        PlayClip(_mainMenuBGClip);
    }
    private void PlayLevelBG()
    {
        PlayClip(_levelBGSO.RandomClip());
    }
    private void PlayEndLevelBG()
    {
        PlayClip(_endLevelBGClip);
    }
    private void PlayClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
