using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAssetsController : MonoBehaviour
{
    static public int cash, house, car;
    public int cashPublic;
    static public int[] coin;
    GameObject myAssetsFoldText, myAssetsFullText, myAssetsCoinNumText;
    string[] coinNameArr;

    void Start()
    {
        cash = cashPublic;
        house = 1;
        car = 0;

        coin = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        myAssetsFoldText = GameObject.Find("MyAssetsFoldTxt");
        myAssetsFullText = GameObject.Find("MyAssetsFullTxt");
        myAssetsCoinNumText = GameObject.Find("MyAssetsCoinNumTxt");

        coinNameArr = new string[9] {
            "호트코인 (HTC)", "아더리움 (ATH)", "하이낸스 (HNB)",
            "바플 (XBP)", "아이다 코인 (IDA)", "건사마 (GSM)",
            "콜카닷 (COT)", "헤비코인 (HVC)", "캣지코인 (CAT)"
        };
    }

    public void Update()
    {
        string commonTxt = "<b>자산</b>\n";
        commonTxt += "  - 내 집 마련 (2억):\t";

        string houseAvailable = "<color=#ff0000>불가능</color>\n";

        if (MyAssetsController.cash >= 200000000)
        {
            houseAvailable = "<color=#22FFAA>가능</color>\n"; 
        }

        commonTxt += houseAvailable;
        commonTxt += "  - 현금 / 계좌:\t" + cash + "원\n";
        commonTxt += "  - 코인\n";

        myAssetsFoldText.GetComponent<Text>().text = commonTxt;
        myAssetsFullText.GetComponent<Text>().text = commonTxt;
        myAssetsCoinNumText.GetComponent<Text>().text = "";

        for (int i = 0; i < 9; i++)
        {
            myAssetsFullText.GetComponent<Text>().text += "    - " + coinNameArr[i] + ":\n";
            myAssetsCoinNumText.GetComponent<Text>().text += coin[i] + "개\n";
        }
    }
}