using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance; 
    private GameManager gm;
    
    public AudioSource JumpSound; 
    public AudioSource LandSound;

    public AudioSource RumbleIntro; 
    public AudioSource RumbleLoop; 
    public AudioSource MainIntro; 
    public AudioSource MainLoop;
    
    private GameManager.GameState _currState;
    private GameManager.GameState _savedState = GameManager.GameState.TestLevel;

    private AudioSource currTrack;  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }else if(instance != this)
        {
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
}
