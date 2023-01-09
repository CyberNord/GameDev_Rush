using TMPro;
using UnityEngine;
using UserConstants;

public class TutorialText4 : MonoBehaviour
{
    public TMP_Text text;
    
    private void OnTriggerEnter(Collider other)
    {
        text.text = Constants.TutorialText4; 
    }
    
    private void OnTriggerExit(Collider other)
    {
        text.text = ""; 
    }
}
