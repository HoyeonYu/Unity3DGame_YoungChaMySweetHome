using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBuyBtn : MonoBehaviour
{
    InputField coinDealNumInputField;
    static public int coinDealNum;

    public void onClick()
    {
        coinDealNum = -1;
        coinDealNumInputField = GameObject.Find("CoinDealNum").GetComponent<InputField>();

        bool isCoinDealNumInt = int.TryParse(coinDealNumInputField.text, out coinDealNum);

        if (!isCoinDealNumInt)
        {
            coinDealNumInputField.text = "";
        }

        else
        {
            if (coinDealNum <= CoinDealInfoController.coinMaxAvailNum)
            {
                coinDealNumInputField.text = "";
                CoinPriceController.coinTotalPriceInt[CoinDealCanvasOpenBtn.coinIdx] 
                    += CoinDealCanvasOpenBtn.coinPrice * coinDealNum;

                MyAssetsController.cash -= (CoinDealCanvasOpenBtn.coinPrice * coinDealNum);
                MyAssetsController.coin[CoinDealCanvasOpenBtn.coinIdx] += coinDealNum;

                GameObject director = GameObject.Find("GameDirector");
                director.GetComponent<GameDirector>().OnCoinDealCanvasCloseClick();
                InfoCanvasController.infoDealTxtdelta = 0;
            }
        }
    }
}
