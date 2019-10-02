using System;
using System.Collections.Generic;        //Allows us to use Lists. 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    private int level = 0;
    public float levelStartDelay = 2f;

    [SerializeField]
    private Text levelText;
    [SerializeField]
    private GameObject levelImage;
    private bool doingSetup;

    


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

    public void LoadNextScene()
    {
        Debug.Log("Loaded scene "+level);
        level++;
        InitGame();
        SceneManager.LoadScene(level);
    }


    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }


    public void InitGame()
    {
        doingSetup = true;
        levelText.text = "Level " + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    public void GameOver()
    {
        levelText.text = "You died.";
        levelImage.SetActive(true);
    }

    void Update()
    {
    }

    public int GetActiveScene()
    {
        return level;
    }
}
