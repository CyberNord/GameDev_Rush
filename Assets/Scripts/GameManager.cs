using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UserConstants.Constants;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public TimeScore currentTimeScore; 

    // public TMP_Text livesText;
    public GameState gameState = GameState.Idle;

    private int _lives = LivePool; 

    public int GetLives()
    {
        return _lives; 
    }
    
    public void SetLives(int lives_new)
    {
        _lives = lives_new; 
    }
    
    public void ReduceLives()
    {
        _lives -= 1; 
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
    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
                // SceneManager.LoadScene("TestingEnvironment");
                break;
            case GameState.GameOver:
                SceneManager.LoadScene("GameOver");
                UnlockCursor();
                break;
            case GameState.Level1:
                SceneManager.LoadScene("Level1");
                _lives = LivePool;
                break;
            case GameState.Level2:
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
    
    // Highscore
    public void UpdateHighScore()
    {
        var t = currentTimeScore.GetTimeScore();
        if (!(t < GetHighScore_3())) return;
        if (t < GetHighScore_2())
        {
            if (t < GetHighScore_1())
            {
                PlayerPrefs.SetFloat(HighScoreTime3,PlayerPrefs.GetFloat(HighScoreTime2));
                PlayerPrefs.SetString(HighScoreName3, PlayerPrefs.GetString(HighScoreName2));
                
                PlayerPrefs.SetFloat(HighScoreTime2,PlayerPrefs.GetFloat(HighScoreTime1));
                PlayerPrefs.SetString(HighScoreName2, PlayerPrefs.GetString(HighScoreName1));
                
                PlayerPrefs.SetFloat(HighScoreTime1,t);
                PlayerPrefs.SetString(HighScoreName1, PlayerPrefs.GetString(PlayerName));
                return;
            }
            PlayerPrefs.SetFloat(HighScoreTime3,PlayerPrefs.GetFloat(HighScoreTime2));
            PlayerPrefs.SetString(HighScoreName3, PlayerPrefs.GetString(HighScoreName2));
            
            PlayerPrefs.SetFloat(HighScoreTime2,t);
            PlayerPrefs.SetString(HighScoreName2, PlayerPrefs.GetString(PlayerName));
            return;
        }
        PlayerPrefs.SetFloat(HighScoreTime3,t);
        PlayerPrefs.SetString(HighScoreName3, PlayerPrefs.GetString(PlayerName));
    }
    private float GetHighScore_1()
    {
        var i = PlayerPrefs.GetFloat(HighScoreTime1);
        return i; 
    }
    
    private float GetHighScore_2()
    {
        var i = PlayerPrefs.GetFloat(HighScoreTime2);
        return i; 
    }
    
    private float GetHighScore_3()
    {
        var i = PlayerPrefs.GetFloat(HighScoreTime3);
        return i; 
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Enums 
    public enum GameState
    {
        Idle,
        gameMenu, 
        TestLevel,
        Level1,
        Level2,
        GameOver,
        YouWon
    }
}
