using TMPro;
using UI;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text timerField;
    public TMP_Text livesText;
    private GameManager gm;
    
    private float _startTime;
    // private float time_score;
    private TimeScore timeScore;  

    private void Start()
    {
        _startTime = Time.time;
        timeScore = new TimeScore();
        gm = FindObjectOfType<GameManager>(); 
    }

    private void FixedUpdate()
    {
       timeScore.SetTimeScore(Time.time - _startTime);
       timerField.text = timeScore.GetString();
       livesText.text = gm.GetLives() + " Lives";
    }
}
