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
    [SerializeField]
    private bool showFirstMessageOnly = false;

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
                if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") && !firstMessageShown)
                {
                    if (firstMessage.activeInHierarchy)
                    {
                        if(secondMessage == null)
                        {
                            firstMessage.SetActive(false);
                            messagePanel.SetActive(false);
                            timer = 0;
                        }
                        else
                        {
                            if (!secondMessage.activeInHierarchy)
                            {
                                firstMessage.SetActive(false);
                                messagePanel.SetActive(false);
                                timer = 0;
                                Debug.Log("timer reset 2");
                            }
                        }
                    }                }
                if (!showFirstMessageOnly)
                {
                    if (isBombPickedup && !secondMessageShown && secondMessage != null)
                    {
                        timer = 0;
                        firstMessage.SetActive(false);
                        messagePanel.SetActive(true);
                        secondMessage.SetActive(true);
                        messagePanel.transform.GetChild(2).gameObject.SetActive(false);

                        secondMessageShown = true;
                    }

                    else if (isPowerupPickedup && !secondMessageShown)
                    {
                        timer = 0;
                        firstMessage.SetActive(false);
                        messagePanel.SetActive(true);
                        powerUpMessage.SetActive(true);

                        secondMessageShown = true;
                    }
                }
            }
        }

        if (secondMessageShown && timer > secondMessageTime && secondMessage.activeInHierarchy)
        {
            messagePanel.SetActive(false);
            secondMessage.SetActive(false);
            
            timer = 0;
        }
        if(powerUpMessage != null)
        {
            if(powerUpMessage.activeInHierarchy && timer > powerUpMessageTime)
            {
                messagePanel.SetActive(false);
                powerUpMessage.SetActive(false);
            }
        }
    }

    public void PlayerPickUpMessage()
    {
        if (firstMessage != null)
        {
            isBombPickedup = true;
        }
    }

    public void PlayerPowerUpMessage()
    {
        if (powerUpMessage != null)
        {
            isPowerupPickedup = true;
        }
    }
}
