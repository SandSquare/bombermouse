using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

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
}
