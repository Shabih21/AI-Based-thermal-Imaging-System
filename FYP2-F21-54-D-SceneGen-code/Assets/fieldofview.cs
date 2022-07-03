using UnityEngine;
using System.Collections;

public class fiekdofview : MonoBehaviour
{
    //setting the field of view
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[10] = 15;
        camera.layerCullDistances = distances;
    }
}