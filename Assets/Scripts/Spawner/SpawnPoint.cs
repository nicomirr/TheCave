using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private SpawnPointLocation _location;
    public SpawnPointLocation Location { get { return _location; } }

}
