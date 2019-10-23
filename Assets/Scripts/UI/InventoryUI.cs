using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void AddBomb(GameObject gameObject)
    {
        Debug.Log("Bomb added to inventory");
        //ObjectColors color = gameObject.GetComponent<Collect>().pickupType;
        GameObject newSlot = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
        newSlot.transform.GetChild(0).GetComponent<Image>().sprite = bombColors[(int)gameObject.GetComponent<Collect>().pickupType];
        //newSlot.GetComponent<Collect>().pickupType = color;

        //bombSlot.GetComponent<Image>();
        newSlot.transform.SetParent(this.gameObject.transform);
        //newSlot.transform.SetSiblingIndex(gameObject.transform.childCount);
    }

    public void RemoveBomb()
    {
        Destroy(gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject);
    }
}
