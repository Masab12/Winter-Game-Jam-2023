using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject connectedWall;
    public string wallTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(wallTag))
        {
            Debug.Log("Tags match");
            connectedWall.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}