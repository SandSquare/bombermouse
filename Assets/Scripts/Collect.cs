using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour
{
    GameManager gm;
    UIManager uimanager;
    LevelInfo levelInfo;
    private Player player;
    private bool isColliding = false;

    public ObjectColors pickupType = ObjectColors.Normal;

    public ItemType ItemProperty = ItemType.Bomb;

    [SerializeField]
    public int powerUpValue = 18;
     
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        //uimanager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        levelInfo = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        isColliding = false;
        powerUpValue = 18;
    }



    private void Update()
    {  
    }

    public enum ItemType
    {
        Bomb,
        PowerUp
    }
}
