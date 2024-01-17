using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream : MonoBehaviour
{
    private void Awake()
    {
        Destroy(GameObject.Find("MusicManager"));
    }
}
