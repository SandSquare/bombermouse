using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public Sprite[] images; 
    void Start()
    {
        GetComponent<Image>().sprite = images[(int)Random.Range(0,images.Length)];
    }
}
