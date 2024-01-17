using UnityEngine.SceneManagement;
using UnityEngine;

public class Boatanim : MonoBehaviour
{
    public GameObject EndSceneScreen;
   public void EndScene()
    {
        EndSceneScreen.SetActive(true);  
    }
}
