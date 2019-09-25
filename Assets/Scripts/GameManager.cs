using UnityEngine;
using System.Collections;


using System.Collections.Generic;        //Allows us to use Lists. 

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;                        //Time to wait before starting level, in seconds.
    public float turnDelay = 0.1f;                            //Delay between each Player turn.
    public int playerFoodPoints = 100;                        //Starting value for Player food points.
    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    [HideInInspector] public bool playersTurn = true;        //Boolean to check if it's players turn, hidden in inspector but public.


    private int level = 1;                                    //Current level number, expressed in game as "Day 1".

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    
        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    //This is called each time a scene is loaded.
    void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
    }


    //Update is called every frame.
    void Update()
    {
    }




    //GameOver is called when the player reaches 0 food points
    public void GameOver()
    {
        enabled = false;
    }

}
