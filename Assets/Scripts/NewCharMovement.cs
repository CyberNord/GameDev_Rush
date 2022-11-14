using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class NewCharMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float m_moveSpeed = 4.5f;
    [SerializeField] private float m_turnSpeed = 200;

    [SerializeField] private Animator m_animator;
    [SerializeField] private CharacterController m_characterController;

    [Header("Collision")]
    [SerializeField] private float m_groundCheckDistance = - 0.1f;
    [SerializeField] private LayerMask m_groundLayerMask;

    // Collision
    private bool m_isGrounded;
    private bool walk; 
    private Vector3 m_velocityVector3;
     

    // Basic Movement
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;
    
    private readonly float m_interpolation = 10;
    private float m_currentV = 0;
    private float m_currentH = 0;

    // Jump
    private bool m_jumpInput = false;
    private float m_gravity = -9.81f;
    private float m_jumpHeight = 1.2f;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        // m_animator = GetComponentInChildren<Animator>();
        if (!m_characterController) { gameObject.GetComponent<CharacterController>(); }
    }


    private void Update()
    {
        if (!m_jumpInput && Input.GetKey(KeyCode.Space))
        {
            m_jumpInput = true;
            
        } 
        
        Animate();

        m_isGrounded = Physics.CheckSphere(transform.position, m_groundCheckDistance, m_groundLayerMask);

        if (m_isGrounded && m_velocityVector3.y < 0)
        {
            m_velocityVector3.y = -2f;
        }
    }

    void FixedUpdate()
    {
        // Todo Animation ground

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        walk = Input.GetKey(KeyCode.LeftShift);

        if (v < 0)
        {
            if (walk)
            {
                v *= m_backwardsWalkScale;
            }
            else { v *= m_backwardRunScale; }
        }
        else if (walk)
        {
            v *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        if (m_jumpInput)
        {
            if (m_isGrounded)
            {
                // Jump
                m_velocityVector3.y = Mathf.Sqrt(m_jumpHeight * -2 * m_gravity);
            }
        }

        // Todo: Character Rotation has a fairly large turning circle ..

        // character rotation
        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        // character movement
        Vector3 movementVector = new Vector3(h * m_moveSpeed * Time.deltaTime, 0, v * m_moveSpeed * Time.deltaTime);
        movementVector = Vector3.ClampMagnitude(movementVector, m_moveSpeed);     
        movementVector = transform.TransformDirection(movementVector);  
        m_characterController.Move(movementVector); 

        // apply jump
        m_velocityVector3.y += m_gravity * Time.deltaTime;
        m_characterController.Move(m_velocityVector3 * Time.deltaTime);

        

        // reset variables
        m_jumpInput = false;
        m_animator.SetBool("isGrounded", m_isGrounded);
    }

    private void Animate()
    {
        if (!m_isGrounded && Input.GetKey(KeyCode.Space)) 
        {
            m_animator.Play("Jump"); ;
        }
            

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)
           )
        {
            // WalkForwards
            m_animator.SetFloat("Motion",0.5f, 0.15f, Time.deltaTime );
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            // WalkBackwards
            m_animator.SetFloat("Motion", -0.5f, 0.15f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            // RunForwards
            m_animator.SetFloat("Motion", 1f, 0.15f, Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            // RunBackwards
            m_animator.SetFloat("Motion", -1, 0.15f, Time.deltaTime);
        }
        else
        {
            // Idle
            m_animator.SetFloat("Motion", 0, 0.15f, Time.deltaTime);
        }
    }
}
