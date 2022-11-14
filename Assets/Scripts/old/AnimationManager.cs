using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    private Animator a_animator;



    // Start is called before the first frame update
    void Start()
    {
        a_animator = GetComponentInChildren<Animator>();
        a_animator.applyRootMotion = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            a_animator.Play("RunForwards");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            a_animator.Play("RunBackwards");
        }
        else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift) ||
                 Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift) ||
                 Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift)
                )
        {
            a_animator.Play("WalkForwards");
        }
        else if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            a_animator.Play("RWalkBackwards");
        }
        else
        {
            a_animator.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            a_animator.Play("Jump");
        }
    }
}
