using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAssetsController : MonoBehaviour
{
    static public int cash, house, car;
    public int cashPublic;
    static public int[] coin;
    GameObject myAssetsFoldText, myAssetsFullText, myAssetsCoinNumText;
    string[] coinNameArr;

    void Start()
    {
        cash = cashPublic;
        house = 1;
        car = 0;

        coin = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        myAssetsFoldText = GameObject.Find("MyAssetsFoldTxt");
        myAssetsFullText = GameObject.Find("MyAssetsFullTxt");
        myAssetsCoinNumText = GameObject.Find("MyAssetsCoinNumTxt");

        coinNameArr = new string[9] {
            "ȣƮ���� (HTC)", "�ƴ����� (ATH)", "���̳��� (HNB)",
            "���� (XBP)", "���̴� ���� (IDA)", "�ǻ縶 (GSM)",
            "��ī�� (COT)", "������� (HVC)", "Ĺ������ (CAT)"
        };
    }

    public void Update()
    {
        string commonTxt = "<b>�ڻ�</b>\n";
        commonTxt += "  - �� �� ���� (2��):\t";

        string houseAvailable = "<color=#ff0000>�Ұ���</color>\n";

        if (MyAssetsController.cash >= 200000000)
        {
            houseAvailable = "<color=#22FFAA>����</color>\n"; 
        }

        commonTxt += houseAvailable;
        commonTxt += "  - ���� / ����:\t" + cash + "��\n";
        commonTxt += "  - ����\n";

        myAssetsFoldText.GetComponent<Text>().text = commonTxt;
        myAssetsFullText.GetComponent<Text>().text = commonTxt;
        myAssetsCoinNumText.GetComponent<Text>().text = "";

        for (int i = 0; i < 9; i++)
        {
            myAssetsFullText.GetComponent<Text>().text += "    - " + coinNameArr[i] + ":\n";
            myAssetsCoinNumText.GetComponent<Text>().text += coin[i] + "��\n";
        }
    }
}