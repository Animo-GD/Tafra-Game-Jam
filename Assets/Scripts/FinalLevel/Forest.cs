using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    private Rigidbody2D PRb2;
    private void Awake()
    {
        PRb2 = Player.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<Animator>().SetFloat("Speed", 3.8f);
    }
    private void Update()
    {
        Player.transform.position +=Vector3.right * Time.deltaTime * speed;
    }
}
