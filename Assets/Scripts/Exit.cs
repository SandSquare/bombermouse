using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private bool isColliding = false;
    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        isColliding = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            Debug.Log("Exit found" + isColliding);
            isColliding = true;
            gm.LoadNextScene();
            //GameManager.LoadScene(GameManager.GetActiveScene().buildIndex);
        }
    }
}
