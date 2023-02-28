using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameManager gameManager;

    public int pointValue = 10;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CollectObject(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}