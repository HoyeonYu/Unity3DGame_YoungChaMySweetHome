using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPriceController : MonoBehaviour
{
    static public int[] coinPriceInt;
    private float[] coinDiffRate;
    GameObject[] coinDealBtn, coinPriceText;
    GameObject coinCurrentTimeText;

    float span = 2.0f;
    float delta = 0;

    void Start()
    {
        coinPriceInt = new int[9] { 8000, 400, 98000, 20, 900, 300, 800, 100000, 200 };
        coinDiffRate = new float[9];
        coinDealBtn = new GameObject[9];
        coinPriceText = new GameObject[9];

        coinCurrentTimeText = GameObject.Find("CoinCurrentTimeText");

        for (int i = 0; i < 9; i++)
        {
            coinDealBtn[i] = GameObject.Find("CoinBtn_" + i);

            coinPriceText[i] = GameObject.Find("CoinTxt_" + i);
            coinPriceText[i].GetComponent<Text>().text = "₩ " + coinPriceInt[i];
        }
    }

    void Update()
    {
        coinCurrentTimeText.GetComponent<Text>().text = "현재시각: " +
            System.DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));

        string isDealAvailable = ", 거래 가능 시간";

        for (int i = 0; i < 9; i++)
        {
            coinDealBtn[i].GetComponent<Button>().interactable = true;
        }

        if ((int.Parse(System.DateTime.Now.ToString("ss")) / 10) % 2 != 0)
        {
            isDealAvailable = ", 거래 불가 시간";

            for (int i = 0; i < 9; i++)
            {
                coinDealBtn[i].GetComponent<Button>().interactable = false;
            }
        }

        else
        {
            delta += Time.deltaTime;

            if (delta > span)
            {
                delta = 0;
                ChangePrice();
            }
        }

        coinCurrentTimeText.GetComponent<Text>().text += isDealAvailable;
    }

    void ChangePrice()
    {
        coinDiffRate[0] = Random.Range(-0.1f, 0.1f);
        coinDiffRate[1] = Random.Range(-0.3f, 0.3f);
        coinDiffRate[2] = Random.Range(-0.2f, 0.2f);
        coinDiffRate[3] = Random.Range(-0.2f, 0.2f);
        coinDiffRate[4] = Random.Range(-0.05f, 0.1f);
        coinDiffRate[5] = Random.Range(-0.4f, 0.3f);
        coinDiffRate[6] = Random.Range(-0.3f, 0.2f);
        coinDiffRate[7] = Random.Range(-0.2f, 0.3f);
        coinDiffRate[8] = Random.Range(-0.3f, 0.4f);


        for (int i = 0; i < 9; i++)
        {
            string textColor = (coinDiffRate[i] > 0 ? "<color=#ff0505>" : "<color=#0000ff>");

            coinPriceInt[i] += (int)(coinPriceInt[i] * coinDiffRate[i]);
            coinPriceText[i].GetComponent<Text>().text = "₩ " + coinPriceInt[i].ToString() 
                + textColor + " (" + (coinDiffRate[i] * 100).ToString("F2") + "%)" + "</color>";
        }
    }
}
