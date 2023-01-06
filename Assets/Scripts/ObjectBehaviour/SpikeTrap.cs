using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    public Animator spikeTrapAnim;
    
    void Awake()
    {
        spikeTrapAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        spikeTrapAnim.SetTrigger("open");
    }

    private void OnTriggerExit(Collider other)
    {
        spikeTrapAnim.SetTrigger("close");
    }

    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //Do it again;
        StartCoroutine(OpenCloseTrap());

    }
}
