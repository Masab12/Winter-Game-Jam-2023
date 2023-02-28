using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject characters;
    public GameObject bed;
    public CharacterMovement character;

    

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject == characters && character.isHoldingToy)
        {
            Debug.Log("You win!");
            // Add any win condition logic you need here
        }
    }
}