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

    
    public GameObject door, pmap, bmap, part, bart, calc, padl, candy, tongue, key, knife, teddy, cat, dog, poem, puzz, glass;

    [Header("Booleans")]
    public bool Door = false;
    public bool PMap = false;
    public bool BMap = false;
    public bool PArt = false;
    public bool BArt = false;
    public bool Calc = false;
    public bool PadL = false;
    public bool Candy = false;
    public bool Tongue = false;
    public bool Key = false;
    public bool Knife = false;
    public bool Teddy = false;
    public bool Cat = false;
    public bool Dog = false;
    public bool Poem = false;
    public bool Puzz = false;
    public bool Glass = false;


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

        //animator.SetFloat("Velocity", Mathf.Abs(inputY + inputX));

        if (Input.GetKeyDown("e"))
        {
            //bool, skal være sand
            if (Door == true)
            {
                door.transform.GetComponent<Door>().OpenorClose();
            }

            if (PMap == true)
            {
                pmap.SetActive(true);
                PMap = false;
            }

            if (PMap == false)
            {
                pmap.SetActive(false);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Door = true;
        }

        if (other.gameObject.CompareTag("PMap"))
        {
            PMap = true;
        }

        if (other.gameObject.CompareTag("BMap"))
        {
            BMap = true;
        }

        if (other.gameObject.CompareTag("PArt"))
        {
            PArt = true;
        }

        if (other.gameObject.CompareTag("BArt"))
        {
            BArt = true;
        }
        
        if (other.gameObject.CompareTag("Calc"))
        {
            Calc = true;
        }

        if (other.gameObject.CompareTag("PadL"))
        {
            PadL = true;
        }

        if (other.gameObject.CompareTag("Candy"))
        {
            Candy = true;
        }

        if (other.gameObject.CompareTag("Tongue"))
        {
            Tongue = true;
        }

        if (other.gameObject.CompareTag("Key"))
        {
            Key = true;
        }

        if (other.gameObject.CompareTag("Knife"))
        {
            Knife = true;
        }

        if (other.gameObject.CompareTag("Teddy"))
        {
            Teddy = true;
        }

        if (other.gameObject.CompareTag("Cat"))
        {
            Cat = true;
        }

        if (other.gameObject.CompareTag("Dog"))
        {
            Dog = true;
        }

        if (other.gameObject.CompareTag("Poem"))
        {
            Poem = true;
        }

        if (other.gameObject.CompareTag("Puzz"))
        {
            Puzz = true;
        }

        if (other.gameObject.CompareTag("Glass"))
        {
            Glass = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Door = false;
        }

        if (other.gameObject.CompareTag("PMap"))
        {
            PMap = false;
        }

        if (other.gameObject.CompareTag("BMap"))
        {
            BMap = false;
        }

        if (other.gameObject.CompareTag("PArt"))
        {
            PArt = false;
        }

        if (other.gameObject.CompareTag("BArt"))
        {
            BArt = false;
        }

        if (other.gameObject.CompareTag("Calc"))
        {
            Calc = false;
        }

        if (other.gameObject.CompareTag("PadL"))
        {
            PadL = false;
        }

        if (other.gameObject.CompareTag("Candy"))
        {
            Candy = false;
        }

        if (other.gameObject.CompareTag("Tongue"))
        {
            Tongue = false;
        }

        if (other.gameObject.CompareTag("Key"))
        {
            Key = false;
        }

        if (other.gameObject.CompareTag("Knife"))
        {
            Knife = false;
        }

        if (other.gameObject.CompareTag("Teddy"))
        {
            Teddy = false;
        }

        if (other.gameObject.CompareTag("Cat"))
        {
            Cat = false;
        }

        if (other.gameObject.CompareTag("Dog"))
        {
            Dog = false;
        }

        if (other.gameObject.CompareTag("Poem"))
        {
            Poem = false;
        }

        if (other.gameObject.CompareTag("Puzz"))
        {
            Puzz = false;
        }

        if (other.gameObject.CompareTag("Glass"))
        {
            Glass = false;
        }
    }
}


    
