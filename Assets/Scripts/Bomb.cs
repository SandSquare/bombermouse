using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{


    [SerializeField]
    GameObject fire;

    [SerializeField]
    int length = 2;

    private float timer;
    private float fuseTime = 2.0f;

    void Start()
    {
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fuseTime)
        {
            timer = 0;
            Explode();
        }
    }

    private void Explode()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        MakeFires();
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    private void DestroyFires()
    {
    }

    private void MakeFires()
    {
        for (int i = 1; i <= length + 1; i++)
        {
            Instantiate(fire, transform.position - new Vector3(i, 0, 0), Quaternion.identity, transform.parent);
        }
    }
}
