using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float WalkSpeed, RunSpeed, JumpSpeed;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask Ground;

    private bool IsGrounded;
    private float speed;
    private Rigidbody2D Rb2;
    private Animator Anim;
    private float HI;
    private bool FacingRight = true;
    public bool LevelEnded = false;
    public GameObject PFText;
    public GameObject BlackScreen;
    public Animator RDAnim;
    public GameObject Cnv;
    public GameObject Tourch;

    public GameObject CoversationScreen;
    public GameObject redeye;

    public GameObject Cam;

    public GameObject CamHolder;
    private bool chasing;
    public GameObject LoseScreen;

    private void Awake()
    {
        Rb2 = this.GetComponent<Rigidbody2D>();
        Anim = this.GetComponent<Animator>();
    }
    private void Start()
    {
        speed = WalkSpeed;
    }
    private void Update()
    {
        if (!LevelEnded)
        {


            HI = Input.GetAxis("Horizontal");
            Rb2.velocity = new Vector2(HI * speed * Time.fixedDeltaTime, Rb2.velocity.y);



            if (FacingRight && Rb2.velocity.x < 0)
            {
                Flip();
            }
            else if (!FacingRight && Rb2.velocity.x > 0)
            {
                Flip();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = RunSpeed;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = WalkSpeed;
            }
            

            // Jump
            IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);

            if (IsGrounded && Input.GetButtonDown("Jump"))
            {
                Rb2.velocity = Vector2.up * JumpSpeed * Time.fixedDeltaTime;

            }
            
        }else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            EndLevel();
        }
        Anim.SetFloat("Speed", Mathf.Abs(Rb2.velocity.x));
        Anim.SetFloat("JumpingSpeed", Mathf.Abs(Rb2.velocity.y));

        if(chasing)
        {
            Camera.main.GetComponent<Animator>().SetTrigger("Shake");
            redeye.SetActive(true);
        }
    }
       
    void Flip()
    {
        
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("End"))
        {
            LevelEnded = true;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if(collision.gameObject.CompareTag("ToNextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("Phone"))
        {
            LevelEnded = true;
            CoversationScreen.SetActive(true);
        }

        if(collision.gameObject.CompareTag("DeadLine"))
        {
            LoseScreen.SetActive(true);
            gameObject.SetActive(false);

        }

        if(collision.gameObject.CompareTag("EndBridge") && !GameObject.FindGameObjectWithTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(collision.gameObject.CompareTag("Trap"))
        {
            gameObject.SetActive(false);
            LoseScreen.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Bed"))
        {
            Anim.SetBool("GoToBed", true);
            BScreen();
        }
        if (collision.gameObject.CompareTag("TNT") && !GameObject.FindGameObjectWithTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Desk"))
        {
            LeanTween.alpha(PFText, 0, 1);
            RDAnim.SetBool("RDApear", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PrsF"))
        {
            LeanTween.alpha(PFText, 1, .5f);
        }
        
        if(collision.gameObject.CompareTag("Tourch"))
        {
            Destroy(collision.gameObject);
            Tourch.SetActive(true);

        }
        
        if(collision.gameObject.CompareTag("EndLevel2"))
        {
            CamHolder.transform.position = new Vector3(61.2f, 0,-10);
            Camera.main.GetComponent<Animator>().enabled = false;
            Cam.SetActive(false);
        }

        if(collision.gameObject.CompareTag("First Chasing"))
        {
            
            chasing = true;
            collision.GetComponent<AudioSource>().Play();
        }
        
        
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EndBed"))
        {
            EndLevel();
        }
        if(collision.gameObject.CompareTag("PrsF"))
        {
            if(Input.GetKeyDown(KeyCode.F))
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        if (collision.gameObject.CompareTag("Desk"))
        {

            LeanTween.alpha(PFText, 1, 2);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Cnv.SetActive(true);
                LeanTween.alpha(PFText, 0, 2);
            }

        }
        
    }

    public void BScreen()
    {
        LeanTween.alpha(BlackScreen, 1, 2);
        Invoke("NextLevel",4);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void EndLevel()
    {

        Rb2.velocity = Vector2.right * Time.fixedDeltaTime * (50);
        LevelEnded = true;
    }



}
