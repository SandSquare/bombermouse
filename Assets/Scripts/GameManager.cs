using System;
using System.Collections.Generic;        //Allows us to use Lists. 
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    [SerializeField]
    private static int level = 0;


    void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    public static void LoadNextScene()
    {
        Debug.Log("Loaded scene "+level);
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
