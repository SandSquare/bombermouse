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

    [SerializeField, Range(-2, 2)]
    public int powerUpValue = 1;
     
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        //uimanager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        levelInfo = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        isColliding = false;
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
