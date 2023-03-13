using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Ground Check")]
    public LayerMask groundMask;
    public Transform groundDetectionTransform;
    public bool isGrounded;

    [Header("Movement")]
    public float movementSpeed = 5f;
    public float gravityFactor = -9.81f;
    public float currentVelY = 0;
    public CharacterController controller;

    [Header("Cutscenes")]
    Vector3 Startpoint;
    public int cutscene;

    [Header("Animation")]
    public Animator animator;

    [Header("UI")]
    public GameObject locked_door;
    public GameObject demo;
    public GameObject cabin_locked;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Startpoint = transform.position;
        animator = GetComponent<Animator>();
    }

    public void CheckIsGrounded()
    {
        Collider[] cols = Physics.OverlapSphere(groundDetectionTransform.position, 0.05f, groundMask);

        if (cols.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        CheckIsGrounded();

        if (isGrounded == false)
        {
            currentVelY += gravityFactor * Time.deltaTime;
        }
        else if (isGrounded == true)
        {
            currentVelY = -2f;
        }

        Vector3 movement = new Vector3();

        movement = inputX * -transform.forward + inputY * transform.right;

        controller.Move(movement * movementSpeed * Time.deltaTime);
        controller.Move(new Vector3(0, currentVelY * Time.deltaTime, 0));

        animator.SetFloat("Velocity", Mathf.Abs(inputY + inputX));

        if (Input.GetKeyDown("e"))
        {
            //bool, skal være sand
        }

    }

    void OnTriggerEnter(Collider other)
    {
        

    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}


    
