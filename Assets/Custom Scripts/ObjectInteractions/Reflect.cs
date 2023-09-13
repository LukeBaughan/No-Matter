using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Reflect : MonoBehaviour
{
    [SerializeField]
    public AudioSource audioSource;
    [SerializeField]
    public AudioClip soundEffect;
    [SerializeField]
    float soundEffectVolume = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (GetMirrorMoving() == false)
            {
                Photon player = collision.gameObject.GetComponent<Photon>();

                // Executes if photon collides with the reflective object AND if the object is stationary
                if (player != null)
                {
                    // Reflects photon and play a sound effect
                    player.direction = Vector2.Reflect(player.direction, collision.contacts[0].normal);
                    audioSource.PlayOneShot(soundEffect, soundEffectVolume);
                }
            }
        
    }

    // Gets if the reflective objects is being moved by the player
    private bool GetMirrorMoving()
    {
        I_Reflective reflectiveObject = gameObject.GetComponent<Mirror>() as I_Reflective;
        if (reflectiveObject != null)
        {
            return reflectiveObject.GetIsMoving();
        }
        else
        {
            return false;
        }
    }
}
