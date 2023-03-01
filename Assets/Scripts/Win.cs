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

              
             
                ParticleSystem effect = Instantiate(particleEffect, transform.position, transform.rotation);
                
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
            
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