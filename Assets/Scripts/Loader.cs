﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;            //GameManager prefab to instantiate.


    void Awake()
    {

        if (GameManager.instance == null)
            Instantiate(gameManager);

        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        //if (SoundManager.instance == null)

        //    //Instantiate SoundManager prefab
        //    Instantiate(soundManager);
    }
}
