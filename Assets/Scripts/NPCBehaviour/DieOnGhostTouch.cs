using UnityEngine;

public class DieOnGhostTouch : MonoBehaviour
{
    private GameManager gm;
    private SoundEffects _soundEffects;
    public int playSound = 0;

    private AudioSource sound;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        _soundEffects = FindObjectOfType<SoundEffects>();
        SoundChosen();
    }

    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
        gm.ReduceLives(); // lives -1 
        gm.gameState = GameManager.GameState.GameOver;
        Invoke("GoToGameOver", gm.GetLives() < 1 ? 6f : 5f);
    }
    
    private void GoToGameOver()
    {
        gm.CheckState();
    }

    private void SoundChosen()
    {
        sound = playSound switch
        {
            1 => _soundEffects.ghostSound1,
            2 => _soundEffects.ghostSound2,
            3 => _soundEffects.ghostSound3,
            4 => _soundEffects.ghostSound4,
            5 => _soundEffects.ghostSound5,
            6 => _soundEffects.ghostSound6,
            _ => _soundEffects.ghostSound1
        };
    } 
}
