using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectObjects : MonoBehaviour
{
    private GameObject[] objectlist;
    int index = 0;

    private void Start()
    {   //getting which object is selected
        index = PlayerPrefs.GetInt("objectselected");
        objectlist = new GameObject[transform.childCount];

        //displaying them in a loop
        for (int i = 0; i < transform.childCount; i++)
        {
            objectlist[i] = transform.GetChild(i).gameObject;
        }

        //setting all objects to false except one
        foreach (GameObject go in objectlist)
            go.SetActive(false);

        if(objectlist[index])
        objectlist[index].SetActive(true);
    }

    //toggle left
    public void toggleleft()
    {
        objectlist[index].SetActive(false);

        index--;
        if (index < 0)
            index = objectlist.Length - 1;

        objectlist[index].SetActive(true);

    }

    //toggle right
    public void toggleright()
    {
        objectlist[index].SetActive(false);

        index++;
        if (index == objectlist.Length)
            index = 0;

        objectlist[index].SetActive(true);

    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("objectselected", index);
        SceneManager.LoadScene(1);

    }

}
