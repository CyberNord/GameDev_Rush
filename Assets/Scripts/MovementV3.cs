using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementV3 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float m_MoveSpeed = 2;
    [SerializeField] private float m_RunSpeed = 5;
    [SerializeField] private float m_jumpHeight = 5.8f;
    private float m_speedMultiplicator;

    [Header("Audio")]
    [SerializeField] private SoundEffects _soundEffects; 

    private Rigidbody m_RigidBody;
    private GameManager gm;

    private List<Collider> m_collisions = new List<Collider>();
    private bool m_isGrounded;

    private float m_currentZ = 0;
    private float m_currentX = 0;
    private readonly float m_interpolation = 10;
    private float m_turnSpeed = 300;

    private Animator m_Animator;

    private bool isDed = false;
    private bool landSound = false;

    private Vector3 respawnPoint;
    private GameManager.GameState curr;
    
    public float horizontalMouseSpeed = 2.0F;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
        m_Animator = GetComponent<Animator>();

        respawnPoint = transform.position;
        curr = gm.gameState;
        Debug.Log("current Level is " + curr);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDed)
        {
            Die();
        }
        else if(gm.gameState == GameManager.GameState.YouWon)
        {
            m_Animator.SetTrigger("won"); 
        }
        else
        {
            RunCtr();
            JumpCtr();
        }
        
    }

    void Update()
    {
        if (gm.gameState == GameManager.GameState.GameOver)
        {
            isDed = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            // Application.Quit();
            gm.gameState = GameManager.GameState.GameOver; 
            gm.CheckState();
        }
    }

    void RunCtr()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        float mouseCtrlX = horizontalMouseSpeed * Input.GetAxis("Mouse X");
        
        m_speedMultiplicator = Input.GetKey(KeyCode.LeftShift) ? m_MoveSpeed : m_RunSpeed;

        Debug.Log("(Horizontal)X="+ moveX + " (Vertical)Z=" + moveZ);
        
        Vector3 movement = new Vector3(moveX * 1.4f , 0f, moveZ * m_speedMultiplicator);

        m_RigidBody.MovePosition(transform.position + movement  * Time.deltaTime);
        
        m_currentZ = Mathf.Lerp(m_currentZ, moveZ, Time.deltaTime * m_interpolation);
        m_currentX = Mathf.Lerp(m_currentX, moveX, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentZ * m_speedMultiplicator * Time.deltaTime;
        transform.position += transform.right * m_currentX * m_speedMultiplicator * Time.deltaTime;

        // rotate Player
        transform.Rotate(0, mouseCtrlX, 0);
        if(Input.GetKey(KeyCode.Q)){
            Debug.Log(" Q - Pressed ");
            transform.Rotate(0, -horizontalMouseSpeed, 0);
        }
        if(Input.GetKey(KeyCode.E)){
            Debug.Log(" E - Pressed ");
            transform.Rotate(0, horizontalMouseSpeed, 0);
        }

        // Animator
        m_Animator.SetFloat("isMoving", (Mathf.Abs(moveX)+Mathf.Abs(moveZ)));
        m_Animator.SetFloat("Run", moveZ);
        m_Animator.SetFloat("Turn", moveX);
        

    }

    void JumpCtr()
    {
        float moveY = Input.GetAxis("Jump");

        if (moveY > 0f && m_isGrounded)
        {
            _soundEffects.JumpSound.Play();
            landSound = true;
            Vector3 jumpVector = new Vector3(0f, m_jumpHeight, 0f);
            
            m_RigidBody.velocity = jumpVector ;

            m_Animator.SetBool("Jump", true);
            m_Animator.SetBool("isInAir", true);
            
        }
    }

    private void Die()
    {
        m_Animator.SetBool("isDed", true);
        m_Animator.SetTrigger("isDed");
        if (gm.GetLives() >= 0)
        {
            Invoke("Respawn", 4f);
        }

    }

    private void Respawn()
    {
        transform.position = respawnPoint;
        isDed = false;
        m_Animator.SetBool("isDed", false);
        gm.gameState = curr;
        Debug.Log("Respawned. Lives left = " + gm.GetLives());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint");
            respawnPoint = transform.position;
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
                if (!landSound) continue;
                _soundEffects.LandSound.Play();
                landSound = false;
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
