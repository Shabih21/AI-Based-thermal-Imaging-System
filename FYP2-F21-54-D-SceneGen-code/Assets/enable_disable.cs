using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable_disable : MonoBehaviour
{
    public bool on = false;

    //function to swicth IR camera on/off
    public void set_on_of()
    {
        if(on==true)
        {
            on = false;
        }
        else if(on==false)
        {
            on = true;
        }
    }
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if on turn off
        if(on == false)
        {
            GetComponent<OldCinemaEffect>().enabled = false;
        }
        //if off turn on
        else if(on == true)
        {
            GetComponent<OldCinemaEffect>().enabled = true;
        }       
    }
}
