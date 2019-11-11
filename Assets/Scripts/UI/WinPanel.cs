using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    GameObject star2;
    [SerializeField]
    GameObject star3;
    [SerializeField]
    private LevelTimer levelTimer;

    //private LevelInfo levelInfo;
    private float levelClearTime;


    // Start is called before the first frame update
    void Start()
    {
        //levelInfo = GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<LevelInfo>();

        GetTime();
        DisplayStars();
    }

    void GetTime()
    {
        levelClearTime = levelTimer.LevelCleared();
    }

    void DisplayStars()
    {
        if (levelClearTime < LevelInfo.instance.clearTimes[1])
        {
            // 3 star time
            star2.GetComponent<Image>().color = Color.yellow;
            star3.GetComponent<Image>().color = Color.yellow;
        }
        else if (levelClearTime < LevelInfo.instance.clearTimes[0])
        {
            // 2 star time
            star2.GetComponent<Image>().color = Color.yellow;
        }
    }
}
