
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private GameObject musicManager;
    private AudioSource AS;
    private PlayerMovement PM;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if(!musicManager)
        {
            musicManager = this.gameObject;
            
        }else
        {
            Destroy(musicManager);
        }

        if(musicManager)
            DontDestroyOnLoad(musicManager);
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
         if(PM.LevelEnded == true)
        {
            Fadeout();
        }else if(PM.LevelEnded == false)
        {
            Fadein();
        }
        
    }
    void Fadein()
    {
        
        AS.volume += .005f;
    }
    void Fadeout()
    {
        AS.volume -= .005f;
    }
}
