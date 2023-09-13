using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OpaqueInteraction : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip soundEffect;
    [SerializeField]
    float soundEffectVolume = 0.3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Photon player = collision.gameObject.GetComponent<Photon>();

        // Ends the game if the photon collides with the object using this script
        if (player != null)
        {
            audioSource.PlayOneShot(soundEffect, soundEffectVolume);
            GameManager.Instance.OnDead();
        }

    }
}
