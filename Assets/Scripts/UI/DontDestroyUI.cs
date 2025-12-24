using UnityEngine;
using UnityEngine.UIElements;

public class DontDestroyUI : MonoBehaviour
{
    public static DontDestroyUI Instance{get; private set;}

    [SerializeField] private GameObject _soundImage;
    public GameObject SoundImage => _soundImage;   

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
