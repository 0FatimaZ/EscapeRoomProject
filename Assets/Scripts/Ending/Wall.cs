using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [Header("Animation")]
    public Animator animator;

    public bool open = false;

    public GameObject knife;

    public Padlock padlockscript;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenorClose()
    {
        print("Outside");
        if (padlockscript.padlockUnlocked == true)
        {
            print("Inside");
            animator.SetBool("isopen", true);
            open = true;
            knife.SetActive(true);

        }

    }
}
