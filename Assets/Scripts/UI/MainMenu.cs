using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void NewGame()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 2);
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    // Start is called before the first frame update

}
