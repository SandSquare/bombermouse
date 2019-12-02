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

    private Player player;

    GameObject normalCount;
    GameObject purpleCount;
    GameObject greenCount;
    GameObject redCount;


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

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Init()
    {

        //foreach(var color in player.bombCountDictionary)
        //{
        //    if (color.Key == ObjectColors.Normal)
        //    {
        //        normalCount = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
        //        normalCount.transform.SetParent(this.gameObject.transform);
        //        normalCount.transform.GetChild(1).GetComponent<Image>().sprite = bombColors[0];
        //        normalCount.GetComponentInChildren<TextMeshProUGUI>().text = color.Value.ToString();
        //    }
        //    if(color.Key == ObjectColors.Purple)
        //    {
        //        purpleCount = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
        //        purpleCount.transform.SetParent(this.gameObject.transform);
        //        purpleCount.transform.GetChild(1).GetComponent<Image>().sprite = bombColors[1];
        //        purpleCount.GetComponentInChildren<TextMeshProUGUI>().text = color.Value.ToString();
        //    }
        //    if (color.Key == ObjectColors.Green)
        //    {
        //        greenCount = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
        //        greenCount.transform.SetParent(this.gameObject.transform);
        //        greenCount.transform.GetChild(1).GetComponent<Image>().sprite = bombColors[2];
        //        greenCount.GetComponentInChildren<TextMeshProUGUI>().text = color.Value.ToString();
        //    }
        //    if (color.Key == ObjectColors.Red)
        //    {
        //        redCount = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
        //        redCount.transform.SetParent(this.gameObject.transform);
        //        redCount.transform.GetChild(1).GetComponent<Image>().sprite = bombColors[3];
        //        redCount.GetComponentInChildren<TextMeshProUGUI>().text = color.Value.ToString();
        //    }

        //}
        //SelectionHighlight();

        int length = LevelInfo.instance.bombAmount;
        for (int i = 0; i < length; i++)
        {
            GameObject newSlot = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
            newSlot.transform.SetParent(this.gameObject.transform);
        }

        HighlightFirstBomb();
    }

    //public void SelectionHighlight()
    //{
    //    if(player.currentColor == ObjectColors.Normal)
    //    {
    //        normalCount.transform.GetChild(0).gameObject.SetActive(true);

    //        purpleCount.transform.GetChild(0).gameObject.SetActive(false);
    //        greenCount.transform.GetChild(0).gameObject.SetActive(false);
    //        redCount.transform.GetChild(0).gameObject.SetActive(false);
    //    }
    //    if(player.currentColor == ObjectColors.Purple)
    //    {
    //        purpleCount.transform.GetChild(0).gameObject.SetActive(true);

    //        greenCount.transform.GetChild(0).gameObject.SetActive(false);
    //        redCount.transform.GetChild(0).gameObject.SetActive(false);
    //        normalCount.transform.GetChild(0).gameObject.SetActive(false);
    //    }
    //    if(player.currentColor == ObjectColors.Green)
    //    {
    //        greenCount.transform.GetChild(0).gameObject.SetActive(true);

    //        redCount.transform.GetChild(0).gameObject.SetActive(false);
    //        purpleCount.transform.GetChild(0).gameObject.SetActive(false);
    //        normalCount.transform.GetChild(0).gameObject.SetActive(false);
    //    }
    //    if(player.currentColor == ObjectColors.Red)
    //    {
    //        redCount.transform.GetChild(0).gameObject.SetActive(true);

    //        greenCount.transform.GetChild(0).gameObject.SetActive(false);
    //        purpleCount.transform.GetChild(0).gameObject.SetActive(false);
    //        normalCount.transform.GetChild(0).gameObject.SetActive(false);
    //    }
    //}

    public void HighlightFirstBomb()
    {
        for (int i = 0; i< gameObject.transform.childCount; i++)
        {
            GameObject bombSlotChild = gameObject.transform.GetChild(i).gameObject;

            if(i == 0 && !bombDeleted)
            {
                bombSlotChild.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                bombSlotChild.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if(i == 1 && bombDeleted)
            {
                bombSlotChild.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                bombSlotChild.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                bombSlotChild.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                bombSlotChild.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        explosionLengthText.text = FindObjectOfType<Player>().explosionLength.ToString();
    }


    public void AddBomb(GameObject gameObject)
    {
        GameObject newSlot = Instantiate(bombSlot, Vector3.zero, Quaternion.identity);
        newSlot.transform.GetChild(0).GetComponent<Image>().sprite = bombColors[(int)gameObject.GetComponent<Collect>().pickupType];

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

    //public void UpdateCounts()
    //{
    //    foreach (var color in player.bombCountDictionary)
    //    {
    //        if (color.Key == ObjectColors.Normal && color.Value.ToString() != normalCount.GetComponentInChildren<TextMeshProUGUI>().text)
    //        {
    //            normalCount.GetComponentInChildren<TextMeshProUGUI>().text = color.Value.ToString();
    //        }
    //        if (color.Key == ObjectColors.Purple)
    //        {
    //            purpleCount.GetComponentInChildren<TextMeshProUGUI>().text = color.Value.ToString();
    //        }
    //        if (color.Key == ObjectColors.Green)
    //        {
    //            greenCount.GetComponentInChildren<TextMeshProUGUI>().text = color.Value.ToString();
    //        }
    //        if (color.Key == ObjectColors.Red)
    //        {
    //            redCount.GetComponentInChildren<TextMeshProUGUI>().text = color.Value.ToString();
    //        }
    //    }
    //}
}
