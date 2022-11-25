using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Contains all sort of Sounds to be played by various game entities

    public static AudioManager instance;

    [Header("Teleporter")]
    [SerializeField] private AudioSource teleporterAmbient;
    [SerializeField] private AudioSource teleporterPort;


    // Make sure its the one and only
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

}
