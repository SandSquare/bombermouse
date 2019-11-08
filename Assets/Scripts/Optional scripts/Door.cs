using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isPowered = false;

    private Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isPowered)
        {
            PowerOn();
        }
    }

    public void PowerOn()
    {
        isPowered = true;
        collider.enabled = false;
    }

    public void PowerOff()
    {
        isPowered = false;
        collider.enabled = true;
    }
}
