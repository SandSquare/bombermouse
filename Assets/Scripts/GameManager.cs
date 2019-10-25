using System;
using System.Collections.Generic;        //Allows us to use Lists. 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    private int level = 1;
    public float levelStartDelay = 2f;

    private Text levelNumber;
    private Text levelName;
    private Text bombText;
    private GameObject levelImage;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private GameObject splashScreen;

    private Player player;
    private bool doingSetup;

    private void Start()
    {
        InitGame();
        //InventoryUI.instance.Init();
    }

    void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        splashScreen = Instantiate(splashScreen);
        bombText = splashScreen.transform.Find("BombText").GetComponent<Text>();
        levelImage = splashScreen.transform.GetChild(1).gameObject;
        levelNumber = splashScreen.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
        levelName = splashScreen.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void UpdateUI()
    {
        uiManager.UpdateUI();
    }

    public void LoadNextScene(int levelIndex)
    {
        if (levelIndex == 0)
        {
            level++;
        }
        else
        {
            level = levelIndex;
        }
        InitGame();
        SceneManager.LoadScene(level);
        InventoryUI.instance.Init();
        Debug.Log("Loaded scene " + level);
    }

    public void RestartLevel()
    {
        Debug.Log("Restarted scene " + level);
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
        levelNumber.text = $"Level {level}:";
        levelName.text = LevelInfo.instance.levelName;
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
        levelNumber.text = "You died.";
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
