using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRune : MonoBehaviour
{
    public GameObject TrapDoor;

    void OnTriggerEnter()
    {
        TrapDoor.GetComponent<Animation>().Play("trapRune"); 
    }
}
