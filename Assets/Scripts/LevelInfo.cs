﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField]
    private string levelName;
    [SerializeField, Range(0,50)]
    public int bombAmount = 0;
    [SerializeField, Range(0,11)]
    public int explosionLength;
    [SerializeField]
    public ObjectColors objectColors = ObjectColors.Normal;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateColor(ObjectColors color)
    {
        this.objectColors = color;
        Debug.Log(color);
    }
}
