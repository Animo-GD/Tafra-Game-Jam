using UnityEngine.SceneManagement;
using UnityEngine;

public class UIMger : MonoBehaviour
{

    public GameObject PauseScreen;

    private bool gameIsPaused;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                PauseScreen.SetActive(false);
                Time.timeScale = 1;

                gameIsPaused = false;
            }else if(!gameIsPaused)
            {
                PauseScreen.SetActive(true);
                Time.timeScale = 0;
                gameIsPaused = true;
            }
        }

    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
