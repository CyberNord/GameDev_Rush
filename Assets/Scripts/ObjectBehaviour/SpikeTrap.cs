using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    public bool sequencial = false;
    public float timerUntilOpenTrap = 2f;
    public float timerUntilCloseTrap = 2f;

    public Animator spikeTrapAnim;
    
    void Awake()
    {
        spikeTrapAnim = GetComponent<Animator>();
        if (sequencial)
        {
            StartCoroutine(OpenCloseTrap());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!sequencial)
        {
            spikeTrapAnim.SetTrigger("open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!sequencial)
        {
            spikeTrapAnim.SetTrigger("close");
        }
    }

    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(timerUntilCloseTrap);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(timerUntilOpenTrap);
        //Do it again;
        StartCoroutine(OpenCloseTrap());

    }
}
