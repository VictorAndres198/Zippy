using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryAudio : MonoBehaviour
{
    public AudioClip successClip;
    AudioSource src;
    void Awake() => src = GetComponent<AudioSource>();
    public void playSuccess()
    {
        if (src != null && successClip != null)
            src.PlayOneShot(successClip);
    }
}
