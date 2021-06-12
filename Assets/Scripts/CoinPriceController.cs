using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPriceController : MonoBehaviour
{
    [SerializeField]
    private int HTCPrice, ATHPrice, HNBPrice, XBPPrice,
        IDAPrice, GSMPrice, COTPrice, HVCPrice, CATPrice;

    GameObject HTCText, ATHText, HNBText, XBPText,
        IDAText, GSMText, COTText, HVCText, CATText;

    GameObject currentTimeText;

    float span = 2.0f;
    float delta = 0;

    void Start()
    {
        HTCText = GameObject.Find("HTCText");
        ATHText = GameObject.Find("ATHText");
        HNBText = GameObject.Find("HNBText");
        XBPText = GameObject.Find("XBPText");
        IDAText = GameObject.Find("IDAText");
        GSMText = GameObject.Find("GSMText");
        COTText = GameObject.Find("COTText");
        HVCText = GameObject.Find("HVCText");
        CATText = GameObject.Find("CATText");

        currentTimeText = GameObject.Find("CurrentTimeText");
    }

    void Update()
    {
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;
            ChangePrice();
        }

        currentTimeText.GetComponent<Text>().text = "현재시각: " + 
            System.DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));

        if ((int.Parse(System.DateTime.Now.ToString("ss")) / 10) % 2 == 0)
        {
            currentTimeText.GetComponent<Text>().text += ", 거래 가능 시간";
        }

        else
        {
            currentTimeText.GetComponent<Text>().text += ", 거래 불가 시간";
        }
    }

    void ChangePrice()
    {
        float rate = Random.RandomRange(-0.1f, 0.1f);
        HTCPrice += (int)(HTCPrice * rate);
        HTCText.GetComponent<Text>().text = "₩ " + HTCPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";

        rate = Random.RandomRange(-0.3f, 0.3f);
        ATHPrice += (int)(ATHPrice * rate);
        ATHText.GetComponent<Text>().text = "₩ " + ATHPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";

        rate = Random.RandomRange(-0.2f, 0.2f);
        HNBPrice += (int)(HNBPrice * rate);
        HNBText.GetComponent<Text>().text = "₩ " + HNBPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";

        rate = Random.RandomRange(-0.2f, 0.2f);
        XBPPrice += (int)(XBPPrice * rate);
        XBPText.GetComponent<Text>().text = "₩ " + XBPPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";

        rate = Random.RandomRange(-0.05f, 0.1f);
        IDAPrice += (int)(IDAPrice * rate);
        IDAText.GetComponent<Text>().text = "₩ " + IDAPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";

        rate = Random.RandomRange(-0.4f, 0.3f);
        GSMPrice += (int)(GSMPrice * rate);
        GSMText.GetComponent<Text>().text = "₩ " + GSMPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";

        rate = Random.RandomRange(-0.5f, 0.2f);
        COTPrice += (int)(COTPrice * rate);
        COTText.GetComponent<Text>().text = "₩ " + COTPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";

        rate = Random.RandomRange(-0.2f, 0.3f);
        HVCPrice += (int)(HVCPrice * rate);
        HVCText.GetComponent<Text>().text = "₩ " + HVCPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";

        rate = Random.RandomRange(-0.3f, 0.4f);
        CATPrice += (int)(CATPrice * rate);
        CATText.GetComponent<Text>().text = "₩ " + CATPrice.ToString() + " (" + (rate * 100).ToString("F2") + "%)";
    }
}
