using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //GameManager.LoadScene(1);
            //GameManager.LoadScene(SceneManager.GetActiveScene());
        }
    }
}
