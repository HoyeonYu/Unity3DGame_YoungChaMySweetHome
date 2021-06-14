using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDealInfoController : MonoBehaviour
{
    GameObject coinDealInfoText;
    static public int coinMaxAvailNum;

    void LateUpdate()
    {
        coinDealInfoText = GameObject.Find("CoinDealInfoText");

        if (CoinDealCanvasOpenBtn.coinPrice != 0)
        {
            coinMaxAvailNum = MyAssetsController.cash / CoinDealCanvasOpenBtn.coinPrice;

            coinDealInfoText.GetComponent<Text>().text = "코인 이름 : " +
                CoinDealCanvasOpenBtn.coinName + "\n";

            coinDealInfoText.GetComponent<Text>().text += "거래 가격 : " +
                CoinDealCanvasOpenBtn.coinPrice + "원\n\n";

            coinDealInfoText.GetComponent<Text>().text += 
               "최대 매수 가능 수량: " + coinMaxAvailNum + "개\n" +
               "최대 매도 가능 수량: " + MyAssetsController.coin[CoinDealCanvasOpenBtn.coinIdx] + "개";

            coinDealInfoText.GetComponent<Text>().text += "\n\n매수 또는 매도 수량을 입력하세요";

        }
    }
}
