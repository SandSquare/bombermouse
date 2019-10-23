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

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddBomb(Bomb newBomb)
    {
        //Instantiate(newBombSlot, Vector3.zero, Quaternion.identity);
        //bombSlot = newBomb;
    }

    void UpdateUI()
    {

    }

    public void AddBomb(GameObject gameObject)
    {
        //throw new NotImplementedException();
    }
}
