using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private static PauseManager _instance;
    public static PauseManager Instance {  get { return _instance; } }

    private bool _gamePaused;
    public bool GamePaused { get { return _gamePaused; } }

    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        GameEvents.OnDisablePause += UnfreezeGame;
    }

    private void OnDisable()
    {
        GameEvents.OnDisablePause -= UnfreezeGame;
    }

    private void Start()
    {
        _gamePaused = true;
    }

    private void UnfreezeGame()
    {
        _gamePaused = false;
    }

}
