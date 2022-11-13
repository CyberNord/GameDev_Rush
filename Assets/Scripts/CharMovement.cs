using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{

    private float movementSpeed = 6.0f; 
    private CharacterController characterController;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float dX = Input.GetAxisRaw("Horizontal") * movementSpeed; // A-D
        float dZ = Input.GetAxisRaw("Vertical") * movementSpeed; // W-S

        Vector3 movementVector = new Vector3(dX * Time.deltaTime, 0, dZ * Time.deltaTime);
        movementVector = Vector3.ClampMagnitude(movementVector, movementSpeed);     // normalize
        movementVector = transform.TransformDirection(movementVector);              // transform to global coordinate System

        transform.Translate(movementVector);

    }
}
