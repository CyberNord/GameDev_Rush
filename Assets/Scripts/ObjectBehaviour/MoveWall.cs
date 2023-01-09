using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall: MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private float xChange;
    [SerializeField] private float yChange;
    [SerializeField] private float zChange;
    private Vector3 oldPos;
    private Vector3 newPos;
    private GameManager gm;
    private void OnTriggerExit(Collider other)
    {
        newPos = new Vector3(oldPos.x + xChange, oldPos.y + yChange , oldPos.z + zChange);
        gameObject.transform.position = Vector3.Lerp (oldPos, newPos, Time.deltaTime * 2.0f);
        // Rock.transform.position = newPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        oldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState == GameManager.GameState.GameOver)
        {
            gameObject.transform.position = Vector3.Lerp(newPos, oldPos, Time.deltaTime * 2.0f); 
        }
    }
}
