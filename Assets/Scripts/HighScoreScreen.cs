using TMPro;
using UI;
using UnityEngine;
using static UserConstants.Constants;

public class HighScoreScreen : MonoBehaviour
{
    public TMP_Text highscoreText1;
    public TMP_Text highscoreText2;
    public TMP_Text highscoreText3;

    public TMP_Text highscoreName1;
    public TMP_Text highscoreName2;
    public TMP_Text highscoreName3;
    
    private TimeScore h1;
    private TimeScore h2;
    private TimeScore h3;

    private void UpdateHighScoreScreen()
    {
        h1 = new TimeScore(PlayerPrefs.GetFloat(HighScoreTime1));
        h2 = new TimeScore(PlayerPrefs.GetFloat(HighScoreTime2));
        h3 = new TimeScore(PlayerPrefs.GetFloat(HighScoreTime3));

        highscoreText1.text = h1.GetString();
        highscoreText2.text = h2.GetString();
        highscoreText3.text = h3.GetString();
        
        highscoreName1.text = PlayerPrefs.GetString(HighScoreName1);
        highscoreName2.text = PlayerPrefs.GetString(HighScoreName2);
        highscoreName3.text = PlayerPrefs.GetString(HighScoreName3);
    }

    // Start is called before the first frame update
    private void Start()
    {
        UpdateHighScoreScreen();
    }
}
