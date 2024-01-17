using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesFollowTheplayer : MonoBehaviour
{
    public GameObject LoseScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            LoseScreen.SetActive(true);
            LeanTween.alpha(LoseScreen, 1, .5f);
        }
    }
}
