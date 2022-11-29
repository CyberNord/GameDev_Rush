using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameState gameState = GameState.Idle;

    public int Lives = 3; 

    // Make sure its the one and only
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //CheckState()

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CheckState()
    {
        switch (gameState)
        {
            case GameState.gameMenu:
                SceneManager.LoadScene("GameMenu");
                UnlockCursor(); 
                break;
            case GameState.TestLevel:
                SceneManager.LoadScene("TestingEnvironment");
                break;
            case GameState.GameOver:
                SceneManager.LoadScene("GameOver");
                UnlockCursor();
                break;
            case GameState.Level1:
                SceneManager.LoadScene("Level1");
                Lives = 3;
                break;
            case GameState.YouWon:
                SceneManager.LoadScene("YouWon");
                UnlockCursor();
                break;
            case GameState.Idle:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }



    public enum GameState
    {
        Idle,
        gameMenu, 
        TestLevel,
        Level1,
        Level2,
        GameOver,
        YouWon,
    }
}
