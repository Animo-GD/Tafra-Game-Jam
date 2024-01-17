using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2 : MonoBehaviour
{
    public GameObject[] Enemy;
    public Transform EnemyPos;
    public Transform EPos2;
    public AudioSource As;
    void Start()
    {
        As.Play();
        InvokeRepeating("wave2", 2, .4f);
        StartCoroutine(wave3());
    }

    void wave2()
    {

        Instantiate(Enemy[0], EnemyPos.position, EnemyPos.rotation);
        
    }

    IEnumerator wave3()
    {
        Instantiate(Enemy[1], EPos2.position, EPos2.rotation);
        yield return new WaitForSeconds(4f);
        Instantiate(Enemy[1], EPos2.position, EPos2.rotation);
        yield return new WaitForSeconds(4f);
        Instantiate(Enemy[1], EPos2.position, EPos2.rotation);
        yield return new WaitForSeconds(4f);
        Instantiate(Enemy[1], EPos2.position, EPos2.rotation);
        yield return new WaitForSeconds(4f);
        Instantiate(Enemy[1], EPos2.position, EPos2.rotation);
        yield return new WaitForSeconds(4f);
        Instantiate(Enemy[1], EPos2.position, EPos2.rotation);
        yield return new WaitForSeconds(4f);
        Instantiate(Enemy[1], EPos2.position, EPos2.rotation);
    }
}
