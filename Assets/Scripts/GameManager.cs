using System;
using System.Collections.Generic;        //Allows us to use Lists. 
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    public static void LoadScene()
    {
        
    }

    private int level = 3;                                    //Current level number, expressed in game as "Day 1".

    //Awake is always called before any Start functions


    //Initializes the game for each level.
    void InitGame()
    {

    }



    //Update is called every frame.
    void Update()
    {

    }
}
