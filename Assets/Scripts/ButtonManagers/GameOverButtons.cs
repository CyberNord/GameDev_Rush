using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void BackToMainMenu()
    {
        gm.gameState = GameManager.GameState.gameMenu;
        gm.CheckState();
    }

    public void testClick()
    {
        Debug.Log("Click!");

    }
}
