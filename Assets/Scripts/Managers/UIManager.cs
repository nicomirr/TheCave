using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private float _soundAndMusicTextDisplayTime;

    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;


    [SerializeField] private GameObject _clickToStartText;
    [SerializeField] private GameObject _creditsText;
    [SerializeField] private GameObject _clickToRestartText;
    [SerializeField] private GameObject _newHighscoreText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highscoreText;
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private GameObject _mouseImage;
    [SerializeField] private TextMeshProUGUI _soundAndMusicText;

    [SerializeField] private float _endGameRoutineDelayTime = 1;

    private Coroutine _showSoundAndMusicTextRoutine;

    private Image _soundImage;

    private void OnEnable()
    {
        GameEvents.OnDisablePause += EnableInGameUI;
        GameEvents.OnPlayerDeath += EnableEndGameUI;
        GameEvents.OnAudioChanged += EnableMusicAndSoundText;
    }

    private void OnDisable()
    {
        GameEvents.OnDisablePause -= EnableInGameUI;
        GameEvents.OnPlayerDeath -= EnableEndGameUI;
        GameEvents.OnAudioChanged -= EnableMusicAndSoundText;
    }

    private void Start()
    {
        Cursor.visible = false;

        _scoreText.gameObject.SetActive(false);
        _highscoreText.gameObject.SetActive(false);
        _finalScoreText.gameObject.SetActive(false);
        _clickToRestartText.SetActive(false);
        _clickToStartText.SetActive(true);
        _creditsText.gameObject.SetActive(true);
        _mouseImage.SetActive(true);
        _soundAndMusicText.gameObject.SetActive(false);
        DontDestroyUI.Instance.SoundImage.SetActive(true);

        _soundImage = DontDestroyUI.Instance.SoundImage.GetComponent<Image>();
    }

    private void EnableInGameUI()
    {
        _scoreText.gameObject.SetActive(true);
        _highscoreText.gameObject.SetActive(true);
        _clickToStartText.SetActive(false);
        _creditsText.gameObject.SetActive(false);
        _mouseImage.SetActive(false);
        DontDestroyUI.Instance.SoundImage.SetActive(false);
        _soundAndMusicText.gameObject.SetActive(false);
    }

    private void EnableMusicAndSoundText(AudioMode audioMode)
    {
        switch(audioMode)
        {
            case AudioMode.SoundAndMusic:
                _soundAndMusicText.text = "MUSIC: ON  SOUND: ON";
                _soundImage.sprite = _soundOnSprite;
                break;

            case AudioMode.SoundOnly:
                _soundAndMusicText.text = "MUSIC: OFF  SOUND: ON";
                break;

            case AudioMode.MusicOnly:
                _soundAndMusicText.text = "MUSIC: ON  SOUND: OFF";
                break;

            case AudioMode.NoSoundNoMusic:
                _soundAndMusicText.text = "MUSIC: OFF  SOUND: OFF";
                _soundImage.sprite = _soundOffSprite;
                break;
        }

        if (_showSoundAndMusicTextRoutine != null)
        {
            StopCoroutine( _showSoundAndMusicTextRoutine);
        }

        _showSoundAndMusicTextRoutine = StartCoroutine(ShowSoundAndMusicTextRoutine());
    }

    private IEnumerator ShowSoundAndMusicTextRoutine()
    {
        _soundAndMusicText.gameObject.SetActive(true);

        yield return new WaitForSeconds(_soundAndMusicTextDisplayTime);

        _soundAndMusicText.gameObject.SetActive(false);
    }

    private void EnableEndGameUI()
    {
        StartCoroutine(EnableEndGameUIRoutine());
    }

    private IEnumerator EnableEndGameUIRoutine()
    {
        _scoreText.gameObject.SetActive(false);
        _highscoreText.gameObject.SetActive(false);
        yield return new WaitForSeconds(_endGameRoutineDelayTime);

        int score = int.Parse(new string(_scoreText.text.Where(char.IsDigit).ToArray()));
        int highscore = int.Parse(new string(_highscoreText.text.Where(char.IsDigit).ToArray()));

        if (score > highscore)
        {
            _newHighscoreText.gameObject.SetActive(true);
        }

        _finalScoreText.text = "FINAL " + _scoreText.text;
        _finalScoreText.gameObject.SetActive(true);
        yield return new WaitForSeconds(_endGameRoutineDelayTime);

        _clickToRestartText.SetActive(true);
        GameEvents.RaiseEnableDeadInput();
        
    }
}
