using System.Collections;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] private float _speedUpWaitTime = 45f;

    [SerializeField] private float _initialObstaclesSpeed = 5;
    [SerializeField] private float _finalObstaclesSpeed = 10;

    [SerializeField] private float _initialMinDelayTime = 1.3f;
    [SerializeField] private float _finalMinDelayTime = 0.8f;

    [SerializeField] private float _initialMaxDelayTime = 1.7f;
    [SerializeField] private float _finalMaxDelayTime = 1.2f;


    private static ObstaclesManager _instance;
    public static ObstaclesManager Instance { get { return _instance; } }


    [SerializeField] private float _obstaclesSpeed;
    public float ObstaclesSpeed { get { return _obstaclesSpeed; } }

    [SerializeField] private float _minDelayTime;
    public float MinDelayTime { get { return _minDelayTime; } }

    [SerializeField] private float _maxDelayTime;
    public float MaxDelayTime { get { return _maxDelayTime; } }



    private void Awake()
    {
        _instance = this;

        _obstaclesSpeed = _initialObstaclesSpeed;
        _minDelayTime = _initialMinDelayTime;
        _maxDelayTime = _initialMaxDelayTime;
    }

    private void Start()
    {
        StartCoroutine(IncreaseObstacleSpeedRoutine());
    }

    private IEnumerator IncreaseObstacleSpeedRoutine()
    {
        while (_obstaclesSpeed < _finalObstaclesSpeed ||
            _minDelayTime > _finalMinDelayTime ||
            _maxDelayTime > _finalMaxDelayTime)
        {
            while (PauseManager.Instance.GamePaused)
                yield return null;


            yield return new WaitForSeconds(_speedUpWaitTime);

            if (_obstaclesSpeed < _finalObstaclesSpeed)
            {
                _obstaclesSpeed++;
            }

            if (_minDelayTime > _finalMinDelayTime)
            {
                _minDelayTime -= 0.1f;
            }

            if (_maxDelayTime > _finalMaxDelayTime)
            {
                _maxDelayTime -= 0.1f;
            }

        }
        
    }
}
