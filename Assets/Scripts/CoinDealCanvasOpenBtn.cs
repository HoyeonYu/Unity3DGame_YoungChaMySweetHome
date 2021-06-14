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
            "ȣƮ���� (HTC)", "�ƴ����� (ATH)", "���̳��� (HNB)",
            "���� (XBP)", "���̴� ���� (IDA)", "�ǻ縶 (GSM)",
            "��ī�� (COT)", "������� (HVC)", "Ĺ������ (CAT)"
        };

        coinIdx = int.Parse(gameObject.name.Split(new char[] { '_' })[1]);

        coinName = coinNameArr[coinIdx];
        coinPrice = CoinPriceController.coinPriceInt[coinIdx];
    }
}
