using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{

    // Variables
    private float movementSpeed = 2.0f;
    private Vector3 velocityVector3; 


    //Setting Variables
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2.0f;

    // KeyCodes
    [SerializeField] private KeyCode walkKCode = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpKCode = KeyCode.Space;

    // Objects
    private CharacterController characterController;





    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundLayerMask);

        if (isGrounded && velocityVector3.y < 0)
        {
            velocityVector3.y = -2f;
        }

        float dX = Input.GetAxisRaw("Horizontal") * movementSpeed; // A-D
        float dZ = Input.GetAxisRaw("Vertical") * movementSpeed; // W-S

        Vector3 movementVector = new Vector3(dX * Time.deltaTime, 0, dZ * Time.deltaTime);

        if (isGrounded)
        {
            if (movementVector != Vector3.zero && Input.GetKey(walkKCode))
            {
                Walk();
            }
            else if (movementVector != Vector3.zero)
            {
                Run();
            }
            else //if (movementVector == Vector3.zero)
            {
                Idle();
            }

            movementVector = Vector3.ClampMagnitude(movementVector, movementSpeed);     // normalize
            movementVector = transform.TransformDirection(movementVector);              // transform to global coordinate System

            if (Input.GetKeyDown(jumpKCode))
            {
                Jump();
            }
        }

        // transform.Translate(movementVector);
        characterController.Move(movementVector);

        // calculate &apply gravity to player
        velocityVector3.y += gravity * Time.deltaTime;
        characterController.Move(velocityVector3 * Time.deltaTime);
    }

    private void Idle()
    {
        // idle
    }

    private void Walk()
    {
        movementSpeed = walkSpeed;
    }

    private void Run()
    {
        movementSpeed = runSpeed;
    }

    private void Jump()
    {
        velocityVector3.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
