using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    static public GameObject MyAssetsCanvasFold, MyAssetsCanvasFull;
    public GameObject MyHealthCanvas, BankCanvas, CoinCanvas, CoinDealCanvas,
        SuperMarketCanvas, HospitalCanvas, GameStartCanvas, GameOverCanvas, GameSuccessCanvas;
    GameObject[] CarGenerator;

    static public bool isPlayerFixed;
    bool isGameSuccess, isGameDone;
    float gameLevelDelta;

    void Start()
    {
        MyAssetsCanvasFold = GameObject.Find("MyAssetsCanvasFold");
        MyAssetsCanvasFold.SetActive(false);

        MyAssetsCanvasFull = GameObject.Find("MyAssetsCanvasFull");
        MyAssetsCanvasFull.SetActive(false);

        MyHealthCanvas = GameObject.Find("MyHealthCanvas");
        MyHealthCanvas.SetActive(false);

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

        GameStartCanvas = GameObject.Find("GameStartCanvas");
        GameStartCanvas.SetActive(true);

        GameOverCanvas = GameObject.Find("GameOverCanvas");
        GameOverCanvas.SetActive(false);

        GameSuccessCanvas = GameObject.Find("GameSuccessCanvas");
        GameSuccessCanvas.SetActive(false);

        CarGenerator = new GameObject[16];
        for (int i = 0; i < 16; i++)
        {
            CarGenerator[i] = GameObject.Find("CarGenerator_" + i);
        }

        isPlayerFixed = true;
        isGameSuccess = false;
        isGameDone = false;
        gameLevelDelta = 0;

        GameObject.Find("AudioMain").GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        MyAssetsCanvasFold.SetActive(!(BankCanvas.active || CoinCanvas.active || CoinDealCanvas.active 
            || MyAssetsCanvasFull.active || SuperMarketCanvas.active || HospitalCanvas.active
            || GameStartCanvas.active || GameOverCanvas.active || GameSuccessCanvas.active));

        MyAssetsCanvasFull.SetActive(!(BankCanvas.active || CoinCanvas.active || CoinDealCanvas.active
            || MyAssetsCanvasFold.active || SuperMarketCanvas.active || HospitalCanvas.active
            || GameStartCanvas.active || GameOverCanvas.active || GameSuccessCanvas.active));

        MyHealthCanvas.SetActive(!(BankCanvas.active || CoinCanvas.active || CoinDealCanvas.active
            || SuperMarketCanvas.active || HospitalCanvas.active
            || GameStartCanvas.active || GameOverCanvas.active || GameSuccessCanvas.active));

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

            if (!isGameDone)
            {
                GameObject.Find("AudioMain").GetComponent<AudioSource>().Pause();
                GameObject.Find("AudioFail").GetComponent<AudioSource>().Play();
                isGameDone = true;
            }
        }

        if (isGameSuccess)
        {
            MyAssetsCanvasFold.SetActive(false);
            MyAssetsCanvasFull.SetActive(false);
            MyHealthCanvas.SetActive(false);
            GameSuccessCanvas.SetActive(true);
            isPlayerFixed = true;

            if (!isGameDone)
            {
                GameObject.Find("AudioMain").GetComponent<AudioSource>().Pause();
                GameObject.Find("AudioSuccess").GetComponent<AudioSource>().Play();
                isGameDone = true;
            }
        }
    }

    public void OnBankCanvasCloseClick()
    {
        BankCanvas.SetActive(false);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnCoinCanvasOpenClick()
    {
        CoinCanvas.SetActive(true);
        BankCanvas.SetActive(false);
        isPlayerFixed = true;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnCoinCanvasCloseClick()
    {
        CoinCanvas.SetActive(false);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnCoinDealCanvasOpenClick()
    {
        CoinCanvas.SetActive(false);
        CoinDealCanvas.SetActive(true);
        isPlayerFixed = true;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnCoinDealCanvasCloseClick()
    {
        CoinDealCanvas.SetActive(false);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnCoinGetFullAssetsCanvasClick()
    {
        MyAssetsCanvasFold.SetActive(false);
        MyAssetsCanvasFull.SetActive(true);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnCoinGetFoldAssetsCanvasClick()
    {
        MyAssetsCanvasFull.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnBuyHouseClick()
    {
        isGameSuccess = true;
        BankCanvas.SetActive(false);
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnSuperMarketCanvasCloseClick()
    {
        SuperMarketCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnSuperMarketCanvasBuyClick()
    {
        SuperMarketCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnHospitalCanvasCloseClick()
    {
        HospitalCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnHospitalCanvasCureClick()
    {
        HospitalCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
    }

    public void OnGameStartClick()
    {
        GameStartCanvas.SetActive(false);
        MyAssetsCanvasFold.SetActive(true);
        isPlayerFixed = false;
        GameObject.Find("AudioClick").GetComponent<AudioSource>().Play();
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
