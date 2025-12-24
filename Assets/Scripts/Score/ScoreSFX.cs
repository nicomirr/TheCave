using UnityEngine;

public class ScoreSFX : MonoBehaviour
{
    [SerializeField] private AudioClip _scoreSFX;
    [SerializeField, Range(0,1)] private float _scoreSFXVolumeMod;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameEvents.OnAddScore += PlayScoreSFX;
    }

    private void OnDisable()
    {
        GameEvents.OnAddScore -= PlayScoreSFX;
    }

    private void PlayScoreSFX()
    {
        _audioSource.PlayOneShot(_scoreSFX,_scoreSFXVolumeMod * AudioManager.Instance.SoundMod);
    }

}
