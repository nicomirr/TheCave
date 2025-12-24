
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioClip _jumpSFX;
    [SerializeField] private AudioClip _deathSFX;

    [SerializeField, Range(0f, 1f)] private float _jumpSFXVolumeMod;
    [SerializeField, Range(0f, 1f)] private float _deathSFXVolumeMod;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerJump += PlayJumpSFX;
        GameEvents.OnPlayerDeath += PlayDeathSFX;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerJump -= PlayJumpSFX;
        GameEvents.OnPlayerDeath -= PlayDeathSFX;
    }

    private void PlayJumpSFX()
    {
        _audioSource.PlayOneShot(_jumpSFX, _jumpSFXVolumeMod * AudioManager.Instance.SoundMod);
    }

    private void PlayDeathSFX()
    {
        _audioSource.PlayOneShot(_deathSFX, _deathSFXVolumeMod * AudioManager.Instance.SoundMod);
    }
}
