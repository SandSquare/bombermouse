using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator menuPanel;
    //public Animator dialog;
    GameObject inventoryUI;

    //public static UIManager Instance = null;

    //private void Awake()
    //{
    //    // If there is not already an instance of SoundManager, set it to this.
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    //If an instance already exists, destroy whatever this object is to enforce the singleton.
    //    else if (Instance != this)
    //    {
    //        Destroy(gameObject);
    //    }

    //    //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
    //    DontDestroyOnLoad(gameObject);
    //}

    void Start()
    {
        //inventoryUI = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        //Debug.Log("lopetus");
        Application.Quit();
    }

    public void PlayOrPauseMusic()
    {
        SoundManager.Instance.PlayOrPauseMusic();
    }
         
    public void MenuButton()
    {
        
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }


    public void OpenSettings()
    {
        menuPanel.SetBool("isHidden", true);
    }

    public void CloseSettings()
    {
        menuPanel.SetBool("isHidden", false);
    }

    public void UpdateUI()
    {

    }

    public void AddBomb(ObjectColors pickupType)
    {
        //inventoryUI
    }
}
