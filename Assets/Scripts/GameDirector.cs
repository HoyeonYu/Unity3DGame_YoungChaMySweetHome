using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject MyAssetsCanvasFold, MyAssetsCanvasFull, 
        BankCanvas, RealEstateCanvas,CoinCanvas, CoinDealCanvas;

    void Start()
    {
        MyAssetsCanvasFold = GameObject.Find("MyAssetsCanvasFold");
        MyAssetsCanvasFold.SetActive(true);

        MyAssetsCanvasFull = GameObject.Find("MyAssetsCanvasFull");
        MyAssetsCanvasFull.SetActive(false);

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
        MyAssetsCanvasFold.SetActive(!(BankCanvas.active || RealEstateCanvas.active
            || CoinCanvas.active || CoinDealCanvas.active || MyAssetsCanvasFull.active));

        MyAssetsCanvasFull.SetActive(!(BankCanvas.active || RealEstateCanvas.active 
            || CoinCanvas.active || CoinDealCanvas.active || MyAssetsCanvasFold.active));
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

    public void OnCoinGetFullAssetsCanvasClick()
    {
        MyAssetsCanvasFold.SetActive(false);
        MyAssetsCanvasFull.SetActive(true);
    }

    public void OnCoinGetFoldAssetsCanvasClick()
    {
        MyAssetsCanvasFull.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
    }
}
