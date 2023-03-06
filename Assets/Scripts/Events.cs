using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class Events : MonoBehaviour
{
    public GameObject NextLevel;
    public GameObject Pause;
    public CharacterMovement character;
    public bl_Joystick joystick;
    public bool isPaused = false;
    void Start()
    {

    }
    public void Awake()
    {

      
        NextLevel.SetActive(false);
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pausee()
    {
        Pause.SetActive(true);
        isPaused = !isPaused;
       

    }
    public void PlayGame()
    {
        isPaused = false;
        
        Pause.SetActive(false);
    }
    public void UnhideNextLevel()
    {
        this.NextLevel.SetActive(true);
        joystick.gameObject.SetActive(false);

    }
    public void HideNextLevell()
    {
        this.NextLevel.SetActive(false);
    }
    public void ReplayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {

        Application.Quit();
    }
    public void NextLevels()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
