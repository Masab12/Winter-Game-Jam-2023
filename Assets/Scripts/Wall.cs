using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject connectedWall;
    public string wallTag;
    public ParticleSystem particleEffect;
    public ParticleSystem particleEffect2;// Add a reference to the particle system

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(wallTag))
        {
            
            connectedWall.SetActive(false);
            gameObject.SetActive(false);
            if (particleEffect != null) // Check if the particle effect reference is not null
            {
                FindObjectOfType<AudioManager>().PlaySound("Collide");
                // Instantiate the particle effect at the current position and rotation of the wall
                ParticleSystem effect = Instantiate(particleEffect, transform.position, transform.rotation);
                // Set the effect to play and destroy itself after it has finished playing
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
            }
            if (particleEffect != null) // Check if the particle effect reference is not null
            {
                // Instantiate the particle effect at the current position and rotation of the wall
                ParticleSystem effect = Instantiate(particleEffect2, transform.position, transform.rotation);
                // Set the effect to play and destroy itself after it has finished playing
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
            }
        }
    }
}