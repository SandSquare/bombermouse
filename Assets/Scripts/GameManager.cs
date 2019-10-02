using UnityEngine;
using System.Collections;
using System.Collections.Generic;        //Allows us to use Lists. 

public static class GameManager
{
    public static float levelStartDelay = 2f;                        //Time to wait before starting level, in seconds.
    public static float turnDelay = 0.1f;                            //Delay between each Player turn.
    private static int level = 1;                                    //Current level number, expressed in game as "Day 1".

    public static void Awake()
    {
        //if (instance == null)
        //    instance = this;
        //else if (instance != this)
        //    Destroy(gameObject);
    
        //DontDestroyOnLoad(gameObject);

        InitGame();
    }

    //This is called each time a scene is loaded.
    static void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }

    //Initializes the game for each level.
    static void InitGame()
    {
    }


    //Update is called every frame.
    static void Update()
    {
    }

    //GameOver is called when the player reaches 0 food points
    public static void GameOver()
    {
    }

}
