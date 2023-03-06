using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Time to display the splash screen in seconds
    public float splashTime = 3.0f;

    // The name of the scene to load after the splash screen
    public string nextSceneName = "MainMenu";

    void Start()
    {
        // Load the next scene after the splash time has elapsed
        Invoke("LoadNextScene", splashTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}