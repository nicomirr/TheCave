using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _obstaclesSpawnPoints;
    [SerializeField] private Transform _scoreColliderSpawnPoint;

    [SerializeField] private Obstacle[] _smallObstacles;
    [SerializeField] private Obstacle[] _mediumObstacles;
    [SerializeField] private Obstacle[] _largeObstacles;
    
    private float _delayTime;

    private int _totalObstacleTypes;
    private int _randomObstacleIndex;
    private int _randomSpawnPointIndex;
    private ObstacleType _randomObstacleType;

    private SpawnPoint _currentSpawnPoint;
    private Obstacle _currentObstacle;


    private void OnEnable()
    {
        GameEvents.OnDisablePause += BeginObstaclesRoutine;
    }

    private void OnDisable()
    {
        GameEvents.OnDisablePause -= BeginObstaclesRoutine;
    }

    private void Start()
    {
        _totalObstacleTypes = Enum.GetValues(typeof(ObstacleType)).Length;        
    }

    private void BeginObstaclesRoutine()
    {
        StartCoroutine(SpawnObstaclesRoutine());
    }

    private IEnumerator SpawnObstaclesRoutine()
    {        
        while(true)
        {            
            if (!GameManager.Instance.IsRunning)
                break;

            _delayTime = UnityEngine.Random.Range(ObstaclesManager.Instance.MinDelayTime, ObstaclesManager.Instance.MaxDelayTime);
            _randomSpawnPointIndex = UnityEngine.Random.Range(0, _obstaclesSpawnPoints.Length);
            _currentSpawnPoint = _obstaclesSpawnPoints[_randomSpawnPointIndex];

            _randomObstacleType = (ObstacleType)UnityEngine.Random.Range(0, _totalObstacleTypes);

            switch (_randomObstacleType)
            {
                case ObstacleType.Small:
                    SpawnObstacle(_smallObstacles);
                    break;

                case ObstacleType.Medium:
                    SpawnObstacle(_mediumObstacles);
                    break;

                case ObstacleType.Large:
                    SpawnObstacle(_largeObstacles);
                    break;
            }

            yield return new WaitForSeconds(_delayTime);
        }
    }

    private void SpawnObstacle(Obstacle[] obstacles)
    {
        bool obstacleFound = false;
        
        while (!obstacleFound)
        {
            _randomObstacleIndex = UnityEngine.Random.Range(0, obstacles.Length);
            _currentObstacle = obstacles[_randomObstacleIndex];

            if (!_currentObstacle.gameObject.activeSelf)
            {
                if(_currentSpawnPoint.Location == SpawnPointLocation.Upper)
                {
                    _currentObstacle.transform.localScale = Vector3.one;
                }
                else
                {
                    _currentObstacle.transform.localScale = new Vector3(1, -1, 1);
                }

                _currentObstacle.gameObject.transform.position =
                        _currentSpawnPoint.gameObject.transform.position;

                _currentObstacle.gameObject.SetActive(true);

                obstacleFound = true;
            }
        }
    }   
}
