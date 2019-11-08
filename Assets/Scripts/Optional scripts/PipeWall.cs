using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeWall : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeExit1, pipeExit2;

    private int explosionLength;

    [SerializeField]
    private LayerMask indestructibleMask;
    [SerializeField]
    private LayerMask destructibleMask;
    // EI TOIMI ERI VÄRISILLÄ POMMEILLA. PITÄÄ LÄHETTÄÄ BOMB.cs pommin väri tai itse prefab joka on osunut pipeen.
    [SerializeField]
    private GameObject explosionPrefab;

    public void CreateExplosion(int length, Vector3 explosionEntry)
    {
        explosionLength = length;
        if(pipeExit1.transform.position == explosionEntry)
        {
            InstatiateExplosions( pipeExit2.transform.position - transform.position, pipeExit2.transform.position);
        }
        else if(pipeExit2.transform.position == explosionEntry)
        {
            InstatiateExplosions(pipeExit1.transform.position - transform.position, pipeExit1.transform.position);
        }
    }

    private void InstatiateExplosions(Vector3 direction, Vector3 startPoint)
    {
        GameObject explosion;
        Vector3 lastExplosionPosition = transform.position;

        for (int i = 1; i <= explosionLength; i++)
        {
            RaycastHit2D hit, wallHit;

            hit = Physics2D.Raycast(startPoint, direction, i, indestructibleMask);
            wallHit = Physics2D.Raycast(startPoint, direction, i, destructibleMask);

            Debug.DrawRay(lastExplosionPosition, direction, Color.blue, 2);

            if (hit)
            {
                if (hit.collider.gameObject.CompareTag("Pipe"))
                {
                    Debug.Log("PIPE HIT");
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

            if (!hit.collider && wallHit.collider)
            {
                explosion = Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
                lastExplosionPosition = transform.position + (i * direction);

                if (explosion.GetComponent<BoxCollider2D>().IsTouchingLayers(destructibleMask))
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }

}
