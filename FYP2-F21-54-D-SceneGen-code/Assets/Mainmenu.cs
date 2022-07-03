using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    //Load the scene
    public int var;
    public void PlayGame(int var)
    {
        SceneManager.LoadScene(var);
    }
}
