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

    [SerializeField]
    Sprite filledStar;

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

        if (levelClearTime < LevelInfo.instance.clearTime * 1.5f)
        {
            // 2 star time
            //star2.GetComponent<Image>().color = Color.yellow;
            star2.GetComponent<Image>().sprite = filledStar;

            if (levelClearTime < LevelInfo.instance.clearTime)
            {
                // 3 star time
                star3.GetComponent<Image>().sprite = filledStar;
            }
        }
    }
}
