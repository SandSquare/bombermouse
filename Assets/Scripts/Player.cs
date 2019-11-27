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

    private HelpMessage helpMessageUI;

    public List<ObjectColors> bombList = new List<ObjectColors>();
    private bool isColliding = false;

    void Start()
    {
        legalMove = true;
        movement = GetComponent<Movement>();


        helpMessageUI = GameObject.Find("HelpMessageUI")?.GetComponent<HelpMessage>();

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
        if (!UIManager.Instance.windowOpen && !GameManager.instance.doingSetup)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                DropBomb();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fire") && !isColliding)
        {
            // Fire kills players only during 0.6 seconds of the explosion
            if(other.GetComponent<Fire>().timer < 0.6f)
            {
                Lose();
            }   
        }

        if (other.CompareTag("Item") && !isColliding)
        {
            Collect collect = other.gameObject.GetComponent<Collect>();
            //isColliding = true;
            if (collect.ItemProperty == Collect.ItemType.Bomb)
            {
                Debug.Log($"{collect.pickupType} Bomb found!");
                bombList.Add(collect.pickupType);
                FindObjectOfType<SoundManager>().PlaySFX("CollectBomb");
                InventoryUI.instance.AddBomb(other.gameObject);
                if (helpMessageUI)
                {
                    helpMessageUI.PlayerPickUpMessage();
                }
            }
            else if (collect.ItemProperty == Collect.ItemType.PowerUp)
            {
                Debug.Log("PowerUp found!");
                FindObjectOfType<SoundManager>().PlaySFX("PowerUp");
                explosionLength += collect.powerUpValue;
                if (helpMessageUI)
                {
                    helpMessageUI.PlayerPowerUpMessage();
                }
                
            }
            Destroy(other.gameObject);
        }
    }

    private void Lose()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        //Play death animation and then open lose panel

        UIManager.Instance.OpenLosePanel();
        FindObjectOfType<SoundManager>().Stop("BackgroundMusic");
        FindObjectOfType<SoundManager>().PlaySFX("GameOver");
    }

    private void DropBomb()
    {
        if (bombList.Count > 0)
        {
            GameObject b = Instantiate(bombPrefabs[(int)bombList[bombList.Count - 1]], new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0), bombPrefabs[(int)bombList[bombList.Count - 1]].transform.rotation);
            b.GetComponent<Bomb>().explosionLength = explosionLength;
            explosionLength = levelInfo.explosionLength;
            bombList.RemoveAt((int)bombList.Count - 1);
            currentBombAmount--;
            InventoryUI.instance.RemoveBomb();

        }
    }
}
