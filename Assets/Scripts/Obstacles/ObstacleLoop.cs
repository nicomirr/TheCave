using UnityEngine;

public class ObstacleLoop : MonoBehaviour
{
    [SerializeField] private float _intialXPos;
    [SerializeField] private float _finalXPos;

    private void Update()
    {
        if (!GameManager.Instance.IsRunning) return;

        MoveObstacle();
        ResetObstaclePosition();
               
    }

    private void MoveObstacle()
    {
        this.transform.Translate(new Vector3(-ObstaclesManager.Instance.ObstaclesSpeed, 0, 0) * Time.deltaTime);
    }

    private void ResetObstaclePosition()
    {
        if (this.transform.position.x <= _finalXPos)
        {
            this.transform.position = new Vector3(_intialXPos, this.transform.position.y, this.transform.position.z);
        }
    }
}
