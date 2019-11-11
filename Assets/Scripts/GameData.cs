﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int[] levelPoints;
    public string title;

    public GameData(LevelManager levelManager)
    {
        levelPoints = levelManager.levelPoints;
        title = levelManager.title;
    }
}
