using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost1 : MonoBehaviour
{
    public float moveDistance = 5f;
    public bool moveX = true;
    public bool moveY = true;
    public bool moveZ = true;
    public float speed = 1; 

    Vector3 _startingPos;

    Transform _trans;

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
        
        if (moveX)
        {
            x = Mathf.PingPong(Time.time * speed, moveDistance);
        }
        
        if (moveY)
        {
            y = Mathf.PingPong(Time.time * speed, moveDistance);
        }
        
        if (moveZ)
        {
            z = Mathf.PingPong(Time.time * speed, moveDistance);
        }
        
        _trans.position = new Vector3(_startingPos.x + x, _startingPos.y + y, _startingPos.z + z);
        
    }
}
