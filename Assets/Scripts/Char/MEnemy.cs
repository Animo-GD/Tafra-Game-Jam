using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MEnemy : MonoBehaviour
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
        
        if(SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (Rb2.velocity.y < 0)
            {
                anim.SetBool("Fall", true);
                Rb2.velocity = new Vector2(0, Rb2.velocity.y);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime);
            }
        }
        if (Player)
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.SetActive(false);
            LoseScreen.SetActive(true);
        }
        if(collision.gameObject.CompareTag("DeadLine"))
        {
            Destroy(gameObject);
        }
    }
}
