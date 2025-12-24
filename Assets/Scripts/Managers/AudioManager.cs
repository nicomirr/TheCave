using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private int soundMod;
    public int SoundMod { get { return soundMod; }}

    private static readonly int AUDIO_MODE_COUNT = Enum.GetValues(typeof(AudioMode)).Length;

    private AudioMode _currentAudioMode;

    private bool _isMusicOn =>
        _currentAudioMode == AudioMode.SoundAndMusic ||
        _currentAudioMode == AudioMode.MusicOnly;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        _currentAudioMode = AudioMode.SoundAndMusic;

        EnableSoundAndMusic();
    }

    private void OnEnable()
    {
        if (Instance != this) return;

        GameEvents.OnChangeAudio += ChangeAudioMode;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        if (Instance != this) return;

        GameEvents.OnChangeAudio -= ChangeAudioMode;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMusicStatus();
    }

    private void ChangeAudioMode()
    {
        if((int)_currentAudioMode >= (AUDIO_MODE_COUNT - 1))
        {
            _currentAudioMode = 0;
        }
        else
        {
            _currentAudioMode++;
        }

        switch (_currentAudioMode)
        {
            case AudioMode.SoundAndMusic:
                EnableSoundAndMusic();
                break;

            case AudioMode.SoundOnly:
                EnableSoundOnly();
                break;

            case AudioMode.MusicOnly:
                EnableMusicOnly();
                break;

            case AudioMode.NoSoundNoMusic:
                DisableSoundAndMusic();
                break;
        }

        GameEvents.RaiseAudioChanged(_currentAudioMode);
    }
    private void EnableSoundAndMusic()
    {
        soundMod = 1;
        GameEvents.RaiseMusicOn();
    }

    private void EnableSoundOnly()
    {
        soundMod = 1;
        GameEvents.RaiseMusicOff();
    }

    private void EnableMusicOnly()
    {
        soundMod = 0;
        GameEvents.RaiseMusicOn();
    }

    private void DisableSoundAndMusic()
    {
        soundMod = 0; 
        GameEvents.RaiseMusicOff();
    }

    private void UpdateMusicStatus()
    {
        if(_isMusicOn)
        {
            GameEvents.RaiseMusicOn();
        }
        else
        {
            GameEvents.RaiseMusicOff();
        }
    }
}
