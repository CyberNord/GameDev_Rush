using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoxCharMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_jumpHeight;

    private Rigidbody m_RigidBody;

    private List<Collider> m_collisions = new List<Collider>();
    private bool m_isGrounded;

    private float m_currentZ = 0;
    private float m_currentX = 0;
    private readonly float m_interpolation = 10;
    private float m_turnSpeed = 300;

    private Animator m_Animator; 


    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TurnCtr();
        RunCtr();
        JumpCtr();
    }


    void RunCtr()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        Debug.Log("(Horizontal)X="+ moveX + " (Vertical)Z=" + moveZ);

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        m_RigidBody.MovePosition(transform.position + movement * m_moveSpeed * Time.deltaTime);


        // TurnCtr - 
        m_currentZ = Mathf.Lerp(m_currentZ, moveZ, Time.deltaTime * m_interpolation);
        m_currentX = Mathf.Lerp(m_currentX, moveX, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentZ * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentX * m_turnSpeed * Time.deltaTime, 0);

        m_Animator.SetFloat("isMoving", (Mathf.Abs(moveX)+Mathf.Abs(moveZ)));
        m_Animator.SetFloat("Run", moveZ);
        m_Animator.SetFloat("Turn", moveX);

    }

    void JumpCtr()
    {
        float moveY = Input.GetAxis("Jump");

        if (moveY > 0f && m_isGrounded)
        {
            Vector3 jumpVector = new Vector3(0f, m_jumpHeight, 0f);

            m_RigidBody.velocity = (m_RigidBody.velocity + jumpVector) ;

            m_Animator.SetBool("Jump", true);
            m_Animator.SetBool("isInAir", true);
        }
    }

    /// <summary>
    /// Collision detection taken from Sample Sam
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
                m_Animator.SetBool("Jump", false);
                m_Animator.SetBool("isInAir", false);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }
}
