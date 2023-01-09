using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UserConstants;

public class TutorialText2 : MonoBehaviour
{
    public TMP_Text text;
    
    private void OnTriggerEnter(Collider other)
    {
        text.text = Constants.TutorialText2; 
    }
    
    private void OnTriggerExit(Collider other)
    {
        text.text = ""; 
    }
}
