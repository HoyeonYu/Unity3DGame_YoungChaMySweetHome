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

            coinDealInfoText.GetComponent<Text>().text = "���� �̸� : " +
                CoinDealCanvasOpenBtn.coinName + "\n";

            coinDealInfoText.GetComponent<Text>().text += "�ŷ� ���� : " +
                CoinDealCanvasOpenBtn.coinPrice + "��\n\n";

            coinDealInfoText.GetComponent<Text>().text += "������ ���� �ڻ��� ���� " +
               MyAssetsController.cash + "������," +
               "\n�ִ� " + coinMaxAvailNum + "������ �ż� �����ϸ�," +
               "\n�ִ� " + MyAssetsController.coin[CoinDealCanvasOpenBtn.coinIdx] + "������ �ŵ� �����մϴ�.";

        }
    }
}
