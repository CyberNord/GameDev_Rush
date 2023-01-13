using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UserConstants;

public class FemaleWarriorLine : MonoBehaviour
{
    public TMP_Text text;
    
    private void OnTriggerEnter(Collider other)
    {
        text.text = Constants.NPCFemale1; 
    }
    
    private void OnTriggerExit(Collider other)
    {
        text.text = ""; 
    }
}
