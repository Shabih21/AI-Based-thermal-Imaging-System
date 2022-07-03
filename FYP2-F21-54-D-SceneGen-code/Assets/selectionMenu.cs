using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    private GameObject[] objectlist;

    //select a specific object from the menu
    private void Start()
    {
        objectlist = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            objectlist[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in objectlist)
            go.SetActive(false);
    }
}
