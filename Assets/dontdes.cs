using UnityEngine.SceneManagement;
using UnityEngine;

public class dontdes : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(gameObject);
            
    }
    
}
