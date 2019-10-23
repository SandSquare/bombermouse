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

    // Start is called before the first frame update
    void Start()
    {

        //inventory = Inventory.instance;

        //canvas = this.gameObject;
        //bombList = canvas.transform.GetChild(0).Get;
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
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
            AddBomb(bombSlot);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddBomb(GameObject gameObject)
    {
        Debug.Log("Bomb added to inventory");
        GameObject newSlot = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
        //bombSlot.GetComponent<Image>();
        newSlot.transform.SetParent(this.gameObject.transform);
        newSlot.transform.SetSiblingIndex(0);
    }

    public void RemoveBomb()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }
}
