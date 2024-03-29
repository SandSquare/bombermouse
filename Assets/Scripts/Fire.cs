﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float timer;

    private int damage = 1;
    private bool wallDamaged = false;

    [SerializeField]
    private ObjectColors fireColor;

    [SerializeField]
    private float burnTime = 2.0f;

    [SerializeField]
    private LayerMask destructibleWall;

    private SpriteRenderer spriteRenderer;

    [HideInInspector]
    public bool isHorizontal = false;
    [HideInInspector]
    public bool isLeft = false;
    [HideInInspector]
    public bool isRight = false;
    [HideInInspector]
    public bool isVertical = false;
    [HideInInspector]
    public bool isUp = false;
    [HideInInspector]
    public bool isDown = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > burnTime)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject wallHit = collision.gameObject;

        if (collision.IsTouchingLayers() && !wallDamaged)
        {
            if (wallHit.layer == 9 && wallHit.GetComponent<Wall>().wallColor == fireColor)
            {
                wallHit.GetComponent<Wall>().DamageWall(damage);
                wallDamaged = true;
            }
        }
    }
}
