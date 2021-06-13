using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject MyAssetsCanvas, BankCanvas, CoinCanvas, RealEstateCanvas;

    void Start()
    {
        MyAssetsCanvas = GameObject.Find("MyAssetsCanvas");
        MyAssetsCanvas.SetActive(true);

        BankCanvas = GameObject.Find("BankCanvas");
        BankCanvas.SetActive(false);

        CoinCanvas = GameObject.Find("CoinCanvas");
        CoinCanvas.SetActive(false);

        RealEstateCanvas = GameObject.Find("RealEstateCanvas");
        RealEstateCanvas.SetActive(false);
    }

    void Update()
    {
        MyAssetsCanvas.SetActive(!(BankCanvas.active || RealEstateCanvas.active || CoinCanvas.active));
    }

    public void OnBankCanvasCloseClick()
    {
        Debug.Log("OnBankCanvasCloseClick");
        BankCanvas.SetActive(false);
        Debug.Log("SetActive");
    }

    public void OnCoinCanvasOpenClick()
    {
        CoinCanvas.SetActive(true);
        BankCanvas.SetActive(false);
    }

    public void OnCoinCanvasCloseClick()
    {
        CoinCanvas.SetActive(false);
    }

    public void OnRealEstateCanvasOpenClick()
    {
        RealEstateCanvas.SetActive(true);
        BankCanvas.SetActive(false);
    }

    public void OnRealEstateCanvasCloseClick()
    {
        RealEstateCanvas.SetActive(false);
    }
}
