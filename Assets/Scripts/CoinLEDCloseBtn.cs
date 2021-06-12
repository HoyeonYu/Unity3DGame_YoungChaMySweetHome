using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLEDCloseBtn : MonoBehaviour
{
    GameObject CoinLED;

    void Start()
    {
        CoinLED = GameObject.Find("CoinLED");
    }

    public void OnClick()
    {
        CoinLED.SetActive(false);
    }
}
