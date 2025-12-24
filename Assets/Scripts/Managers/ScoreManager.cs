using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private TextMeshProUGUI _highScoreText;

    private const string HIGH_SCORE_KEY = "HIGHSCORE";

    private int _score;

    private int _highscore;

    private void OnEnable()
    {
        _highscore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        _highScoreText.text = "HIGHSCORE: " + _highscore;

        GameEvents.OnAddScore += AddScore;
        GameEvents.OnPlayerDeath += TrySetHighscore;
    }

    private void OnDisable()
    {
        GameEvents.OnAddScore -= AddScore;
        GameEvents.OnPlayerDeath -= TrySetHighscore;
    }

    private void Start()
    {
        _score = 0;
        UpdateScore();
    }

    public void AddScore()
    {
        _score++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        _scoreText.text = "SCORE: " + _score.ToString();
    }

    private void TrySetHighscore()
    {
        if (_score <= _highscore) return;

        _highscore = _score;

        PlayerPrefs.SetInt(HIGH_SCORE_KEY, _highscore);
        PlayerPrefs.Save();
    }
}
