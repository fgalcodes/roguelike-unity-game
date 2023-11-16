using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardManager boardScript;

    private int _level = 1;


    private void Awake()
    {
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    private void InitGame()
    {
        boardScript.SetupScene(_level);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
