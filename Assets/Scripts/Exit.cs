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
            // TODO: Level points 1-3
            LevelManager.instance.levelPoints[GameManager.instance.level - 2] = 1;
            LevelManager.instance.levelPoints[GameManager.instance.level - 1] = 0;
            SaveSystem.SaveGameData(LevelManager.instance);

            FindObjectOfType<SoundManager>().PlaySFX("LevelComplete");

            other.gameObject.GetComponent<Movement>().enabled = false;
            FindObjectOfType<SoundManager>().PlayMusic("LevelComplete");

            FindObjectOfType<SoundManager>().Stop("BackgroundMusic");
            UIManager.Instance.OpenWinPanel(loadLevel);
            //GameManager.instance.LoadNextScene(loadLevel);
            //GameManager.LoadScene(GameManager.GetActiveScene().buildIndex);
        }
    }
}
