using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    IEnumerator m_MoveCoroutine;

    [SerializeField]
    float m_SpeedFactor;

    int xDir;
    int yDir;
    bool legalMove;
    Vector2 direction;

    [SerializeField]
    LayerMask solid;

    void Update()
    {
        // if character is already moving, just return
        if (m_MoveCoroutine != null)
            return;


        if (yDir != 0 && xDir == 0)
        {
            xDir = (int)Input.GetAxisRaw("Horizontal");
            yDir = 0;
        }
        else if (xDir != 0 && yDir == 0)
        {
            yDir = (int)Input.GetAxisRaw("Vertical");
            xDir = 0;
        }
        else
        {
            xDir = (int)Input.GetAxisRaw("Horizontal");
            yDir = (int)Input.GetAxisRaw("Vertical");
        }

        if (xDir != 0 && yDir != 0)
        {
            yDir = 0;
        }


        direction = new Vector2(xDir, yDir);
        legalMove = AttemptMove();

        if (direction != Vector2.zero && legalMove)
        {
            // start moving your character
            m_MoveCoroutine = Move(direction);
            StartCoroutine(m_MoveCoroutine);
        }
    }

    private bool AttemptMove()
    {
        bool canMove = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, solid.value);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.CompareTag("Wall1"))
            {
            }
            canMove = false;
            //Debug.Log("Exit found.");
        }
        this.GetComponent<BoxCollider2D>().enabled = true;
        return canMove;
    }

    IEnumerator Move(Vector2 direction)
    {
        // Lerp(Vector2 a, Vector2 b, float t);
        Vector2 orgPos = transform.position; // original position
        Vector2 newPos = orgPos + direction; // new position after move is done
        float t = 0; // placeholder to check if we're on the right spot
        while (t < 1.0f) // loop while player is not in the right spot
        {
            // calculate and set new position based on the deltaTime's value
            transform.position = Vector2.Lerp(orgPos, newPos, (t += Time.deltaTime * m_SpeedFactor));
            // wait for new frame
            yield return new WaitForEndOfFrame();
        }
        // stop coroutine
        StopCoroutine(m_MoveCoroutine);
        // get rid of the reference to enable further movements
        m_MoveCoroutine = null;
    }
}

