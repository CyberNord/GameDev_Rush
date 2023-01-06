using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private static int LIVEPOOL = 3;
    
    // public TMP_Text livesText;
    public GameState gameState = GameState.Idle;
    
    private int lives = LIVEPOOL;

    public int GetLives()
    {
        return lives; 
    }
    
    public void SetLives(int lives_new)
    {
        lives = lives_new; 
    }
    
    public void reduceLives()
    {
        lives -= 1; 
    }
    
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
        // livesText.text = lives + " Livesasd";
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
                lives = LIVEPOOL;
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
