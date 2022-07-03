using UnityEngine;
using UnityEngine.InputSystem;

public class cinemachineswitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction action;
    private Animator animator;
    public GameObject gridpanel;
    
    //different camera views
    bool cam1 = true;
    bool cam2 = false;
    bool cam3 = false;
    bool cam4 = false;
    bool cam5 = false;

    //getting the animator
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    //enable the camera
    private void OnEnable()
    {
        action.Enable();
    }
    
    //disable the camera
    private void OnDisable()
    {
        action.Disable();
    }

    //getting the input from the keyboard
    void Start()
    {
        action.performed += _ => SwitchState();
    }

    //actual function to switch the camera
    private void SwitchState()
    {
        //cam1
        if (cam1)
        {
            animator.Play("state2");
            gridpanel.SetActive(false);
            cam1 = false;
            cam2 = true;
        }
        //cam2
        else if(cam2)
        {
            animator.Play("state3");
            cam2 = false;
            cam3 = true;
        }
        //cam3
        else if(cam3)
        {
            animator.Play("state4");
            cam3 = false;
            cam4 = true;
        }
        //cam4
        else if (cam4)
        {
            animator.Play("state1");
            gridpanel.SetActive(true);
            cam4 = false;
            cam1 = true;

        }
        // cam1 = !cam1;
    }

}
