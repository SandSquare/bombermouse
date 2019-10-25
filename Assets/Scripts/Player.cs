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
    //GameManager gm;

    private LevelInfo levelInfo;
    public int explosionLength;
    private int currentBombAmount;

    public List<ObjectColors> bombList = new List<ObjectColors>();
    private bool isColliding = false;

    void Start()
    {
        //gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        legalMove = true;
        movement = GetComponent<Movement>();
        //levelInfo = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();

        levelInfo = LevelInfo.instance;
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
            GameManager.instance.RestartLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item") && !isColliding)
        {
            Collect collect = other.gameObject.GetComponent<Collect>();
            //isColliding = true;
            if (collect.ItemProperty == Collect.ItemType.Bomb)
            {
                Debug.Log($"{collect.pickupType} Vial found!");
                bombList.Add(collect.pickupType);
                InventoryUI.instance.AddBomb(other.gameObject);
                //uimanager.AddBomb(pickupType);
            }
            else if (collect.ItemProperty == Collect.ItemType.PowerUp)
            {
                Debug.Log("PowerUp found!");
                explosionLength += collect.powerUpValue;
            }
            Destroy(other.gameObject);
        }
    }



    private void DropBomb()
    {
        if (bombList.Count > 0)
        {
            GameObject b = Instantiate(bombPrefabs[(int)bombList[bombList.Count - 1]], new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0), bombPrefabs[(int)bombList[bombList.Count - 1]].transform.rotation);
            b.GetComponent<Bomb>().explosionLength = explosionLength;
            explosionLength = 3;
            bombList.RemoveAt((int)bombList.Count - 1);
            currentBombAmount--;
            InventoryUI.instance.RemoveBomb();
            
        }
    }
}
