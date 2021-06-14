using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAssetsController : MonoBehaviour
{
    static public int cash, house, car;
    static public int[] coin;
    GameObject myAssetsFoldText, myAssetsFullText;
    string[] coinNameArr;

    void Start()
    {
        cash = 100000;
        house = 1;
        car = 0;

        coin = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        myAssetsFoldText = GameObject.Find("MyAssetsFoldTxt");
        myAssetsFullText = GameObject.Find("MyAssetsFullTxt");

        coinNameArr = new string[9] {
            "ȣƮ���� (HTC)", "�ƴ����� (ATH)", "���̳��� (HNB)",
            "���� (XBP)", "���̴� ���� (IDA)", "�ǻ縶 (GSM)",
            "��ī�� (COT)", "������� (HVC)", "Ĺ������ (CAT)"
        };
    }

    public void Update()
    {
        string showText = "�� �ڻ�\n\n";
        showText += "   ����: " + cash + "��\n";
        showText += "   ��: " + house + "ä\n";
        showText += "   �ڵ���: " + car + "��\n";
        showText += "   ����: ";

        myAssetsFoldText.GetComponent<Text>().text = showText;

        for (int i = 0; i < 9; i++)
        {
            showText += "\n    - " + coinNameArr[i] + ": " + coin[i] + "��";
        }

        myAssetsFullText.GetComponent<Text>().text = showText;
    }
}
