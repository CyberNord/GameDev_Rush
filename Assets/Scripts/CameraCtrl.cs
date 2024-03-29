using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    public float rotationY;
    public float rotationX;

    [Header("Mouse Settings")]
    [SerializeField] private float mouseSensitivity = 1.0f;
    [SerializeField] private Transform target;
    private float distanceFromTarget = 3;

    private int MIN_DIST = -2; 
    private int MAX_DIST = 6;

    private Vector3 curRotationVector3;
    private Vector3 smoothVelocityVector3 = Vector3.zero;
    
    private Vector3 defaultView;
    private bool resetView = false; 
    

    [SerializeField] private float smoothTime = 0.1f;

    private void Start()
    {
        defaultView = transform.position;
        
    }

    void Update()
    {
        // zoom in or out
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            switch (scroll)
            {
                case > 0:
                {
                    if (distanceFromTarget > MIN_DIST)
                    {
                        distanceFromTarget -= .5f;
                    }

                    break;
                }
                case < 0:
                {
                    if (distanceFromTarget < MAX_DIST)
                    {
                        distanceFromTarget += .5f;
                    }

                    break;
                }
            }
        }
        
        //Snap back Camera View
        if (resetView && !Input.GetKey(KeyCode.Mouse1))
        {
            transform.position = defaultView - transform.forward * distanceFromTarget * Time.deltaTime;
            transform.localEulerAngles = new Vector3 (14, 0, 0);

            rotationX = 14;
            rotationY = 0;
            curRotationVector3 = Vector3.SmoothDamp(curRotationVector3, new Vector3(rotationX, rotationY, 0), ref smoothVelocityVector3,
                0);
            
            resetView = false; 
        }
        
        // Rotate Camera View
        if (Input.GetKey(KeyCode.Mouse1))
        {
            resetView = true;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            rotationY += mouseX;
            rotationX -= mouseY;

            // limit axis
            rotationX = Mathf.Clamp(rotationX, -20, 80);

            // smoothing
            Vector3 nextRotationVector3 = new Vector3(rotationX, rotationY, 0);
            curRotationVector3 = Vector3.SmoothDamp(curRotationVector3, nextRotationVector3, ref smoothVelocityVector3,
                smoothTime);

            // apply rotation
            transform.localEulerAngles = curRotationVector3;
        }

        // follow Target Object
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
