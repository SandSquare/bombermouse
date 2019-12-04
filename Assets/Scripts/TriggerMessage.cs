using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMessage : MonoBehaviour
{

    [SerializeField]
    private GameObject helpMessagePanel;
    private bool hasTriggered = false;
    private float timer = 0;
    public float activeTime = 7f;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !hasTriggered)
        {
            Debug.Log("joo");
            helpMessagePanel.SetActive(true);
            helpMessagePanel.transform.GetChild(2).gameObject.SetActive(true);
            hasTriggered = true;
        }
    }

    void Update()
    {
        if (hasTriggered && helpMessagePanel.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if (timer > activeTime)
            {
                helpMessagePanel.SetActive(false);
                timer = 0;
            }
        }
    }



}
