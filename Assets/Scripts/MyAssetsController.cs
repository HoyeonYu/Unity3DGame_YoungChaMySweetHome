using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAssetsController : MonoBehaviour
{
    static public int cash, house;
    static public int[] coin;
    GameObject myAssetsText;
    string[] coinNameArr;

    void Start()
    {
        cash = 100000;
        house = 1;
        coin = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        myAssetsText = GameObject.Find("MyAssetsText");

        coinNameArr = new string[9] {
            "호트코인 (HTC)", "아더리움 (ATH)", "하이낸스 (HNB)",
            "바플 (XBP)", "아이다 코인 (IDA)", "건사마 (GSM)",
            "콜카닷 (COT)", "헤비코인 (HVC)", "캣지코인 (CAT)"
        };
    }

    public void Update()
    {
        myAssetsText.GetComponent<Text>().text = "내 자산\n\n";
        myAssetsText.GetComponent<Text>().text += "   현금: " + cash + "원\n";
        myAssetsText.GetComponent<Text>().text += "   집: " + house + "채\n";

        myAssetsText.GetComponent<Text>().text += "   코인: ";

        for (int i = 0; i < 9; i++)
        {
            myAssetsText.GetComponent<Text>().text += "\n    - " + coinNameArr[i] + ": "
                + coin[i] + "개";
        }
    }
}
