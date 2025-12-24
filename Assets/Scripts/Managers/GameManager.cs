using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get {  return _instance; } }

    private bool _isRunning;
    public bool IsRunning { get { return _isRunning; } }

    private void Awake()
    {
        _instance = this;
        _isRunning = true;
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerDeath += StopGame;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDeath -= StopGame;
    }

    private void StopGame()
    {
        _isRunning = false;
    }
}
