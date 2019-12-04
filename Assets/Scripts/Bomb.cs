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

    [SerializeField, Range(0, 20)]
    public int explosionLength = 3;

    [SerializeField, Range(0, 0.1f)]
    float explosionExpandingTime = 0.02f;

    private float timer;
    private float fuseTime = 2.0f;

    [SerializeField]
    ObjectColors bombColor = ObjectColors.Normal;

    private GameObject player;



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Invoke("Explode", fuseTime);
        //explosionLength = player.GetComponent<Player>().explosionLength;
    }


    void Update()
    {
        timer += Time.deltaTime;
        Animate();
    }

    private void Animate()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        //Color a = s.color;
        //s.color = Color.Lerp(a, Color.red, timer * 0.02f);
        float expansion = 0.1f;
        transform.localScale += Vector3.one * expansion * Time.deltaTime;
    }

    private void Explode()
    {
        //Center explosion sprite switch and instantiate
        SoundManager.Instance.PlaySFX("Bomb");
        GameObject centerFire = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        StartCoroutine(CreateExplosions(Vector3.up));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.down));
        StartCoroutine(CreateExplosions(Vector3.left));

        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, fuseTime);
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        GameObject explosion;
        Vector3 lastExplosionPosition = transform.position;

        for (int i = 1; i <= explosionLength; i++)
        {
            RaycastHit2D hit, wallHit;

            hit = Physics2D.Raycast(transform.position, direction, i, indestructibleMask);
            wallHit = Physics2D.Raycast(transform.position, direction, i, destructibleMask);

            Debug.DrawRay(lastExplosionPosition, direction, Color.blue, 2);

            if (hit)
            {
                if (hit.collider.gameObject.CompareTag("Pipe"))
                {
                    hit.collider.gameObject.GetComponent<PipeWall>().CreateExplosion(explosionLength + 1 - i, lastExplosionPosition);
                    break;
                }
            }

            if (wallHit)
            {
                explosion = Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
                lastExplosionPosition = transform.position + (i * direction);
                break;
            }

            if (!hit.collider && !wallHit.collider)
            {
                explosion = Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
                lastExplosionPosition = transform.position + (i * direction);
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(explosionExpandingTime);
        }
    }
}
