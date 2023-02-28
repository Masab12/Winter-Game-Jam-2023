using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int collectiblesCollected = 0;
    public int totalCollectibles = 0;

    public GameObject player;
    public Transform startingPoint;
    private int collectedObjects;

    private bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        player.transform.position = startingPoint.position;
    }

    public void CollectObject(GameObject obj)
    {
        collectiblesCollected++;
        if (collectiblesCollected == totalCollectibles)
        {
            GameOver(true);
        }
    }

    public void GameOver(bool hasWon)
    {
        if (!isGameOver)
        {
            isGameOver = true;
            if (hasWon)
            {
                Debug.Log("You have won the game!");
            }
            else
            {
                Debug.Log("You have lost the game.");
            }
           
        }
    }
}