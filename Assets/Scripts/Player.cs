using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    Sprite powerUp;

    private HelpMessage helpMessageUI;

    public List<ObjectColors> bombList = new List<ObjectColors>();
    private bool isColliding = false;

    [HideInInspector]
    public ObjectColors currentColor = ObjectColors.Normal;
    [HideInInspector]
    public Dictionary<ObjectColors, int> bombCountDictionary;

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

        UpdateBombAmounts();
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.Instance.windowOpen && !GameManager.instance.doingSetup)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                //ToggleDropBomb();
                DropBomb();
            }

            if (Input.GetButtonDown("Fire3"))
            {
                //ToggleBomb();
                //InventoryUI.instance.SelectionHighlight();
            }
        }
    }

    public void UpdateBombAmounts()
    {
        bombCountDictionary = bombList.GroupBy(r => r).Select(grp => new
        {
            Value = grp.Key,
            Count = grp.Count()
        }).ToDictionary(e => e.Value, e => e.Count);

        if (!bombCountDictionary.ContainsKey(ObjectColors.Normal))
        {
            bombCountDictionary.Add(ObjectColors.Normal, 0);
        }

        if (!bombCountDictionary.ContainsKey(ObjectColors.Purple))
        {
            bombCountDictionary.Add(ObjectColors.Purple, 0);
        }

        if (!bombCountDictionary.ContainsKey(ObjectColors.Green))
        {
            bombCountDictionary.Add(ObjectColors.Green, 0);
        }

        if (!bombCountDictionary.ContainsKey(ObjectColors.Red))
        {
            bombCountDictionary.Add(ObjectColors.Red, 0);
        }

        //foreach (var item in bombCountDictionary)
        //{
        //    Debug.LogFormat("Value: {0}, Count: {1}", item.Key, item.Value);
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fire") && !isColliding)
        {
            // Fire kills players only during 0.6 seconds of the explosion
            if (other.GetComponent<Fire>().timer < 0.6f)
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
                //UpdateBombAmounts();
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
                InventoryUI.instance.PowerUpPicked();
                //InventoryUI.instance.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = ;
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

    //private void ToggleBomb()
    //{
    //    if (bombList.Count > 0)
    //    {
    //        if (currentColor < ObjectColors.Red)
    //        {
    //            currentColor++;
    //        }
    //        else
    //        {
    //            currentColor = ObjectColors.Normal;
    //        }
    //    }
    //}

    private void ToggleDropBomb()
    {
        if (bombList.Count > 0)
        {


            //if (bombList.Contains(currentColor))
            //{
            //    GameObject b = Instantiate(bombPrefabs[(int)currentColor], new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0), bombPrefabs[(int)bombList[bombList.Count - 1]].transform.rotation);
            //    b.GetComponent<Bomb>().explosionLength = explosionLength;
            //    explosionLength = levelInfo.explosionLength;
            //    bombList.Remove(currentColor);
            //    UpdateBombAmounts();
            //    InventoryUI.instance.UpdateCounts();
            //}
        }
    }
}
