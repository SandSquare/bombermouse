using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightController : MonoBehaviour
{
    [SerializeField]
    private GameObject spotLight;

    [SerializeField]
    private GameObject globalLight;

    private GameObject exit;
    private GameObject player;

    private bool lightMoved;
    private bool startingLights = false;
    private bool lightsHappened = false;

    private void Awake()
    {
        exit = GameObject.FindGameObjectWithTag("Exit");
        player = GameObject.FindGameObjectWithTag("Player");

        spotLight.transform.position = exit.transform.position;

        spotLight.SetActive(false);
        globalLight.GetComponent<Light2D>().intensity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (startingLights && !lightsHappened)
        {
            spotLight.SetActive(true);
            globalLight.GetComponent<Light2D>().intensity = 0.2f;

            if (!UIManager.Instance.windowOpen && !GameManager.instance.doingSetup && !lightMoved)
            {
                StartCoroutine(MoveTowardsPlayer());

                lightsHappened = true;
            }
        }
    }

    private IEnumerator MoveTowardsPlayer()
    {
        while (Vector3.Distance(spotLight.transform.position, player.transform.position) > 0.05f)
        {
            spotLight.transform.position = Vector2.MoveTowards(spotLight.transform.position, player.transform.position, 5f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(IncreaseGlobalLight());
    }

    private IEnumerator IncreaseGlobalLight()
    {
        while(globalLight.GetComponent<Light2D>().intensity <= 1)
        {
            globalLight.GetComponent<Light2D>().intensity += 0.025f;
            spotLight.GetComponent<Light2D>().intensity -= 0.025f;
            Debug.Log("global light increased");
            yield return new WaitForEndOfFrame();
        }

        spotLight.SetActive(false);
    }

    public void DoLights()
    {
        startingLights = true;
    }
}
