using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private float timer;

    [SerializeField]
    private float burnTime = 2.0f;

    [SerializeField]
    private LayerMask destructibleWall;

    [SerializeField]
    private Sprite[] fireSprites;

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

    void Start()
    {
        ChangeSprite();
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

    void ChangeSprite()
    {
        if (isHorizontal)
        {
            spriteRenderer.sprite = fireSprites[0];
            if (isLeft)
            {
                spriteRenderer.sprite = fireSprites[4];
            }
            else if(isRight)
            {
                spriteRenderer.sprite = fireSprites[5];
            }
        }else if(isVertical)
        {
            spriteRenderer.sprite = fireSprites[1];
            if (isUp)
            {
                spriteRenderer.sprite = fireSprites[6];
            }
            else if(isDown)
            {
                spriteRenderer.sprite = fireSprites[3];
            }
        }
        else
        {
            spriteRenderer.sprite = fireSprites[2];
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers())
        {
            if (collision.gameObject.layer == 9)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
