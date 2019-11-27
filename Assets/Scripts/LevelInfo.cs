﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField]
    public string levelName = "Make your way out!";
    [SerializeField, Range(0, 50)]
    public int bombAmount = 0;
    [SerializeField, Range(0, 11)]
    public int explosionLength;
    [SerializeField]
    public ObjectColors objectColors = ObjectColors.Normal;
    [SerializeField, Tooltip("in seconds")]
    public float clearTime = 5.0f;

    public static LevelInfo instance = null;

    
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic("BGM2");
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Two instaances!!");
            Destroy(gameObject);
            return;
        }
        //GameManager.instance.levelName.text = levelName;
    }

    public void UpdateColor(ObjectColors color)
    {
        this.objectColors = color;
        Debug.Log(color);
    }

    public void UpdateLevelName()
    {
        //GameManager.instance.levelName.text = levelName;
    }
}
