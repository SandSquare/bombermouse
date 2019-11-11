using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance = null;

    //public List<Text> bombList;
    //public GameObject canvas;
    //Inventory inventory;
    [SerializeField]
    public GameObject bombSlot;

    [SerializeField]
    private Sprite[] bombColors;

    [SerializeField]
    private int maxSize = 6;

    private bool bombDeleted = false;

    [SerializeField]
    private TextMeshProUGUI explosionLengthText;


    // Start is called before the first frame update
    void Start()
    {
        Init();
        //inventory = Inventory.instance;

        //canvas = this.gameObject;
        //bombList = canvas.transform.GetChild(0).Get;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Two Inventories!!");
            Destroy(gameObject);
            return;
        }
    }

    public void Init()
    {
        int length = LevelInfo.instance.bombAmount;
        for (int i = 0; i < length; i++)
        {
            GameObject newSlot = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
            newSlot.transform.SetParent(this.gameObject.transform);
        }

        HighlightFirstBomb();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HighlightFirstBomb()
    {
        for (int i = 0; i< gameObject.transform.childCount; i++)
        {
            GameObject bombSlotChild = gameObject.transform.GetChild(i).gameObject;

            if(i == 0 && !bombDeleted)
            {
                bombSlotChild.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if(i == 1 && bombDeleted)
            {
                bombSlotChild.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                bombSlotChild.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        explosionLengthText.text = FindObjectOfType<Player>().explosionLength.ToString();
    }


    public void AddBomb(GameObject gameObject)
    {
        GameObject newSlot = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
        newSlot.transform.GetChild(1).GetComponent<Image>().sprite = bombColors[(int)gameObject.GetComponent<Collect>().pickupType];

        newSlot.transform.SetParent(this.gameObject.transform);
        newSlot.transform.SetSiblingIndex(0);



        if (this.gameObject.transform.childCount > maxSize + 1)
        {
            Destroy(this.gameObject.transform.GetChild(maxSize - 1).gameObject);
        }
        bombDeleted = false;
        HighlightFirstBomb();
    }

    public void RemoveBomb()
    {
        if (this.gameObject.transform.childCount != 0)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }

        bombDeleted = true;
        HighlightFirstBomb();
    }
}
