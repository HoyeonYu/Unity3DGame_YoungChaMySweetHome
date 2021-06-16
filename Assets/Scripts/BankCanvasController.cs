using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankCanvasController : MonoBehaviour
{
    GameObject bankBuyHouseBtn, bankBuyHouseBtnTxt;

    void Start()
    {
        bankBuyHouseBtn = GameObject.Find("BankBuyHouseBtn");
        bankBuyHouseBtnTxt = GameObject.Find("BankBuyHouseBtnTxt");
    }

    void Update()
    {
        bankBuyHouseBtn.GetComponent<Button>().interactable = true;
        bankBuyHouseBtnTxt.GetComponent<Text>().text = "���� �ż� ����";

        if (MyAssetsController.cash < 200000000)
        {
            bankBuyHouseBtn.GetComponent<Button>().interactable = false;
            bankBuyHouseBtnTxt.GetComponent<Text>().text = "���� �ż� �Ұ���";
        }
    }
}
