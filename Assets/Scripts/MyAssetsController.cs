using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAssetsController : MonoBehaviour
{
    static public int cash, house, car;
    static public int[] coin;
    GameObject myAssetsFoldText, myAssetsFullText;
    string[] coinNameArr;

    void Start()
    {
        cash = 100000;
        house = 1;
        car = 0;

        coin = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        myAssetsFoldText = GameObject.Find("MyAssetsFoldTxt");
        myAssetsFullText = GameObject.Find("MyAssetsFullTxt");

        coinNameArr = new string[9] {
            "호트코인 (HTC)", "아더리움 (ATH)", "하이낸스 (HNB)",
            "바플 (XBP)", "아이다 코인 (IDA)", "건사마 (GSM)",
            "콜카닷 (COT)", "헤비코인 (HVC)", "캣지코인 (CAT)"
        };
    }

    public void Update()
    {
        string showText = "자산\n\n";
        showText += "  - 현금:\t\t" + cash + "원\n";
        showText += "  - 집:\t\t\t" + house + "채\n";
        showText += "  - 자동차:\t" + car + "대\n";
        showText += "  - 코인: ";

        myAssetsFoldText.GetComponent<Text>().text = showText;

        string tab = "";

        for (int i = 0; i < 9; i++)
        {
            if (i == 3)
            {
                tab = "\t\t";
            }

            else if (i == 5 || i == 6)
            {
                tab = "\t";
            }

            else
            {
                tab = "";
            }

            showText += "\n    - " + coinNameArr[i] + ":\t" + tab + "  " + coin[i] + "개";
        }

        myAssetsFullText.GetComponent<Text>().text = showText;
    }
}
