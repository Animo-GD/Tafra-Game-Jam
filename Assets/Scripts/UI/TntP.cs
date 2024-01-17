using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TntP : MonoBehaviour
{
    
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BridgePoint") && Input.GetMouseButtonDown(0))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
