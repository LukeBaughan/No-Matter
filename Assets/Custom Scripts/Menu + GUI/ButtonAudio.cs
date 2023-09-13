using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundEffect;

    public void playSound()
    {
        audioSource.PlayOneShot(soundEffect);
        DontDestroyOnLoad(audioSource);
    }
}
