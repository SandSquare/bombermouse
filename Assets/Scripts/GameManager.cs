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
    public float gameClearDelay = 5f;
    public float splashScreenStartDelay = .05f;

    [SerializeField]
    public int maxLevels;

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

    bool gameCleared = false;
    private float time = 0;
    private float clearScreenDuration = 5.0f;

    private void Start()
    {
        InitGame();
        maxLevels = SceneManager.sceneCountInBuildSettings;
        //maxLevels = 3;
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
        // TODO Game clear screen
        Debug.Log($"{level} {maxLevels}");
        if (level >= maxLevels)
        {
            GameClear();
            return;
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
        //InitGame();
        //SceneManager.LoadScene(level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }


    public void InitGame()
    {
        doingSetup = true;
        levelNumber.text = $"Level {level - 1}:";
        levelName.text = levelNames[level] != "" ? levelNames[level] : "Default Level Name";
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

    public void GameClear()
    {
        gameCleared = true;
        levelNumber.text = "";
        levelName.text = "Congratulations! \n You have successfully escaped. \n Good job!";
        levelImage.SetActive(true);
        Invoke("HideLevelImage", gameClearDelay);
    }

    void Update()
    {
        if (gameCleared)
        {
            time += Time.deltaTime;
            if (time > 4.0f)
            {
                SceneManager.LoadScene("MainMenu");
                gameCleared = false;
            }
        }
    }

    public int GetActiveScene()
    {
        return level;
    }
}
