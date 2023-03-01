using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject characters;
    public GameObject bed;
    public GameObject endScene;
    public CharacterMovement character;
    public ParticleSystem particleEffect;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == characters && character.isHoldingToy)
        {
            Debug.Log("You win!");
            FindObjectOfType<AudioManager>().PlaySound("Win");

            if (particleEffect != null) // Check if the particle effect reference is not null
            {
                FindObjectOfType<AudioManager>().PlaySound("Collide");
                // Instantiate the particle effect at the current position and rotation of the wall
                ParticleSystem effect = Instantiate(particleEffect, transform.position, transform.rotation);
                // Set the effect to play and destroy itself after it has finished playing
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
            }
            characters.gameObject.SetActive(false);
            endScene.SetActive(true);
            Invoke(nameof(ShowCompletePanel), 5f);
        }
    }

    void ShowCompletePanel()
    {
        // Show Complete Panel
    }
}