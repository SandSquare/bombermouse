using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loader : MonoBehaviour
{

    public GameObject gameManager;            //GameManager prefab to instantiate.
    public GameObject soundManager;

    [SerializeField]
    private bool soundsOn = false;

    void Awake()
    {

        if (GameManager.instance == null)
            Instantiate(gameManager);

        //SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        if (SoundManager.Instance == null)
            Instantiate(soundManager);
        //    //Instantiate SoundManager prefab
        //    Instantiate(soundManager);
    }
}
