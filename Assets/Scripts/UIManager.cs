﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject PausePanelUI;
    //public Animator dialog;
    GameObject inventoryUI;
    [SerializeField]
    private GameObject LosePanelUI;
    [SerializeField]
    public GameObject WinPanelUI;
    [SerializeField]
    private GameObject OptionsPanelUI;

    [SerializeField]
    GameObject resumeButton;
    [SerializeField]
    GameObject restartButton;
    [SerializeField]
    GameObject nextLevelButton;
    [SerializeField]
    GameObject volumeSlider;


    private int levelToLoad;

    public static UIManager Instance = null;
    public bool windowOpen = false;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Debug.Log("Two UImanager instances");
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    { 
        Time.timeScale = 1;
    }


    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OpenLosePanel()
    {
        if (LosePanelUI == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        LosePanelUI.SetActive(true);
        windowOpen = true;
        EventSystem.current.SetSelectedGameObject(restartButton);
    }

    public void OpenWinPanel(int level)
    {
        level = levelToLoad;
        if (WinPanelUI == null)
        {
            if (level <= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
        }
        WinPanelUI.SetActive(true);
        windowOpen = true;
        EventSystem.current.SetSelectedGameObject(nextLevelButton);
    }

    public void MenuPanel()
    {
        if (PausePanelUI.activeInHierarchy || WinPanelUI.activeInHierarchy || LosePanelUI.activeInHierarchy || OptionsPanelUI.activeInHierarchy)
        {
            if (OptionsPanelUI.activeInHierarchy)
            {
                CloseSettings();
            }
            else
            {
                PausePanelUI.SetActive(false);
                windowOpen = false;
                EventSystem.current.SetSelectedGameObject(resumeButton);
                Time.timeScale = 1;
            }
        }
        else
        {
            PausePanelUI.SetActive(true);
            windowOpen = true;
            Time.timeScale = 0;
            
        }
    }

    public void OpenSettings()
    {
        if (PausePanelUI.activeInHierarchy || WinPanelUI.activeInHierarchy || LosePanelUI.activeInHierarchy)
        {
            OptionsPanelUI.SetActive(true);
            PausePanelUI.SetActive(false);
            windowOpen = true;
            
        }
    }

    public void CloseSettings()
    {
        OptionsPanelUI.SetActive(false);
        PausePanelUI.SetActive(true);
    }

    public void OnNextLevelButton()
    {
        if (levelToLoad <= 1)
        {
            //SoundManager.Instance.PlayMusic("BackgroundMusic");
            //FindObjectOfType<SoundManager>().PlaySFX("BackgroundMusic");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameManager.instance.LoadNextScene(levelToLoad);
            return;
        }

        //GameManager.instance.LoadNextScene(levelToLoad);
        // if (levelToLoad <= 1)
        // {
        //     GameManager.instance.LoadNextScene(levelToLoad);
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //     return;
        // }
        // GameManager.instance.LoadNextScene(levelToLoad);
    }

    public void OnRestartButton()
    {
        //SoundManager.Instance.PlayMusic("BackgroundMusic");
        //FindObjectOfType<SoundManager>().PlaySFX("BackgroundMusic");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuButton()
    {
        // 0 is MainMenu
        SceneManager.LoadScene(0);
    }

    public void MusicsOnOff()
    {
        SoundManager.Instance.musicOn = SoundManager.Instance.musicOn ? false : true;
    }

    public void SFXOnOff()
    {
        SoundManager.Instance.sfxOn = SoundManager.Instance.sfxOn ? false : true;
    }

    public void Update()
    {
        DoInputs();
    }

    private void DoInputs()
    {
        if (Input.GetKeyDown("r"))
        {
            GameManager.instance.RestartLevel();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instance.MenuPanel();
        }
    }

    public void AddBomb(ObjectColors pickupType)
    {
        //inventoryUI
    }
    
    public void PlayClick()
    {
        SoundManager.Instance.PlaySFX("Click2");
    }
}
