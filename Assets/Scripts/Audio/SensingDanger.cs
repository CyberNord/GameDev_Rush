using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensingDanger : MonoBehaviour
{
    [SerializeField] private SoundEffects _soundEffects;
    private bool sayLine = true; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (!sayLine) return;
        _soundEffects.SenseDangerSound.Play();
        sayLine = false;
    }
}
