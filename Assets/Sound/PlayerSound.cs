using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] clip;
    
    private AudioSource As;
    private Rigidbody2D rb2;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        As = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if(Mathf.Abs(rb2.velocity.x) <= 2 && Mathf.Abs(rb2.velocity.x) > 0)
        {
            As.clip = clip[0];
            As.Play();
        }else if(rb2.velocity.x == 0)
        {
            As.Stop();
        }
        
    }

}
