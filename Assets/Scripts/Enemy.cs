using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;
    protected AudioSource audioSource;
    
    public AudioClip poofSound;  // Asignar en el Inspector

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent <Animator>();
        rb = GetComponent <Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // Reproduce el sonido poof
        if (audioSource != null && poofSound != null)
            audioSource.PlayOneShot(poofSound);
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
