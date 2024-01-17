using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P : MonoBehaviour
{

    public GameObject boat;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boat"))
        {
            boat.SetActive(true);
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
