using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayMusic("Menumusic");
    }
    
    public void NewGame()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 2);
        SceneManager.LoadScene(2);  
    }

    public void SaveGame()
    {
        SaveSystem.SaveGameData(LevelManager.instance);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGameData();
        if (data != null)
        {
            LevelManager.instance.levelPoints = data.levelPoints;
            LevelManager.instance.title = data.title;
        }
    }


    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayClick()
    {
        SoundManager.Instance.PlaySFX("Click2");
    }

}
