using UnityEngine;
using static UserConstants.Constants;

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
    
    public void ResetHighscore()
    {
        PlayerPrefs.SetString(HighScoreName1, DummyName1);
        PlayerPrefs.SetFloat(HighScoreTime1,DummyTime1);
        PlayerPrefs.SetString(HighScoreName2, DummyName2);
        PlayerPrefs.SetFloat(HighScoreTime2,DummyTime2);
        PlayerPrefs.SetString(HighScoreName3,DummyName3);
        PlayerPrefs.SetFloat(HighScoreTime3,DummyTime3);
        
        Debug.Log("Highscore resetted");
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
