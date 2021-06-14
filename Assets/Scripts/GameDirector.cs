using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject MyAssetsCanvas, BankCanvas, RealEstateCanvas,
        CoinCanvas, CoinDealCanvas;

    void Start()
    {
        MyAssetsCanvas = GameObject.Find("MyAssetsCanvas");
        MyAssetsCanvas.SetActive(true);

        BankCanvas = GameObject.Find("BankCanvas");
        BankCanvas.SetActive(false);

        RealEstateCanvas = GameObject.Find("RealEstateCanvas");
        RealEstateCanvas.SetActive(false);

        CoinCanvas = GameObject.Find("CoinCanvas");
        CoinCanvas.SetActive(false);

        CoinDealCanvas = GameObject.Find("CoinDealCanvas");
        CoinDealCanvas.SetActive(false);
    }

    void Update()
    {
        MyAssetsCanvas.SetActive(!(BankCanvas.active || RealEstateCanvas.active || CoinCanvas.active
            || CoinDealCanvas.active));
    }

    public void OnBankCanvasCloseClick()
    {
        BankCanvas.SetActive(false);
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

    public void OnCoinCanvasOpenClick()
    {
        CoinCanvas.SetActive(true);
        BankCanvas.SetActive(false);
    }

    public void OnCoinCanvasCloseClick()
    {
        CoinCanvas.SetActive(false);
    }

    public void OnCoinDealCanvasOpenClick()
    {
        CoinCanvas.SetActive(false);
        CoinDealCanvas.SetActive(true);
    }

    public void OnCoinDealCanvasCloseClick()
    {
        CoinDealCanvas.SetActive(false);
    }
}
