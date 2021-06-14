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

            coinDealInfoText.GetComponent<Text>().text += "고객님의 현금 자산은 현재 " +
               MyAssetsController.cash + "원으로," +
               "\n최대 " + coinMaxAvailNum + "개까지 매수 가능하며," +
               "\n최대 " + MyAssetsController.coin[CoinDealCanvasOpenBtn.coinIdx] + "개까지 매도 가능합니다.";

        }
    }
}
