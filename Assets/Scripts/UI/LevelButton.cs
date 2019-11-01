using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelNumber;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelNumber);
    }
}
