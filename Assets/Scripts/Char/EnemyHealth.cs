using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int Health = 100;
    public GameObject Blood;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Health -= 50;
            Instantiate(Blood, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if(Health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
