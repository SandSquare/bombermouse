using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool legalMove;

    [SerializeField]
    GameObject[] bombPrefabs;
    Movement movement;
    GameManager gm;

    private LevelInfo levelInfo;
    public int explosionLength;
    private int currentBombAmount;
    
    List<ObjectColors> bombList = new List<ObjectColors>();


    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        legalMove = true;
        movement = GetComponent<Movement>();
        levelInfo = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();

        explosionLength = levelInfo.explosionLength;
        currentBombAmount = levelInfo.bombAmount;

        for (int i = 0; i < levelInfo.bombAmount; i++)
        {
            bombList.Add(ObjectColors.Normal);
        }
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
        else if (Input.GetKeyDown("r"))
        {
            //Debug.Log("moro");
            gm.RestartLevel();
        }
    }

    private void DropBomb()
    {
        if (bombList.Count > 0)
        { 
            Instantiate(bombPrefabs[(int)bombList[0]], new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0), bombPrefabs[(int)bombList[0]].transform.rotation);
            bombList.RemoveAt(0);
            currentBombAmount--;
            
        }
    }
}
