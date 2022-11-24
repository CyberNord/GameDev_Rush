using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    public float rotationY = 0.0f;
    public float rotationX = 0.0f;

    [Header("Mouse Settings")]
    [SerializeField] private float mouseSensitivity = 1.0f;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget = 5;

    private Vector3 curRotationVector3;
    private Vector3 smoothVelocityVector3 = Vector3.zero;

    [SerializeField] private float smoothTime = 0.1f;

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;

        // limit axis
        rotationX = Mathf.Clamp(rotationX, 10, 80);

        // smoothing
        Vector3 nextRotationVector3 = new Vector3(rotationX, rotationY, 0);
        curRotationVector3 = Vector3.SmoothDamp(curRotationVector3, nextRotationVector3, ref smoothVelocityVector3,smoothTime);

        // apply rotation
        transform.localEulerAngles = curRotationVector3;

        // follow Target Object
        transform.position = target.position - transform.forward * distanceFromTarget; 
    }
}
