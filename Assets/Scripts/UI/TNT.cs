
using UnityEngine;

public class TNT : MonoBehaviour
{
    public GameObject tntprefab;
    private Vector2 mouspos;



    
    public void tnt()
    {
        Instantiate(tntprefab, mouspos, Quaternion.identity);
    }
    private void Update()
    {
        mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
}
