﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField]
    public int loadLevel = 0;
    private bool isColliding = false;
    //GameManager gm;

    private void Start()
    {
        //gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            Debug.Log("Exit found" + isColliding);
            isColliding = true;
            LevelManager.instance.levelPoints[GameManager.instance.level - 1] = 1;
            SaveSystem.SaveGameData(LevelManager.instance);
            FindObjectOfType<SoundManager>().PlaySFX("LevelComplete");
            FindObjectOfType<SoundManager>().Stop("BackgroundMusic");
            UIManager.Instance.OpenWinPanel(loadLevel);
            //GameManager.instance.LoadNextScene(loadLevel);
            //GameManager.LoadScene(GameManager.GetActiveScene().buildIndex);
        }
    }
}
