using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpMessage : MonoBehaviour
{
    [SerializeField]
    private GameObject messagePanel;
    [SerializeField]
    private GameObject firstMessage;
    [SerializeField]
    private float firstMessageTime = 5f;
    [SerializeField]
    private GameObject secondMessage;
    [SerializeField]
    private float secondMessageTime = 7f;
    [SerializeField]
    private GameObject powerUpMessage;
    [SerializeField]
    private float powerUpMessageTime = 5f;

    private bool isBombPickedup;
    private bool isPowerupPickedup;

    private float timer;

    private bool firstMessageShown, secondMessageShown;

    // Update is called once per frame
    void Update()
    {
        if (messagePanel)
        {
            timer += Time.deltaTime;
            if (!UIManager.Instance.windowOpen && !GameManager.instance.doingSetup)
            {
                if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || timer > firstMessageTime && !firstMessageShown)
                {
                    //TODO: SECOND MESSAGE DOESNT DISAPPEAR timer resets maybe
                    
                    if (!secondMessage.activeInHierarchy && firstMessage.activeInHierarchy)
                    {
                        timer = 0; 
                        firstMessage.SetActive(false);
                        messagePanel.SetActive(false);
                    }
                }
                else if (isBombPickedup && !secondMessageShown)
                {
                    timer = 0;
                    firstMessage.SetActive(false);
                    messagePanel.SetActive(true);
                    secondMessage.SetActive(true);
                    messagePanel.transform.GetChild(2).gameObject.SetActive(false);

                    secondMessageShown = true;
                }
                else if(isPowerupPickedup && !secondMessageShown)
                {
                    timer = 0;
                    firstMessage.SetActive(false);
                    messagePanel.SetActive(true);
                    powerUpMessage.SetActive(true);

                    secondMessageShown = true;
                }
            }
        }

        if(secondMessageShown && timer > secondMessageTime)
        {
            Debug.Log("Hide seconcd Message!");
            messagePanel.SetActive(false);
            secondMessage.SetActive(false);
            timer = 0;
        }
    }

    public void PlayerPickUpMessage()
    {
        isBombPickedup = true;
    }

    public void PlayerPowerUpMessage()
    {
        isPowerupPickedup = true;
    }
}
