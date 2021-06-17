using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPriceController : MonoBehaviour
{
    static public int[] coinPriceInt, coinTotalPriceInt;
    float[] coinDiffRate;
    GameObject[] coinDealBtn, coinPriceText, coinChangeText;
    GameObject coinCurrentTimeText;

    float span = 2.0f;
    float delta = 0;

    void Start()
    {
        coinPriceInt = new int[9] { 8000, 400, 98000, 20, 900, 300, 800, 100000, 200 };
        coinTotalPriceInt = new int[9];
        coinDiffRate = new float[9];
        coinDealBtn = new GameObject[9];
        coinPriceText = new GameObject[9];
        coinChangeText = new GameObject[9];

        coinCurrentTimeText = GameObject.Find("CoinCurrentTimeText");

        for (int i = 0; i < 9; i++)
        {
            coinTotalPriceInt[i] = 0;
            coinDealBtn[i] = GameObject.Find("CoinBtn_" + i);

            coinPriceText[i] = GameObject.Find("CoinTxt_" + i);
            coinPriceText[i].GetComponent<Text>().text = "₩ " + coinPriceInt[i];

            coinChangeText[i] = GameObject.Find("CoinTxt_" + i + " (1)");
            coinChangeText[i].GetComponent<Text>().text = "";
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
        coinDiffRate[0] = Random.Range(-0.1f, 0.2f);
        coinDiffRate[1] = Random.Range(-0.3f, 0.5f);
        coinDiffRate[2] = Random.Range(-0.2f, 0.2f);
        coinDiffRate[3] = Random.Range(-0.6f, 1.2f);
        coinDiffRate[4] = Random.Range(-0.05f, 0.1f);
        coinDiffRate[5] = Random.Range(-0.6f, 0.8f);
        coinDiffRate[6] = Random.Range(-0.5f, 0.6f);
        coinDiffRate[7] = Random.Range(-0.2f, 0.2f);
        coinDiffRate[8] = Random.Range(-0.8f, 1.8f);


        for (int i = 0; i < 9; i++)
        {
            int changePrice = (int)(coinPriceInt[i] * coinDiffRate[i]);
            coinPriceInt[i] += changePrice;
            coinPriceText[i].GetComponent<Text>().text = "₩ " + coinPriceInt[i].ToString();

            string upDownStart = (coinDiffRate[i] > 0 ? "<color=#B40B01> +" : "<color=#0012D4> ");
            string upDownMid = (coinDiffRate[i] > 0 ? " (+" : " (");
            string upDownEnd = (coinDiffRate[i] > 0 ? "%) ▲</color>" : "%) ▼</color>");

            coinChangeText[i].GetComponent<Text>().text = upDownStart + changePrice + upDownMid
                + (coinDiffRate[i] * 100).ToString("F2") + upDownEnd;
        }
    }
}
