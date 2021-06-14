using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAssetsController : MonoBehaviour
{
    static public int cash, house;
    static public int[] coin;
    GameObject myAssetsText;
    string[] coinNameArr;

    void Start()
    {
        cash = 100000;
        house = 1;
        coin = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        myAssetsText = GameObject.Find("MyAssetsText");

        coinNameArr = new string[9] {
            "ȣƮ���� (HTC)", "�ƴ����� (ATH)", "���̳��� (HNB)",
            "���� (XBP)", "���̴� ���� (IDA)", "�ǻ縶 (GSM)",
            "��ī�� (COT)", "������� (HVC)", "Ĺ������ (CAT)"
        };
    }

    public void Update()
    {
        myAssetsText.GetComponent<Text>().text = "�� �ڻ�\n\n";
        myAssetsText.GetComponent<Text>().text += "   ����: " + cash + "��\n";
        myAssetsText.GetComponent<Text>().text += "   ��: " + house + "ä\n";

        myAssetsText.GetComponent<Text>().text += "   ����: ";

        for (int i = 0; i < 9; i++)
        {
            myAssetsText.GetComponent<Text>().text += "\n    - " + coinNameArr[i] + ": "
                + coin[i] + "��";
        }
    }
}
