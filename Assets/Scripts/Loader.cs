using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;            //GameManager prefab to instantiate.


    void Awake()
    {

        if (GameManager.instance == null)
            Instantiate(gameManager);

        //SceneManager.LoadSceneAsync(8, LoadSceneMode.Additive);
        //SceneManager.LoadScene(8, LoadSceneMode.Additive);

        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        //if (SoundManager.instance == null)

        //    //Instantiate SoundManager prefab
        //    Instantiate(soundManager);
    }
}
