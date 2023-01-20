using UnityEngine;

public class DieOnTouch : MonoBehaviour
{
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gm.ReduceLives(); // lives -1 
        gm.gameState = GameManager.GameState.GameOver;
        if (gm.GetLives() < 1)
        {
            Invoke("GoToGameOver", 6f);
        }
        else
        {
            Invoke("GoToGameOver", 5f);
        }
    }
    
    private void GoToGameOver()
    {
        gm.CheckState();
    }
}
