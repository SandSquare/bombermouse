using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private bool isColliding = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            Debug.Log("Exit found"+isColliding);
            isColliding = true;
            GameManager.LoadNextScene();
            //GameManager.LoadScene(GameManager.GetActiveScene().buildIndex);
        }
    }
}
