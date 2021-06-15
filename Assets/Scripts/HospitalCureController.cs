using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HospitalCureController : MonoBehaviour
{
    GameObject hospitalInfoTxt;
    GameObject[] cureBtn, cureBtnTxt;
    static public string[] cureName;
    static public int[] cureHurtValue, curePrice;
    static public bool isCured;

    void Start()
    {
        hospitalInfoTxt = GameObject.Find("HospitalInfoTxt");

        cureName = new string[3] { "연고 바르기", "통증 주사 맞기", "수술하기"};
        cureHurtValue = new int[3] { 10, 40, 70 };
        curePrice = new int[3] { 10000, 20000, 100000 };
        cureBtn = new GameObject[3];
        cureBtnTxt = new GameObject[3];
        isCured = false;

        hospitalInfoTxt.GetComponent<Text>().text =
            "치료명                    " + "부상 회복       " + "가격\n";

        hospitalInfoTxt.GetComponent<Text>().text +=
            "--------------------------------------------------------------------\n";

        for (int i = 0; i < 3; i++)
        {
            cureBtn[i] = GameObject.Find("HospitalBtn_" + i);
            cureBtnTxt[i] = GameObject.Find("HospitalBtnTxt_" + i);

            hospitalInfoTxt.GetComponent<Text>().text += cureName[i].PadRight(15, ' ');

            if (i == 0)
            {
                hospitalInfoTxt.GetComponent<Text>().text += "   ";
            }

            else if (i == 2)
            {
                hospitalInfoTxt.GetComponent<Text>().text += "      ";
            }

            hospitalInfoTxt.GetComponent<Text>().text += cureHurtValue[i].ToString().PadRight(20, ' ') 
                + curePrice[i] + "원\n";
        }
    }

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            cureBtn[i].GetComponent<Button>().interactable = true;
            cureBtnTxt[i].GetComponent<Text>().text = "치료 가능";

            if (curePrice[i] > MyAssetsController.cash)
            {
                cureBtn[i].GetComponent<Button>().interactable = false;
                cureBtnTxt[i].GetComponent<Text>().text = "치료 불가";
            }
        }
    }
}
