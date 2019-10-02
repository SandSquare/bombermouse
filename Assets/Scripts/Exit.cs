using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            GameManager.LoadNextScene();
            //GameManager.LoadScene(GameManager.GetActiveScene().buildIndex);
        }
    }
}
