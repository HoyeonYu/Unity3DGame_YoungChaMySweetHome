using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHealthController : MonoBehaviour
{
    static public int hungryValue, tireValue, hurtValue;
    static public bool isGameEnd;
    GameObject MyHealthTxt;
    float healthHungrySpan = 3.0f;
    float healthHungryDelta = 0;
    float healthHurtSpan = 3.0f;
    float healthHurtDelta = 0;

    void Start()
    {
        hungryValue = 50;
        tireValue = 50;
        hurtValue = 0;
        MyHealthTxt = GameObject.Find("MyHealthTxt");
        isGameEnd = false;
    }

    void Update()
    {
        MyHealthTxt.GetComponent<Text>().text = "건강상태\n\n";

        UpdateHungryData();
        UpdateHappyData();
        UpdateHurtData();

        if (hungryValue <= 0 || tireValue >= 100 || hurtValue >= 100)
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

        if (tireValue > 80)
        {
            colorText = "<color=#ff0000>";
        }

        else if (tireValue > 50)
        {
            colorText = "<color=#ffff00>";
        }

        MyHealthTxt.GetComponent<Text>().text += "  - 피로도\t\t "
            + colorText + tireValue + " / 100" + colorEndText + "\n";
    }

    void UpdateHurtData()
    {
        string colorText = "<color=#00ff00>";
        string colorEndText = "</color>";

        healthHungryDelta += Time.deltaTime;

        if (healthHungryDelta > healthHungrySpan && hurtValue > 0)
        {
            hurtValue += 2;
            healthHungryDelta = 0;
        }

        if (hurtValue > 80)
        {
            colorText = "<color=#ff0000>";
        }

        else if (hurtValue > 50)
        {
            colorText = "<color=#ffff00>";
        }

        MyHealthTxt.GetComponent<Text>().text += "  - 부상도\t\t "
            + colorText + hurtValue + " / 100" + colorEndText;
    }
}
