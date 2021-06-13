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
        BankCanvas.SetActive(false);
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
