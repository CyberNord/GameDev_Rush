using UnityEngine;

public class CharMovement_1 : MonoBehaviour
{
    /// <summary>
    /// Old version - character rotatio resets itself all the time
    /// </summary>
    

    // MOVEMENT
    private float movementSpeed = 5.0f;
    private Vector3 velocityVector3;
    private Vector3 movementVector;

    // JUMP
    [SerializeField] private KeyCode jumpKCode = KeyCode.Space;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.0f;

    // ROTATION
    [SerializeField] private float RotatingSpeed = 500.0f;

    
    // Objects - References
    private CharacterController characterController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        animator.applyRootMotion = false; 
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

        movementVector = new Vector3(dX * Time.deltaTime, 0, dZ * Time.deltaTime);

        if (isGrounded)
        {
           
            if (movementVector != Vector3.zero)
            {
                Run();
            }
            else
            {
                Idle();
            }

            movementVector = Vector3.ClampMagnitude(movementVector, movementSpeed);     // normalize
            movementVector = transform.TransformDirection(movementVector);              // transform to global coordinate System

            // Rotate character to direction selected
            if (!Input.GetKeyDown(KeyCode.S))
            {
                Quaternion toRotation = Quaternion.LookRotation(movementVector, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotatingSpeed * Time.deltaTime);
            }

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
        animator.Play("Idle01");
    }

    private void Run()
    {

        
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.Play("Run01Forwards");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.Play("Run01Backwards");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump01");
        }
    }

    private void Jump()
    {
        animator.Play("Jump01");
        velocityVector3.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
