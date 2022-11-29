using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuButtons : MonoBehaviour
{
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        Debug.Log("Awake GameMenuButtons");
        if (gm == null)
        {
            Debug.Log("However gm not found!");
        }
    }
    public void LoadTestScene()
    {
        Debug.Log("Clicked LoadTestScene!");
        gm.gameState = GameManager.GameState.TestLevel;
        gm.CheckState();
    }

    public void NewGame()
    {
        Debug.Log("Clicked NewGame!");
        gm.gameState = GameManager.GameState.Level1;
        gm.CheckState();
    }

    public void testClick()
    {
        Debug.Log("Click!");
        
    }

    public void Exit()
    {
        Application.Quit();

    }
}
