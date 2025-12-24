using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        if (PauseManager.Instance.GamePaused || !GameManager.Instance.IsRunning) return;        

        this.transform.Translate(new Vector3(-ObstaclesManager.Instance.ObstaclesSpeed, 0, 0) * Time.deltaTime);
    }
}
