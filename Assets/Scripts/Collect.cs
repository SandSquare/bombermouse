using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour
{
    GameManager gm;
    LevelInfo levelInfo;
    private Player player;
    private bool isColliding = false;

    [SerializeField]
    ObjectColors pickupType = ObjectColors.Normal;

    [SerializeField]
    private ItemType ItemProperty = ItemType.Bomb;

    [SerializeField, Range(-2, 2)]
    int powerUpValue = 1;
     
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        levelInfo = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            isColliding = true;
            if (ItemProperty == ItemType.Bomb)
            {
                Debug.Log("Bomb found!");
                player.bombList.Add(pickupType);
            }
            if (ItemProperty == ItemType.PowerUp)
            {
                Debug.Log("PowerUp found!");
                player.explosionLength += powerUpValue;
            }
            Destroy(gameObject);
        }
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
