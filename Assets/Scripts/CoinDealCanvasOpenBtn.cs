using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDealCanvasOpenBtn : MonoBehaviour
{
    static public string coinName;
    static public int coinIdx;
    static public int coinPrice;

    public void OnClick()
    {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().OnCoinDealCanvasOpenClick();

        string[] coinNameArr = {
            "호트코인 (HTC)", "아더리움 (ATH)", "하이낸스 (HNB)",
            "바플 (XBP)", "아이다 코인 (IDA)", "건사마 (GSM)",
            "콜카닷 (COT)", "헤비코인 (HVC)", "캣지코인 (CAT)"
        };

        coinIdx = int.Parse(gameObject.name.Split(new char[] { '_' })[1]);

        coinName = coinNameArr[coinIdx];
        coinPrice = CoinPriceController.coinPriceInt[coinIdx];
    }
}
