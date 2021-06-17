using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDealInfoController : MonoBehaviour
{
    GameObject coinDealInfoText;
    static public int coinMaxAvailNum;
    static public float avgCoinPrice;

    void LateUpdate()
    {
        coinDealInfoText = GameObject.Find("CoinDealInfoText");

        if (CoinDealCanvasOpenBtn.coinPrice != 0)
        {
            coinMaxAvailNum = MyAssetsController.cash / CoinDealCanvasOpenBtn.coinPrice;

            coinDealInfoText.GetComponent<Text>().text = "���� �̸� : " +
                CoinDealCanvasOpenBtn.coinName + "\n";

            coinDealInfoText.GetComponent<Text>().text += "�ŷ� ���� : " +
                CoinDealCanvasOpenBtn.coinPrice + "��\n\n";

            coinDealInfoText.GetComponent<Text>().text += 
               "�ִ� �ż� ���� ����: " + coinMaxAvailNum + "��\n" +
               "�ִ� �ŵ� ���� ����: " + MyAssetsController.coin[CoinDealCanvasOpenBtn.coinIdx] + "��\n";

            if (MyAssetsController.coin[CoinDealCanvasOpenBtn.coinIdx] > 0)
            {
                avgCoinPrice = CoinPriceController.coinTotalPriceInt[CoinDealCanvasOpenBtn.coinIdx]
                    / MyAssetsController.coin[CoinDealCanvasOpenBtn.coinIdx];

                coinDealInfoText.GetComponent<Text>().text += "(���� ��� �ܰ�: " + avgCoinPrice.ToString("F2") + "��)\n";
            }

            coinDealInfoText.GetComponent<Text>().text += "�ż� �Ǵ� �ŵ� ������ �Է��ϼ���";

        }
    }
}
