using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHealthController : MonoBehaviour
{
    static public int hungryValue, happyValue;
    static public bool isGameEnd;
    GameObject MyHealthTxt;
    float healthHungrySpan = 3.0f;
    float healthHungryDelta = 0;

    void Start()
    {
        hungryValue = 1;
        happyValue = 50;
        MyHealthTxt = GameObject.Find("MyHealthTxt");
        isGameEnd = false;
    }

    void Update()
    {
        MyHealthTxt.GetComponent<Text>().text = "건강상태\n\n";

        UpdateHungryData();
        UpdateHappyData();

        if (hungryValue <= 0 || happyValue >= 100)
        {
            isGameEnd = true;
        }
    }

    void UpdateHungryData()
    {
        healthHungryDelta += Time.deltaTime;

        if (healthHungryDelta > healthHungrySpan)
        {
            hungryValue--;
            healthHungryDelta = 0;
        }

        string colorText = "<color=#00ff00>";
        string colorEndText = "</color>";

        if (hungryValue < 20)
        {
            colorText = "<color=#ff0000>";
        }

        else if (hungryValue < 50)
        {
            colorText = "<color=#ffff00>";
        }

        MyHealthTxt.GetComponent<Text>().text += "  - 포만감\t\t "
            + colorText + hungryValue + " / 100" + colorEndText + "\n";
    }

    void UpdateHappyData()
    {
        string colorText = "<color=#00ff00>";
        string colorEndText = "</color>";

        if (happyValue < 20)
        {
            colorText = "<color=#ff0000>";
        }

        else if (happyValue < 50)
        {
            colorText = "<color=#ffff00>";
        }

        MyHealthTxt.GetComponent<Text>().text += "  - 피로도\t\t "
            + colorText + (100 - happyValue) + " / 100" + colorEndText;
    }
}
