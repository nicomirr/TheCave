using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnReloadScene += ReloadScene;
    }

    private void OnDisable()
    {
        GameEvents.OnReloadScene -= ReloadScene;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
