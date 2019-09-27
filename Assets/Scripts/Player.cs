using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool legalMove;

    [SerializeField]
    GameObject bombPrefab;
    Movement movement;


    void Start()
    {
        legalMove = true;
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //oldMovement 
        #region InputGetKey
        //if (input.getkeydown("w") || input.getkeydown("up"))
        //{
        //    direction = vector3.up;
        //}
        //else if (input.getkeydown("a") || input.getkeydown("left"))
        //{
        //    direction = vector3.left;
        //}
        //else if (input.getkeydown("s") || input.getkeydown("down"))
        //{
        //    direction = vector3.down;
        //}
        //else if (input.getkeydown("d") || input.getkeydown("right"))
        //{
        //    direction = vector3.right;
        //}
        //else
        //{
        //    direction = vector3.zero;
        //}
        #endregion
        if (Input.GetButtonDown("Jump"))
        {
            DropBomb();
        }
    }

    private void DropBomb()
    {
        if (bombPrefab)
        {
            Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0), bombPrefab.transform.rotation);
        }
    }
}
