using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool hitpointWall;
    [SerializeField]
    private int healthPoint;
    [SerializeField]
    private WallType ColorType = WallType.Normal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageWall(int wallDamage)
    {
        if(healthPoint > 1)
        {
            healthPoint -= wallDamage;
        }
        else if (healthPoint == 1)
        {
            Destroy(gameObject);
        }
    }

    public enum WallType
    {
        Normal,
        Blue,
        Red,
        Orange
    }
}
