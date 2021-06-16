using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperMarketController : MonoBehaviour
{
    GameObject superMarketInfoTxt;
    GameObject[] foodBuyBtn, foodBuyBtnTxt;
    static public string[] foodName;
    static public int [] foodHungryValue, foodHappyValue, foodPrice;

    void Start()
    {
        superMarketInfoTxt = GameObject.Find("SuperMarketInfoTxt");

        foodName = new string[5] { "����", "����", "�ʹ�", "ġŲ", "�ѿ�" };
        foodHungryValue = new int[5] { 5, 10, 25, 30, 45 };
        foodHappyValue = new int[5] { 3, 10, 20, 25, 40 };
        foodPrice = new int[5] { 1500, 3000, 15000, 20000, 200000 };
        foodBuyBtn = new GameObject[5];
        foodBuyBtnTxt = new GameObject[5];

        superMarketInfoTxt.GetComponent<Text>().text =
            "�������    " + "������      "
            + "�Ƿ�ȸ��    " + "����\n";

        superMarketInfoTxt.GetComponent<Text>().text +=
            "----------------------------------------------------------------------\n";

        for (int i = 0; i < 5; i++)
        {
            foodBuyBtn[i] = GameObject.Find("SuperBtn_" + i);
            foodBuyBtnTxt[i] = GameObject.Find("SuperBtnTxt_" + i);

            superMarketInfoTxt.GetComponent<Text>().text += foodName[i] + "            "
                + foodHungryValue[i].ToString().PadRight(15, ' ');

            if (i == 0)
            {
                superMarketInfoTxt.GetComponent<Text>().text += " ";
            }

            superMarketInfoTxt.GetComponent<Text>().text += foodHappyValue[i].ToString().PadRight(16, ' ') 
                + foodPrice[i] + "��\n";
        }
    }

    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            foodBuyBtn[i].GetComponent<Button>().interactable = true;
            foodBuyBtnTxt[i].GetComponent<Text>().text = "���� ����";

            if (foodPrice[i] > MyAssetsController.cash)
            {
                foodBuyBtn[i].GetComponent<Button>().interactable = false;
                foodBuyBtnTxt[i].GetComponent<Text>().text = "���� �Ұ�";
            }
        }
    }
}
