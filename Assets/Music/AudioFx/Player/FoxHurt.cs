using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxHurt : MonoBehaviour
{
    public AudioClip hurtfoxClip;
    private AudioSource src;
    private bool hasPlayed = false;  // Protección

    void Awake() => src = GetComponent<AudioSource>();

    public void PlayHurtFox()
    {
        if (!hasPlayed)
        {
            src.PlayOneShot(hurtfoxClip);
            hasPlayed = true;
        }
    }

    // Llama esto desde tu PlayerController cuando termine el estado hurt
    public void ResetHurtSound()
    {
        hasPlayed = false;
    }
}