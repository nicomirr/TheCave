using System;
using UnityEngine;

public static class GameEvents
{
    //Se dispara en ScoreCollider, escucha ScoreManager y ScoreSFX
    public static event Action OnAddScore;

    //Se dispara en PlayerMover, escucha PLayerSFX
    public static event Action OnPlayerJump;

    //Se dispara en PlayerCollisions, escuchan PlayerAnimations y PlayerSFX
    public static event Action OnPlayerDeath;

    //Se dispara en PlayerController, escuchan PauseManager, UIManager, Spawner y PlayerMover
    public static event Action OnDisablePause;

    //Se dispara en UIManager, escucha PlayerController
    public static event Action OnEnableDeadInput;

    //Se dispara en PlayerController, escucha SceneLoader
    public static event Action OnReloadScene;

    //Se dispara en AudioManager, escucha MusicManager
    public static event Action OnMusicOn;

    //Se dispara en AudioManager, escucha MusicManager
    public static event Action OnMusicOff;

    //Se dispara en PlayerController, escucha AudioManager
    public static event Action OnChangeAudio;

    //Se dispara en AudioManager, escucha UIManager
    public static event Action<AudioMode> OnAudioChanged;

    public static void RaiseAddScore()
    {
        OnAddScore?.Invoke();
    }

    public static void RaisePlayerJump()
    {
        OnPlayerJump?.Invoke();
    }

    public static void RaisePlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public static void RaiseDisablePause()
    {
        OnDisablePause?.Invoke();
    }

    public static void RaiseEnableDeadInput()
    {
        OnEnableDeadInput?.Invoke();
    }

    public static void RaiseReloadScene()
    {
        OnReloadScene?.Invoke();
    }

    public static void RaiseMusicOn()
    {
        OnMusicOn?.Invoke();
    }

    public static void RaiseMusicOff()
    {
        OnMusicOff?.Invoke();
    }

    public static void RaiseChangeAudio()
    {
        OnChangeAudio?.Invoke();
    }

    public static void RaiseAudioChanged(AudioMode audioMode)
    {
        OnAudioChanged?.Invoke(audioMode);
    }
}
