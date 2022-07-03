using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class rocketmovement : MonoBehaviour
{
    public Transform rocketTarget;
    public Rigidbody rocketRigidbody;
    //public Transform[] objectlist;

    public float turn;
    public float rocketVelocity;
    private const float minDistance = 10f;

    //int index = 0;
    //private Vector3[] array = new Vector3[10];
    //int count = 0;
    //int count_1 = 0;

    bool check = false;

//     public void Update()
//     {
//         if (check == false)
//         {
//             if (Input.GetMouseButtonDown(0))
//             {
//                 Debug.Log(Input.mousePosition);
//                 array[count] = Input.mousePosition;
//                 count++;
//             }
//         }
//         else
//         {
//             index = PlayerPrefs.GetInt("objectselected");

//             objectlist[index+1].gameObject.SetActive(false);



//             if (count_1 < count)
//             {
//                 rocketTarget = objectlist[index + 1];
//                 rocketTarget.position = array[count_1];

//                 if ((transform.position - rocketTarget.transform.position).sqrMagnitude > minDistance * minDistance)
//                 {
//                     rocketRigidbody.velocity = transform.forward * rocketVelocity;
//                     var rocketTargetRotation = Quaternion.LookRotation(rocketTarget.position - transform.position);
//                     rocketRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turn));
//                 }
//                 else
//                 {
//                     count_1++;
//                 }

//             }
//             else
//             {
//                 rocketTarget = objectlist[index];
//                 if ((transform.position - rocketTarget.transform.position).sqrMagnitude > minDistance * minDistance)
//                 {
//                     rocketRigidbody.velocity = transform.forward * rocketVelocity;
//                     var rocketTargetRotation = Quaternion.LookRotation(rocketTarget.position - transform.position);
//                     rocketRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turn));
//                 }
//                 else
//                 {
//                     objectlist[index].gameObject.SetActive(false);
//                     Time.timeScale = 0;
//                     SceneManager.LoadScene(0);
//                 }
//             }
//         }

//     }

//     public void Onmouseclick()
//     {
//         check = true;
//     }
// }
public void Update()
{
                //rocketTarget = objectlist[index];
                if ((transform.position - rocketTarget.transform.position).sqrMagnitude > minDistance * minDistance)
                {
                    rocketRigidbody.velocity = transform.forward * rocketVelocity;
                    var rocketTargetRotation = Quaternion.LookRotation(rocketTarget.position - transform.position);
                    rocketRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turn));
                }
                else
                {
                    rocketTarget.gameObject.SetActive(false);
                    //objectlist[index].gameObject.SetActive(false);
                    Time.timeScale = 0;
                    SceneManager.LoadScene(0);
                }
}
}
