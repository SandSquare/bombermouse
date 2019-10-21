
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public SpriteRenderer icon;
    Bomb bomb;

    public void AddItem(Bomb newBomb)
    {
        bomb = newBomb;
        //icon.sprite = bomb.GetComponent<SpriteRenderer>();
    }

}
