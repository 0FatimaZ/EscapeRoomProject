using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Netcode;

public class PlayerMove : NetworkBehaviour
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

    public Vector3 Startpoint { get; private set; }

    //[Header("Cutscenes")]
    //Vector3 Startpoint;
    //public int cutscene;

    [Header("Animation")]
    public Animator animator;

    [Header("Objects")]
    public GameObject door;
    public GameObject knife;
    public GameObject InventoryBar;
    public Inventory inventory;
    public Camera mainCamera;

    [Header("Booleans")]
    public bool Door = false;
    public bool Knife = false;
    private bool isCursorLocked = true;


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
            //bool, skal v�re sand
            if (Door == true)
            {
                door.transform.GetComponent<Door>().OpenorClose();
            }

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryBar.SetActive(true);
            InventoryBar.GetComponent<InventoryManager>().DrawInventory(inventory.inventory);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            
            InventoryBar.SetActive(false);
            InventoryBar.GetComponent<InventoryManager>().DrawInventory(inventory.inventory);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isCursorLocked = !isCursorLocked;

            Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isCursorLocked;

            mainCamera.GetComponent<CameraScript>().enabled = isCursorLocked;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Door = true;
        }

        if (other.gameObject.CompareTag("Knife"))
        {
            Knife = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Door = false;
        }

    }
}


    
