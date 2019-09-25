using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{


    [SerializeField]
    GameObject explosionPrefab;

    [SerializeField]
    LayerMask indestructibleMask;
    [SerializeField]
    LayerMask destructibleMask;

    [SerializeField, Range (0, 20)]
    int explosionLength = 3;

    [SerializeField, Range(0, 0.1f)]
    float explosionExpandingTime = 0.02f;

    private float timer;
    private float fuseTime = 2.0f;

    void Start()
    {
        Invoke("Explode", fuseTime);
    }


    void Update()
    {
        timer += Time.deltaTime;
        //if (timer > fuseTime)
        //{
        //    timer = 0;
        //    Explode();
        //}
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        StartCoroutine(CreateExplosions(Vector3.up));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.down));
        StartCoroutine(CreateExplosions(Vector3.left));

        GetComponent<SpriteRenderer>().enabled = false;

        //MakeFires();
    }

    private void MakeFires()
    {
        for (int i = 1; i <= explosionLength + 1; i++)
        {
            Instantiate(explosionPrefab, transform.position - new Vector3(i, 0, 0), Quaternion.identity, transform.parent);
        }
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        GameObject explosion;

        for (int i = 1; i < explosionLength; i++)
        {
            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position, direction, i, indestructibleMask);

            if (!hit.collider)
            { 
                explosion = Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);

                if (explosion.GetComponent<BoxCollider2D>().IsTouchingLayers(destructibleMask))
                {
                    break;
                }
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(explosionExpandingTime);
        }
    }
}
