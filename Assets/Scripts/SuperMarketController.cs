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

        foodName = new string[5] { "��\t", "����", "�ʹ�", "ġŲ", "�ѿ�" };
        foodHungryValue = new int[5] { 20, 10, 25, 30, 45 };
        foodHappyValue = new int[5] { 5, 3, 20, 25, 40 };
        foodPrice = new int[5] { 3000, 1500, 15000, 20000, 200000 };
        foodBuyBtn = new GameObject[5];
        foodBuyBtnTxt = new GameObject[5];

        superMarketInfoTxt.GetComponent<Text>().text =
            "�������\t\t������\t\t������\t\t���� ";

        superMarketInfoTxt.GetComponent<Text>().text +=
            "------------------------------------------------------------------------\n";

        for (int i = 0; i < 5; i++)
        {
            foodBuyBtn[i] = GameObject.Find("SuperBtn_" + i);
            foodBuyBtnTxt[i] = GameObject.Find("SuperBtnTxt_" + i);

            superMarketInfoTxt.GetComponent<Text>().text += foodName[i] + "\t\t\t\t" + 
                foodHungryValue[i] + "\t\t\t\t" + foodHappyValue[i] + "\t\t\t\t" + foodPrice[i] + "��\n";
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
