using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveDistance = 5f;
    public float speed = 1;
    
    public bool moveX = true;
    public bool moveY = true;
    public bool moveZ = true;
    
    public bool inverseX = false; 
    public bool inverseY = false; 
    public bool inverseZ = false;

    private bool stop = false; 
    
    Vector3 _startingPos;

    Transform _trans;

    public void StopMovement()
    {
        stop = true; 
    }

    // Use this for initialization
    void Start () {
        _trans = GetComponent<Transform>();
        _startingPos = _trans.position;
    }
	
    // Update is called once per frame
    void Update ()
    {
        float x = 0;
        float y = 0;
        float z = 0;
        
        if (stop) return;
        if (moveX)
        {
            if (inverseX)
            {
                x = _startingPos.x - Mathf.PingPong(Time.time * speed, moveDistance);
            }
            else
            {
                x = _startingPos.x + Mathf.PingPong(Time.time * speed, moveDistance);
            }

        }
        else
        {
            x = _startingPos.x;
        }

        if (moveY)
        {
            if (inverseY)
            {
                y = _startingPos.y - Mathf.PingPong(Time.time * speed, moveDistance);
            }
            else
            {
                y = _startingPos.y + Mathf.PingPong(Time.time * speed, moveDistance);
            }
        }
        else
        {
            y = _startingPos.y;
        }

        if (moveZ)
        {
            if (inverseZ)
            {
                z = _startingPos.z - Mathf.PingPong(Time.time * speed, moveDistance);
            }
            else
            {
                z = _startingPos.z + Mathf.PingPong(Time.time * speed, moveDistance);
            }
        }
        else
        {
            z = _startingPos.z;
        }

        _trans.position = new Vector3(+x, y, z);

    }
}
