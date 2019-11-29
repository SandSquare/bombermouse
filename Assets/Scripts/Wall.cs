using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    private WallType WallProperty = WallType.Normal;
    [SerializeField, Range(1, 5)]
    private int hitpoints = 1;
    [SerializeField]
    public ObjectColors wallColor;
    [SerializeField, Range(0, 1)]
    private float destroyDelay = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        if(WallProperty == WallType.HitpointWall)
        {
            //GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
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
            FindObjectOfType<SoundManager>().PlaySFX("WoodBoxDamage");
            //GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else if (hitpoints <= 1 && WallProperty == WallType.HitpointWall || WallProperty == WallType.Normal)
        {
            Debug.Log("Normaali seinä tuhottu");
            FindObjectOfType<SoundManager>().PlaySFX("WoodBoxDestroy");
            Destroy(gameObject, destroyDelay);
        }

        else if (WallProperty == WallType.ColorWall)
        {
            Debug.Log("väri seinä tuhottu");
            FindObjectOfType<SoundManager>().PlaySFX("GlassWallDestroy");
            Destroy(gameObject, destroyDelay);
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
    Purple,
    Green,
    Red,
}
