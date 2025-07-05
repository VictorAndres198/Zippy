using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAudio : MonoBehaviour
{
    public AudioClip footstepClip;
    AudioSource src;
    void Awake() => src = GetComponent<AudioSource>();

    // Este método lo seleccionas en el Animation Event
    public void PlayFootstep()
    {
        src.PlayOneShot(footstepClip);
    }
}