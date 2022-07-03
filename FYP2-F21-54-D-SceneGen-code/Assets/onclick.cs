using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclick : MonoBehaviour
{
    private Vector3[] array = new Vector3[10];
    int count = 0;
    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            array[count] = Input.mousePosition;
            count++;
        }
    }
}
