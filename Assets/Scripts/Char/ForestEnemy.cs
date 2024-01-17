using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForestEnemy : MonoBehaviour
{
    public float Movespeed;
    private Animator anim;
    private GameObject Player;
    private Rigidbody2D Rb2;
    private GameObject LoseScreen;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        Player = GameObject.FindGameObjectWithTag("Player");

        Rb2 = GetComponent<Rigidbody2D>();
        LoseScreen = GameObject.FindGameObjectWithTag("Lose");
    }
    private void Update()
    {

        
        if (Player)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * Movespeed);
            anim.SetBool("Run", true);
        }else
        {
            anim.SetBool("Run", false);
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(LoseScreen)
            LoseScreen.SetActive(true);
            collision.gameObject.SetActive(false);
            
        }
        
    }
}
