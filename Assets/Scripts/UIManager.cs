﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        //inventoryUI = this.gameObject.transform.GetChild(0).gameObject;
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
    }

    public void MenuPanel()
    {
        if (PausePanelUI.activeInHierarchy)
        {
            //CloseSettings();
            PausePanelUI.SetActive(false);
            windowOpen = false;
        }
        else
        {
            //OpenSettings();
            PausePanelUI.SetActive(true);
            windowOpen = true;
        }
    }

    public void OpenSettings()
    {
    }

    public void CloseSettings()
    {
    }

    public void OnNextLevelButton()
    {
        if (levelToLoad <= 1)
        {
            FindObjectOfType<SoundManager>().PlaySFX("BackgroundMusic");
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
        FindObjectOfType<SoundManager>().PlaySFX("BackgroundMusic");
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
}
