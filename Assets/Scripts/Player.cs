using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    private float x;
    private float y;
    // private float step;
    // private bool horizontalDown;
    // private bool verticalDown;
    Vector3 direction;
    private bool legalMove;
    [SerializeField]
    GameObject bomb;

    void Start()
    {
        speed = 10;
        // horizontalDown = false;
        // verticalDown = false;
        legalMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        #region InputGetKey
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            direction = Vector3.down;
        }
        else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.zero;
        }
        Move();

        if (Input.GetKeyDown("space"))
        {
            GameObject.Instantiate(bomb, transform.position, Quaternion.identity);
        }
    }

    private void Move()
    {
        legalMove = AttemptMove();
        if (direction != Vector3.zero && legalMove)
        {
            Vector3 newPosition = direction + transform.position;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 1);
        }
        #endregion

        #region InputGetAxis
        // x = Input.GetAxisRaw("Horizontal");
        // y = Input.GetAxisRaw("Vertical");
        // step = speed * Time.deltaTime;

        // Vector3 newPosition = new Vector3(x, y, 0) + transform.position;
        // while (transform.position != newPosition)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        // }

        // if (x != 0 && !horizontalDown)
        // {
        //     horizontalDown = true;
        //     y = 0;
        // }
        // else if (y != 0 && !verticalDown)
        // {
        //     verticalDown = true;
        //     x = 0;
        // }

        // if (horizontalDown || verticalDown)
        // {
        //     Vector3 newPosition = new Vector3(x, y, 0) + transform.position;
        //     transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        //     horizontalDown = false;
        //     verticalDown = false;
        // }
        #endregion
    }

    private bool AttemptMove()
    {
        bool canMove = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.gameObject.tag);

            canMove = false;
        }
        this.GetComponent<BoxCollider2D>().enabled = true;
        return canMove;
    }
}
