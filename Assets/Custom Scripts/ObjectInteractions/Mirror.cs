using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour, I_Reflective
{
    bool isMoving = false;
    bool overlapping = false;

    [SerializeField]
    public AudioSource audioSource;
    [SerializeField]
    public AudioClip destroySoundEffect;
    [SerializeField]
    float soundEffectVolume = 0.5f;

    public bool GetIsMoving()
    {
        return isMoving;
    }

    public void SetIsMoving(bool moving)
    {
        PolygonCollider2D colliderComp = GetComponent<PolygonCollider2D>();

        isMoving = moving;


        if (isMoving == true)
        {
            // When moving, don't interact with the photon
            colliderComp.isTrigger = true;
        }
        else
        {
            // When stationary, don't interact with the photon
            colliderComp.isTrigger = false;
            if(overlapping == true)
            {
                audioSource.PlayOneShot(destroySoundEffect, soundEffectVolume);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlapping = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overlapping = false;
    }
}
