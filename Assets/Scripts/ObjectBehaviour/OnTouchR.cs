using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchR : MonoBehaviour
{
    [SerializeField] float angle = 0;
    [SerializeField] float activationTime = 0;

    [SerializeField] bool turnX = false;
    [SerializeField] bool turnY = false;
    [SerializeField] bool turnZ = false;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Action());
    }

    private IEnumerator Action()
    {
        yield return new WaitForSeconds(activationTime);
        if (turnX)
        {
            transform.Rotate(angle, 0.0f, 0.0f);
        }
        else if (turnY)
        {
            transform.Rotate(0.0f, angle, 0.0f);
        }
        else if (turnZ)
        {
            transform.Rotate(0.0f, 0.0f, angle);
        }


        yield return new WaitForSeconds(activationTime);
        if (turnX)
        {
            transform.Rotate(-angle, 0.0f, 0.0f);
        }
        else if (turnY)
        {
            transform.Rotate(0.0f, -angle, 0.0f);
        }
        else if (turnZ)
        {
            transform.Rotate(0.0f, 0.0f, -angle);
        }
    }
}
