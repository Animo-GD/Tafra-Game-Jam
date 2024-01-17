using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexBackground : MonoBehaviour
{
    public ParallaxCamera parallaxCamera;
    List<ParallexLayers> parallaxLayers = new List<ParallexLayers>();



    private void Awake()
    {
        parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
    }
    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;
        SetLayers();
    }

    void SetLayers()
    {
        parallaxLayers.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            ParallexLayers layer = transform.GetChild(i).GetComponent<ParallexLayers>();

            if (layer != null)
            {
                layer.name = "Layer-" + i;
                parallaxLayers.Add(layer);
            }
        }
    }
    void Move(float delta)
    {
        foreach (ParallexLayers layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
}
