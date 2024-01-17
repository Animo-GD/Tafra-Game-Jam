using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3 : MonoBehaviour
{

    public AudioSource chasesound;
    public GameObject FEnemy;
    public Transform EPos;

    private float timer = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer -= Time.deltaTime;
        if(collision.gameObject.CompareTag("Player") && timer > 0)
        {
            chasesound.Play();
            InvokeRepeating("wave3", 1, .5f);
            InvokeRepeating("wave3",2, 1);
        }


        
    }
    void wave3()
    {
        Instantiate(FEnemy, EPos.position, EPos.rotation);
    }
}
