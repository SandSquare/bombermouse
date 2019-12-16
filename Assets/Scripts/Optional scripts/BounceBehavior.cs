using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehavior : MonoBehaviour
{
    float floatSpan = 2.0f;
    float speed = 1.0f;

    private float startY;
 
    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, (float)(startY + Mathf.Sin(Time.time * speed) * floatSpan / 2.0), 0);
    }

}
