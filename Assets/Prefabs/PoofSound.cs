using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofSound : MonoBehaviour
{
    public AudioClip poofClip;
    AudioSource src;
    void Awake() => src = GetComponent<AudioSource>();
    public void playPoof()
    {
        if (src != null && poofClip != null)
            src.PlayOneShot(poofClip);
    }
}
