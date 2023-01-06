using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text timerField;
    public TMP_Text livesText;
    private GameManager gm;
    
    private float _startTime;

    private void Start()
    {
        _startTime = Time.time; 
        gm = FindObjectOfType<GameManager>(); 
    }

    private void FixedUpdate()
    {
        float t = Time.time - _startTime;
        
        int hrs = 00 ;
        int min = (int)t / 60;
        float sec = t % 60;

        if (min >= 60)
        {
            hrs = min / 60; 
            min %= 60;
        }
        
        timerField.text = hrs + ":" + min + ":" + sec.ToString("f2");
        livesText.text = gm.GetLives() + " Lives"; 

    }
}
