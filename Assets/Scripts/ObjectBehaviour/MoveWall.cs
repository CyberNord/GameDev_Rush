using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall: MonoBehaviour
{
    [SerializeField] private new GameObject gameObject;
    [SerializeField] private float xChange;
    [SerializeField] private float yChange;
    [SerializeField] private float zChange;
    private Vector3 oldPos;
    private Vector3 newPos;
    private GameManager gm;
    private SoundEffects _soundEffects;
    
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        _soundEffects = FindObjectOfType<SoundEffects>();
    }
    
    private void OnTriggerExit(Collider other)
    {
        newPos = new Vector3(oldPos.x + xChange, oldPos.y + yChange , oldPos.z + zChange);
        gameObject.transform.position = Vector3.Lerp (oldPos, newPos, Time.deltaTime * 2.0f);
        _soundEffects.HitSound.Play();
        // Rock.transform.position = newPos;
    }

    // Start is called before the first frame update
    private void Start()
    {
        oldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        if (gm.gameState == GameManager.GameState.GameOver)
        {
            gameObject.transform.position = Vector3.Lerp(newPos, oldPos, Time.deltaTime * 2.0f); 
        }
    }
}
