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

        // Debug.Log(destructibleWall.value + "   " + gameObject.layer);
        timer += Time.deltaTime;
        if (timer > burnTime)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
    
    
}
