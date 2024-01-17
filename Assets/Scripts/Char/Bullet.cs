using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D Rb2;

    
    public float BulletSpeed;
    private void Awake()
    {
        Rb2 = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Rb2.velocity = Vector2.right * BulletSpeed;
        Destroy(gameObject, 1);
    }

    
}
