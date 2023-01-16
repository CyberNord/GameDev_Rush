using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource Intro; 
    public AudioSource Loop;

    private void Start()
    {
        Intro.Play();
        Loop.PlayDelayed(Intro.clip.length);
    }
}
