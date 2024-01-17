using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public GameObject Tourch;
    public GameObject Gun;
    private Rigidbody2D rb2;
    private Animator anim;

    public GameObject Bullet;
    public Transform FirePoint;
    public GameObject FlashLigher;
    public LayerMask Enemy;
    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Gun && Tourch)
        {


            if (Tourch.activeInHierarchy)
            {
                anim.SetBool("CarryTourch", true);
                anim.SetBool("CarryGun", false);
            }
            else if (Gun.activeInHierarchy)
            {
                anim.SetBool("CarryGun", true);
                anim.SetBool("CarryTourch", false);
            }

            //Switching

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Tourch.activeInHierarchy)
                {
                    Tourch.SetActive(false);
                    Gun.SetActive(true);
                }
                else if (Gun.activeInHierarchy)
                {
                    Gun.SetActive(false);
                    Tourch.SetActive(true);
                }
            }

            //Gun
            if (Input.GetKeyDown(KeyCode.K) && Gun.activeInHierarchy && Mathf.Abs(rb2.velocity.x) > .01f)
            {
                Instantiate(FlashLigher, FirePoint.position, FirePoint.rotation);
                GameObject temp = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                temp.GetComponent<Rigidbody2D>().velocity = transform.right * 20;
                Destroy(temp, 2);

            }
        }
        
    }
}
