using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private WallType WallProperty = WallType.Normal;
    [SerializeField, Range(1,5)]
    private int hitpoints = 1;
    [SerializeField]
    public ObjectColors wallColor;

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
    // This method damages and destroys walls
    public void DamageWall(int wallDamage)
    {
        if(hitpoints > 1 && WallProperty == WallType.HitpointWall)
        {
            hitpoints -= wallDamage;
            FindObjectOfType<SoundManager>().Play("WoodBoxDamage");
            GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
        }
        else if (hitpoints <= 1 && WallProperty == WallType.HitpointWall || WallProperty == WallType.Normal)
        {
            Debug.Log("Normaali seinä tuhottu");
            FindObjectOfType<SoundManager>().Play("WoodBoxDestroy");
            Destroy(gameObject);
        }

        else if (WallProperty == WallType.ColorWall)
        {
            Debug.Log("väri seinä tuhottu");
            FindObjectOfType<SoundManager>().Play("GlassWallDestroy");
            Destroy(gameObject);
        } 
    }

    public enum WallType
    {
        Normal,
        HitpointWall,
        ColorWall
    }
}

public enum ObjectColors
{
    Normal,
    Blue,
    Orange,
    Red,
}
