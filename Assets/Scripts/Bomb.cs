using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float lifetime = 2.0f;

    void Start()
    {
        
    }


    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
