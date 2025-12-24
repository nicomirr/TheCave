using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerDeath += DisableMusic;
        GameEvents.OnMusicOn += UnmuteMusic;
        GameEvents.OnMusicOff += MuteMusic;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDeath -= DisableMusic;
        GameEvents.OnMusicOn -= UnmuteMusic;
        GameEvents.OnMusicOff -= MuteMusic;
    }

    private void Start()
    {
        if(!_audioSource.isPlaying)
            _audioSource.Play();
    }

    private void DisableMusic()
    {
        _audioSource.Stop(); 
    }

    private void MuteMusic()
    {
        _audioSource.volume = 0;
    }

    private void UnmuteMusic()
    {
        _audioSource.volume = 1;
    }
}
