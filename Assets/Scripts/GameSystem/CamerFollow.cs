using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public GameObject Player;
    public float CameraSpeed;
    public Vector3 Offset;
    public float MaxX,MinX;

    
    void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, MinX, MaxX),transform.position.y);
        Vector3 Pos = new Vector3(Player.transform.position.x,0,0) + Offset;
        Vector3 FinalPositoin = Vector3.Lerp(transform.position, Pos, CameraSpeed);
        if(Player != null)
        {
            
            transform.position = FinalPositoin;
        }
        
    }
    
}
