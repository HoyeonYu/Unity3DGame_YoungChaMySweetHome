using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    static public GameObject MyAssetsCanvasFold, MyAssetsCanvasFull;
    public GameObject BankCanvas, RealEstateCanvas,CoinCanvas, CoinDealCanvas,
        SuperMarketCanvas, CarRepairShopCanvas, CarShopCanvas;

    static public bool isPlayerFixed;

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

        SuperMarketCanvas = GameObject.Find("SuperMarketCanvas");
        SuperMarketCanvas.SetActive(false);

        CarRepairShopCanvas = GameObject.Find("CarRepairShopCanvas");
        CarRepairShopCanvas.SetActive(false);

        CarShopCanvas = GameObject.Find("CarShopCanvas");
        CarShopCanvas.SetActive(false);

        isPlayerFixed = false;
    }

    void Update()
    {
        MyAssetsCanvasFold.SetActive(!(BankCanvas.active || RealEstateCanvas.active
            || CoinCanvas.active || CoinDealCanvas.active || MyAssetsCanvasFull.active
            || SuperMarketCanvas.active || CarRepairShopCanvas.active || CarShopCanvas.active));

        MyAssetsCanvasFull.SetActive(!(BankCanvas.active || RealEstateCanvas.active 
            || CoinCanvas.active || CoinDealCanvas.active || MyAssetsCanvasFold.active
            || SuperMarketCanvas.active || CarRepairShopCanvas.active || CarShopCanvas.active));
    }

    public void OnBankCanvasCloseClick()
    {
        BankCanvas.SetActive(false);
        isPlayerFixed = false;
    }

    public void OnRealEstateCanvasOpenClick()
    {
        RealEstateCanvas.SetActive(true);
        BankCanvas.SetActive(false);
        isPlayerFixed = true;
    }

    public void OnRealEstateCanvasCloseClick()
    {
        RealEstateCanvas.SetActive(false);
        isPlayerFixed = false;
    }

    public void OnCoinCanvasOpenClick()
    {
        CoinCanvas.SetActive(true);
        BankCanvas.SetActive(false);
        isPlayerFixed = true;
    }

    public void OnCoinCanvasCloseClick()
    {
        CoinCanvas.SetActive(false);
        isPlayerFixed = false;
    }

    public void OnCoinDealCanvasOpenClick()
    {
        CoinCanvas.SetActive(false);
        CoinDealCanvas.SetActive(true);
        isPlayerFixed = true;
    }

    public void OnCoinDealCanvasCloseClick()
    {
        CoinDealCanvas.SetActive(false);
        isPlayerFixed = false;
    }

    public void OnCoinGetFullAssetsCanvasClick()
    {
        MyAssetsCanvasFold.SetActive(false);
        MyAssetsCanvasFull.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnCoinGetFoldAssetsCanvasClick()
    {
        MyAssetsCanvasFull.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnSuperMarketCanvasCloseClick()
    {
        SuperMarketCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnSuperMarketCanvasBuyClick()
    {
        SuperMarketCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
    }
}
