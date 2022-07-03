

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;
using TMPro;
using System.IO;


public class rockettarget_chakri : MonoBehaviour
{
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

    private int line_count=0;

    private Vector3[] array;
    int count;
    int count_1 = 0;

    bool check = false;

    public void empire_state(int num)
    {
        index = num;
    }

    public void metlife(int num)
    {
        index = num;
    }

    //[MenuItem("Tools/Read file")]
    public void Start()
    {
       
        //string path = "Assets/Resources/test.txt";
        var fullPath = "C:/Users/HP/Desktop/FYP/Chakri_flight_simulation.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(fullPath); 
        string file_content = reader.ReadToEnd();

        string[] words = file_content.Split('\n',' ');
        
        for(int i=0;i<file_content.Length;i++)
        {
            if(file_content[i]=='\n')
            {
                line_count++;
            }
        }
        line_count+=2;
        array = new Vector3[line_count];
        array[0] = new Vector3(52321f, 4427f, 7381f);

        int count_words = 0;
        

        for(int i=1;i<line_count;i++)
        {
            array[i] = new Vector3(float.Parse(words[count_words]), float.Parse(words[count_words+1]), float.Parse(words[count_words+2]));
            count_words+=3;
            Debug.Log(array[i]);
        }

        count = line_count;


        //Debug.Log(line_count);

        reader.Close();

    }

    public void Update()
    {
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



            if (count_1 < count)
            {
                Debug.Log(count_1);
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
                    if(!((transform.position - rocketTarget.transform.position).sqrMagnitude > particle_distance * particle_distance))
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

                }
            }
        }

    }


      public void Onmouseclick()
        {
            check = true;
            LaunchPanel.SetActive(false);
        }
   


 
}
    
