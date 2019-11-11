using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private Door affectedObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!affectedObject.isPowered && collision.gameObject.tag == "Bomb")
        {
            Debug.Log("DOOR OPENED!");
            affectedObject.PowerOn();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!affectedObject.isPowered && collision.gameObject.tag == "Bomb")
        {
            Debug.Log("DOOR OPENED!");
            affectedObject.PowerOn();
        }
    }
}
