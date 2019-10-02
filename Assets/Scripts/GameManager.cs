using System;
using System.Collections.Generic;        //Allows us to use Lists. 
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    private static int level = 0;

    void Awake()
    {
        level = 1;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    public static void LoadNextScene()
    {
        level++;
        SceneManager.LoadScene(level);
    }


    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public int GetActiveScene()
    {
        return level;
    }

    void InitGame()
    {
    }

    void Update()
    {
    }
}
