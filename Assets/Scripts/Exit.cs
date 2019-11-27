using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField]
    public int loadLevel = 0;
    private bool isColliding = false;
    //GameManager gm;
    LevelTimer timer;
    int level;

    private void Start()
    {
        //gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        isColliding = false;
        level = GameManager.instance.level;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            Debug.Log("Exit found" + isColliding);
            isColliding = true;
            // TODO: Level points 1-3
            SavePoints();

            FindObjectOfType<SoundManager>().PlaySFX("LevelComplete");

            other.gameObject.GetComponent<Movement>().enabled = false;
            //FindObjectOfType<SoundManager>().PlaySFX("LevelComplete");

            SoundManager.Instance.Stop(SoundManager.Instance.currentMusicSource.name);
            //FindObjectOfType<SoundManager>().Stop(SoundManager.Instance.currentMusicSource.name);
            //Debug.Log()
            if (GameManager.instance.level>= GameManager.instance.maxLevels - 1)
            {
                GameManager.instance.GameClear();
            }
            else
            {
                UIManager.Instance.OpenWinPanel(loadLevel);
            }
            //GameManager.instance.LoadNextScene(loadLevel);
            //GameManager.LoadScene(GameManager.GetActiveScene().buildIndex);
        }
    }

    private void SavePoints()
    {
        int score = 1;
        timer = GameObject.FindWithTag("Timer").GetComponent<LevelTimer>();
        float bestTime = LevelInfo.instance.clearTime;
        if (timer.levelTimer < bestTime)
        {
            score = 3;
        }
        else if (timer.levelTimer < bestTime * 2)
        {
            score = 2;
        }
        int previousBestTime = LevelManager.instance.levelPoints[level - 2];
        LevelManager.instance.levelPoints[GameManager.instance.level - 2] = Mathf.Max(previousBestTime,score);
        int nextLevelPreviousTime = LevelManager.instance.levelPoints[level - 1];
        LevelManager.instance.levelPoints[GameManager.instance.level - 1] = Mathf.Max(nextLevelPreviousTime, 0);
        SaveSystem.SaveGameData(LevelManager.instance);
    }
}
