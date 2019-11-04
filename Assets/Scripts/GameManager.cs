using System;
using System.Collections.Generic;        //Allows us to use Lists. 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    public int level = 1;
    public float levelStartDelay = 2f;
    public float splashScreenStartDelay = .05f;

    private Text levelNumber;
    public Text levelName;
    private Text bombText;
    private GameObject levelImage;

    //[SerializeField]
    //private UIManager uiManager;

    [SerializeField]
    private GameObject splashScreen;
    [SerializeField]
    public GameObject levelManager;

    private Player player;
    public bool doingSetup;

    [SerializeField]
    public string[] levelNames;

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
        levelManager = Instantiate(levelManager);
        //bombText = splashScreen.transform.Find("BombText").GetComponent<Text>();
        levelImage = splashScreen.transform.GetChild(1).gameObject;
        levelNumber = splashScreen.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
        levelName = splashScreen.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void UpdateUI()
    {
        //uiManager.UpdateUI();
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

        SceneManager.LoadScene(level);
        //levelName.text = LevelInfo.instance.levelName;
        //LevelInfo.instance.UpdateLevelName();

        InventoryUI.instance.Init();
        Debug.Log("Loaded scene " + level);
        InitGame();
        //Invoke("InitGame", splashScreenStartDelay);
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
        levelNumber.text = $"Level {level - 1}:";
        levelName.text = levelNames[level]!="" ? levelNames[level] : "Default Level Name";
        levelImage.SetActive(true);

        Invoke("HideLevelImage", levelStartDelay);
    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
        levelName.text = "";
    }

    public void GameOver()
    {
        levelNumber.text = "";
        levelName.text = "You died.";
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
