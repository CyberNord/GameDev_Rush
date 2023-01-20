using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWon : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private SoundEffects _soundEffects;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gm.gameState = GameManager.GameState.YouWon;
        _soundEffects.YaySound.Play();
        Invoke("GoToWin", 3f);
    }

    private void GoToWin()
    {
        gm.CheckState();
    }
}
