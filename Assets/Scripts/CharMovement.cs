using UnityEngine;

public class CharMovement : MonoBehaviour
{

    // Variables
    private float movementSpeed = 5.0f;
    private Vector3 velocityVector3;
    private Vector3 movementVector;
    private Vector2 movementInput;


    //Setting Variables
    [SerializeField] private float RotatingSpeed = 500.0f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.0f;

    // KeyCodes
    [SerializeField] private KeyCode jumpKCode = KeyCode.Space;

    // Objects - References
    private CharacterController characterController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = GetInput();

        if(Mathf.Abs(movementInput.x) < 0 && Mathf.Abs(movementInput.y) < 1) return;
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundLayerMask);

        if (isGrounded && velocityVector3.y < 0)
        {
            velocityVector3.y = -2f;
        }

        
        movementVector = new Vector3(movementInput.x * Time.deltaTime, 0, movementInput.y * Time.deltaTime);

        if (isGrounded)
        {
           
            if (movementVector != Vector3.zero)
            {
                Run();
            }
            else //if (movementVector == Vector3.zero)
            {
                Idle();
            }

            movementVector = Vector3.ClampMagnitude(movementVector, movementSpeed);     // normalize
            movementVector = transform.TransformDirection(movementVector);              // transform to global coordinate System

            if (! Input.GetKeyDown(KeyCode.S))
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

    private Vector2 GetInput()
    {
        float dX = Input.GetAxisRaw("Horizontal") * movementSpeed; // A-D
        float dZ = Input.GetAxisRaw("Vertical") * movementSpeed; // W-S


       return new Vector2(dX, dZ); 
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
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("Run01Left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.Play("Run01Right");
        }

    }

    private void Jump()
    {
        velocityVector3.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
