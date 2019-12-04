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
            helpMessagePanel.SetActive(true);
            helpMessagePanel.transform.position = new Vector3(helpMessagePanel.transform.position.x, helpMessagePanel.transform.position.y - 200, 0);
            helpMessagePanel.transform.GetChild(0).gameObject.SetActive(false);
            helpMessagePanel.transform.GetChild(1).gameObject.SetActive(false);
            helpMessagePanel.transform.GetChild(2).gameObject.SetActive(true);
            hasTriggered = true;
        }
    }

    void FixedUpdate()
    {
        if (hasTriggered && helpMessagePanel.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if (timer > activeTime)
            {
                helpMessagePanel.transform.GetChild(2).gameObject.SetActive(false);
                helpMessagePanel.SetActive(false);
                timer = 0;
            }
        }
    }



}
