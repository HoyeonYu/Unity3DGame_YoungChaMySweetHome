using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    static public GameObject MyAssetsCanvasFold, MyAssetsCanvasFull;
    public GameObject MyHealthCanvas, BankCanvas, CoinCanvas, CoinDealCanvas,
        SuperMarketCanvas, HospitalCanvas, GameOverCanvas, GameSuccessCanvas;
    GameObject[] CarGenerator;

    static public bool isPlayerFixed;
    float gameLevelDelta;
    bool isGameSuccess;

    void Start()
    {
        MyAssetsCanvasFold = GameObject.Find("MyAssetsCanvasFold");
        MyAssetsCanvasFold.SetActive(true);

        MyAssetsCanvasFull = GameObject.Find("MyAssetsCanvasFull");
        MyAssetsCanvasFull.SetActive(false);

        MyHealthCanvas = GameObject.Find("MyHealthCanvas");
        MyHealthCanvas.SetActive(true);

        BankCanvas = GameObject.Find("BankCanvas");
        BankCanvas.SetActive(false);

        CoinCanvas = GameObject.Find("CoinCanvas");
        CoinCanvas.SetActive(false);

        CoinDealCanvas = GameObject.Find("CoinDealCanvas");
        CoinDealCanvas.SetActive(false);

        SuperMarketCanvas = GameObject.Find("SuperMarketCanvas");
        SuperMarketCanvas.SetActive(false);

        HospitalCanvas = GameObject.Find("HospitalCanvas");
        HospitalCanvas.SetActive(false);

        GameOverCanvas = GameObject.Find("GameOverCanvas");
        GameOverCanvas.SetActive(false);

        GameSuccessCanvas = GameObject.Find("GameSuccessCanvas");
        GameSuccessCanvas.SetActive(false);

        CarGenerator = new GameObject[16];
        for (int i = 0; i < 16; i++)
        {
            CarGenerator[i] = GameObject.Find("CarGenerator_" + i);
        }

        isPlayerFixed = false;
        gameLevelDelta = 0;
        isGameSuccess = false;
    }

    void Update()
    {
        MyAssetsCanvasFold.SetActive(!(BankCanvas.active || CoinCanvas.active || CoinDealCanvas.active 
            || MyAssetsCanvasFull.active || SuperMarketCanvas.active || HospitalCanvas.active));

        MyAssetsCanvasFull.SetActive(!(BankCanvas.active || CoinCanvas.active || CoinDealCanvas.active
            || MyAssetsCanvasFold.active || SuperMarketCanvas.active || HospitalCanvas.active));

        MyHealthCanvas.SetActive(!(BankCanvas.active || CoinCanvas.active || CoinDealCanvas.active
            || SuperMarketCanvas.active || HospitalCanvas.active));

        gameLevelDelta += Time.deltaTime;
        gameLevelDelta %= 60;

        if ((int)gameLevelDelta / 15 == 0)
        {
            for (int i = 0; i < 16; i++)
            {
                CarGenerator[i].GetComponent<CarPrefabGenerator>().carGenerateSpan = 5;
            }
        }

        else if ((int)gameLevelDelta / 15 == 1)
        {
            for (int i = 0; i < 16; i++)
            {
                CarGenerator[i].GetComponent<CarPrefabGenerator>().carGenerateSpan = 3;
            }
        }

        else if ((int)gameLevelDelta / 15 == 2)
        {
            for (int i = 0; i < 16; i++)
            {
                CarGenerator[i].GetComponent<CarPrefabGenerator>().carGenerateSpan = 4;
            }
        }

        else
        {
            for (int i = 0; i < 16; i++)
            {
                CarGenerator[i].GetComponent<CarPrefabGenerator>().carGenerateSpan = 6;
            }
        }

        if (MyHealthController.isGameEnd)
        {
            MyAssetsCanvasFold.SetActive(false);
            MyAssetsCanvasFull.SetActive(false);
            MyHealthCanvas.SetActive(false);
            GameOverCanvas.SetActive(true);
            isPlayerFixed = true;
        }

        if (isGameSuccess)
        {
            MyAssetsCanvasFold.SetActive(false);
            MyAssetsCanvasFull.SetActive(false);
            MyHealthCanvas.SetActive(false);
            GameSuccessCanvas.SetActive(true);
            isPlayerFixed = true;
        }
    }

    public void OnBankCanvasCloseClick()
    {
        BankCanvas.SetActive(false);
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

    public void OnBuyHouseClick()
    {
        isGameSuccess = true;
        BankCanvas.SetActive(false);
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

    public void OnHospitalCanvasCloseClick()
    {
        HospitalCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnHospitalCanvasCureClick()
    {
        HospitalCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
    }

    public void OnGameOverAgainClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnGameOverExitClick()
    {
        Application.Quit();
    }
}
