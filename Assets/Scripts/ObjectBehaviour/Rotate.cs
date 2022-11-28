using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] bool turnX = false;
    [SerializeField] bool turnY = false;
    [SerializeField] bool turnZ = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (turnX)
        {
            transform.Rotate(speed , 0.0f, 0.0f );
        }
        else if (turnY)
        {
            transform.Rotate(0.0f, speed , 0.0f);
        }
        else if (turnZ)
        {
            transform.Rotate(0.0f, 0.0f, speed);
        }
       
    }


}
