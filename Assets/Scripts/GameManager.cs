using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameState gameState = GameState.Idle; 

    public static event Action<GameState> OnGameStateChanged;

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
                break;
            case GameState.TestLevel:
                SceneManager.LoadScene("TestingEnvironment");
                break;
            case GameState.GameOver:
                SceneManager.LoadScene("GameOver");
                break;
            case GameState.TestLevel2:
                SceneManager.LoadScene("testlevel");
                break;
            case GameState.Idle:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
    }



    public enum GameState
    {
        Idle,
        gameMenu, 
        TestLevel,
        TestLevel2,
        GameOver,
    }
}
