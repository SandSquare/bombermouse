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

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(WallProperty == WallType.HitpointWall)
        {
            //GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
        }
    }
    // This method damages and destroys walls
    public void DamageWall(int wallDamage)
    {
        if(hitpoints > 1 && WallProperty == WallType.HitpointWall)
        {
            hitpoints -= wallDamage;
            FindObjectOfType<SoundManager>().PlaySFX("WoodBoxDamage");
            //GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
            GetComponent<Animator>().enabled = true;
        }
        else if (hitpoints <= 1 && WallProperty == WallType.HitpointWall || WallProperty == WallType.Normal)
        {
            Debug.Log("Normaali seinä tuhottu");
            FindObjectOfType<SoundManager>().PlaySFX("WoodBoxDestroy");
            GetComponent<Animator>().enabled = true;
            animator.SetBool("breakingDown", true);
            Invoke("BreakBox", 0.75f);
        }

        else if (WallProperty == WallType.ColorWall)
        {
            Debug.Log("väri seinä tuhottu");
            FindObjectOfType<SoundManager>().PlaySFX("GlassWallDestroy");
            GetComponent<Animator>().enabled = true;
            Invoke("BreakBox", 0.75f);
        } 
    }

    public void BreakBox()
    {
        Destroy(gameObject, destroyDelay);
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
