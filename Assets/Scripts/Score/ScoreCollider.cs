using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Looper>()) return;

        GameEvents.RaiseAddScore();
    }
}
