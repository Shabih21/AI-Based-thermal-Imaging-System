using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;
using TMPro;
using System.IO;


public class rockettarget2 : MonoBehaviour
{
    //public variabels
    private Transform rocketTarget;
    public GameObject LaunchPanel;
    public GameObject Particle;
    //public Transform target;
    public Transform[] target_list;
    public Rigidbody rocketRigidbody;
    public Transform obj;
    public float turn;
    public float rocketVelocity;
    private const float minDistance = 95f;
    private const float particle_distance = 390f;
    float distance;
    public  TextMeshProUGUI dist;
    public AudioSource audio_source;
    public AudioClip clip;
    private int index;
    int word_count=0;
    public GameObject endpanel;

    public int file_num; 
    private int line_count=0;

    private Vector3[] array;
    int count;
    int count_1 = 0;

    bool check = false;

    //for setting which file to read
    public void empire_state(int num)
    {
        index = num;
    }

    public void metlife(int num)
    {
        index = num;
    }

    //[MenuItem("Tools/Read file")]
    //called once
    public void Start()
    {
       
        //string path = "Assets/Resources/test.txt";

        //path of the txt file
         var fullPath = "C:/Users/HP/Desktop/FYP/Newyork_flight_simulation.txt";
        

        //Newyork
        if(file_num==1)
        {
            fullPath = "C:/Users/HP/Desktop/FYP/Newyork_flight_simulation.txt";
            Debug.Log("NewYork");
        }

        //London
        else if(file_num==2)
        {
            fullPath = "C:/Users/HP/Desktop/FYP/London_flight_simulation.txt";
            Debug.Log("London");
        }

        //chakri
        else if(file_num==3)
        {
            fullPath = "C:/Users/HP/Desktop/FYP/Chakri_flight_simulation.txt";
            Debug.Log("Chakri");
        }

        else{
            fullPath = "C:/Users/HP/Desktop/FYP/Chakri_flight_simulation.txt";
        }

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(fullPath); 
        string file_content = reader.ReadToEnd();

        //splitting on the basis of space
        string[] words = file_content.Split('\n',' ');
        
        //counting the lines
        for(int i=0;i<file_content.Length;i++)
        {
            if(file_content[i]=='\n')
            {
                line_count++;
            }
        }
        array = new Vector3[line_count];
        //array[0] = new Vector3(52321f, 4427f, 7381f);

        int count_words = 0;
        count = line_count;
        Debug.Log(count);
        

        //storing the positions in an array
        for(int i=0;i<line_count;i++)
        {
            //(float) Convert.ToDouble((float.Parse(words[count_words]),CultureInfo.InvariantCulture.NumberFormat), (float.Parse(words[count_words+1]),CultureInfo.InvariantCulture.NumberFormat), float.Parse(words[count_words+2],CultureInfo.InvariantCulture.NumberFormat)));
            array[i] = new Vector3(float.Parse(words[count_words], CultureInfo.InvariantCulture.NumberFormat),float.Parse(words[count_words+1], CultureInfo.InvariantCulture.NumberFormat),float.Parse(words[count_words+2], CultureInfo.InvariantCulture.NumberFormat));
            count_words+=3;
            Debug.Log(array[i]);
        }



        //Debug.Log(line_count);

        reader.Close();

    }

    //update called on regular intervals
    public void Update()
    {

         //selecting the target from the list
         distance = Vector3.Distance (target_list[index].position, rocketRigidbody.transform.position);
         dist.text = "Distance: " + (distance-94).ToString();
         //Debug.Log(distance-55);
        if (check == false)
        {
            // if (Input.GetMouseButtonDown(0))
            // {
            //     //Debug.Log(Input.mousePosition);
            // }
        }
        else
        {
            //array[0] = new Vector3(1137f, 4000f, 11557f);
            //Debug.Log(Input.mousePosition);
            //count = 1;

            //Until all the positions in the file are reached
            if (count_1 < count)
            {
                rocketTarget = obj;
                rocketTarget.position = array[count_1];

                if ((transform.position - rocketTarget.transform.position).sqrMagnitude > minDistance * minDistance)
                {
                    rocketRigidbody.velocity = transform.forward * rocketVelocity;
                    var rocketTargetRotation = Quaternion.LookRotation(rocketTarget.position - transform.position);
                    rocketRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turn));
                }
                else
                {
                    count_1++;
                }

            }
            //rocket target becomes actual target
            else
            {
                //Debug.Log("hello");
                //rocketTarget = target_list[1];
                rocketTarget = target_list[index];
                if ((transform.position - rocketTarget.transform.position).sqrMagnitude > minDistance * minDistance)
                {
                    rocketRigidbody.velocity = transform.forward * rocketVelocity;
                    var rocketTargetRotation = Quaternion.LookRotation(rocketTarget.position - transform.position);
                    rocketRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turn));
                    if(!((transform.position - rocketTarget.transform.position).sqrMagnitude > (particle_distance * particle_distance)))
                    {
                        audio_source.PlayOneShot(clip);
                        Particle.SetActive(true);
                        rocketTarget.gameObject.SetActive(false);
                    }

                }
                else
                {
                    Time.timeScale = 0;
                    //SceneManager.LoadScene(0);
                    endpanel.SetActive(true);

                }
            }
        }

    }

      //getting the positions on mouse click
      public void Onmouseclick()
        {
            check = true;
            LaunchPanel.SetActive(false);
        }
   


 
}
    
