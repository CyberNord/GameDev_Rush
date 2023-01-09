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
        PlayerPrefs.SetString(HighScoreName1, "Fritz");
        PlayerPrefs.SetFloat(HighScoreTime1,600f);
        PlayerPrefs.SetString(HighScoreName2, "Maria");
        PlayerPrefs.SetFloat(HighScoreTime2,900f);
        PlayerPrefs.SetString(HighScoreName3,"Alois");
        PlayerPrefs.SetFloat(HighScoreTime3,1500f);
        
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
