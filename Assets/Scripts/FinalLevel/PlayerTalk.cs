using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerTalk : MonoBehaviour
{
    public GameObject Transition;
    public void transition()
    {
        Transition.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
