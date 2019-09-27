using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private float timer;

    [SerializeField]
    float burnTime = 2.0f;

    [SerializeField]
    LayerMask destructibleWall;



    // Update is called once per frame
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
        if (collision.IsTouchingLayers())
        {
            if (collision.gameObject.layer == 9)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
