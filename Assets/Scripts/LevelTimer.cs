using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;

    private bool runTimer;
    private float levelTimer;

    private void Start()
    {
        runTimer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (runTimer && !UIManager.Instance.windowOpen)
        {
            levelTimer += Time.deltaTime;
        }
        
        UpdateLevelTimer(levelTimer);
    }

    private void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StartTimer()
    {
        runTimer = true;
    }

    public void StopTimer()
    {
        runTimer = false;
    }

    public float LevelCleared()
    {
        // call when level is cleared and returns time that it took to clear the level
        StopTimer();
        return levelTimer;
    }

    public void ResetTimer()
    {
        levelTimer = 0;
    }
}
