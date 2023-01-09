using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UserConstants;

public class TutorialText5 : MonoBehaviour
{
    public TMP_Text text;
    
    private void OnTriggerEnter(Collider other)
    {
        text.text = Constants.TutorialText5; 
    }
    
    private void OnTriggerExit(Collider other)
    {
        text.text = ""; 
    }
}
