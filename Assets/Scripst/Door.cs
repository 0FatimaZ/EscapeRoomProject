using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Animation")]
    public Animator animator;

    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void OpenorClose()
    {
        if (open)
        {
            animator.SetBool("IsOpen", false);
            open = false;
        }

        else
        {
            animator.SetBool("IsOpen", true);
            open = true;
        }
    }
}



