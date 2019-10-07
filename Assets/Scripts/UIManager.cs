using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

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

}
