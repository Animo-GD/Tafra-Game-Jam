using UnityEngine.SceneManagement;
using UnityEngine;

public class DScript : MonoBehaviour
{

    public void DActive()
    {
        gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
