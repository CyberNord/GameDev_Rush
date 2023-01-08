using System;
using TMPro;
using UI;
using UnityEngine;

    public class PlayerUI : MonoBehaviour
    {
        public TMP_Text timerField;
        public TMP_Text livesText;
        private GameManager gm;
        private bool updHighSc = true;

        private float _startTime;
        // private float time_score;
        private TimeScore timeScore;  

        private void Start()
        {
            _startTime = Time.time;
            timeScore = new TimeScore(0f);
            gm = FindObjectOfType<GameManager>(); 
        }

        private void FixedUpdate()
        {
            if (gm.gameState == GameManager.GameState.YouWon)
            {
                if (updHighSc != true) return;
                updHighSc = false; 
                gm.UpdateHighScore();
                return;
            }
            timeScore.SetTimeScore(Time.time - _startTime);
            timerField.text = timeScore.GetString();
            livesText.text = gm.GetLives() + " Lives";
            gm.currentTimeScore = timeScore; 
        }
    }
