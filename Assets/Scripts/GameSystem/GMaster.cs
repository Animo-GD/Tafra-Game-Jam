using UnityEngine;
using UnityEngine.SceneManagement;

public class GMaster : MonoBehaviour
{
    public GameObject transition;
    public GameObject SaveScreen;

    public GameObject Explosion;
    public GameObject[] Ground;
    public GameObject Player;
    public GameObject LoseScreen;
    public GameObject w2;

    
    void LastUpdate()
    {
        LeanTween.alpha(transition, 0, 4);
    }

    private void Update()
    {
        if(!Explosion && Ground[0] && Ground[1])
        {
            Destroy(w2);
            Ground[0].SetActive(false);
            Ground[1].SetActive(true);
        }
        if(!Player.activeInHierarchy)
        {
            LoseScreen.SetActive(true);
        }

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SScreen()
    {
        if(SaveScreen.activeInHierarchy)
        {
            LeanTween.scale(SaveScreen, new Vector3(0, 0, 1), .5f);
            SaveScreen.SetActive(false);
        }else if(!SaveScreen.activeInHierarchy && !Input.GetKeyDown(KeyCode.Space))
        {
            LeanTween.scale(SaveScreen, new Vector3(14, 14, 1), .5f);
            SaveScreen.SetActive(true);
        }
       
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
