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
        gm.reduceLives(); // lives -1  
        gm.gameState = GameManager.GameState.GameOver;
        Invoke("GoToGameOver", 6f);
    }
    
    private void GoToGameOver()
    {
        gm.CheckState();
    }
}
