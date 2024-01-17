using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{

    public GameObject Enemy;
    public Transform EnemyPos;
    public AudioSource As;

    private void Update()
    {
        Enemy.GetComponent<Animator>().SetBool("Fall", false);
    }

    IEnumerator wave1()
    {

        As.Play();
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
        yield return new WaitForSeconds(.4f);
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
        yield return new WaitForSeconds(.5f);
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
        yield return new WaitForSeconds(.3f);
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
        yield return new WaitForSeconds(.6f);
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
        yield return new WaitForSeconds(.4f);
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
        yield return new WaitForSeconds(.2f);
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
        yield return new WaitForSeconds(.5f);
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(wave1());
            
        }
    }
}
