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

    void Start()
    {
        inventoryUI = this.gameObject.transform.GetChild(0).gameObject;
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
