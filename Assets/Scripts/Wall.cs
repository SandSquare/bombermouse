﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private WallType WallProperty = WallType.Normal;
    [SerializeField, Range(1,5)]
    private int hitpoints;
    [SerializeField]
    private WallColors wallColor;

    // Start is called before the first frame update
    void Start()
    {
        if(WallProperty == WallType.HitpointWall)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageWall(int wallDamage)
    {
        if(hitpoints > 1 && WallProperty == WallType.HitpointWall)
        {
            hitpoints -= wallDamage;
            GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
        }
        else if (hitpoints <= 1)
        {
            Destroy(gameObject);
        }
    }

    public enum WallType
    {
        Normal,
        HitpointWall,
        ColorWall
    }

    public enum WallColors
    {
        Normal,
        Blue,
        Orange,
        Red,
    }
}
