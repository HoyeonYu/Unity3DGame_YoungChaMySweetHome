using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCanvasController : MonoBehaviour
{
    GameObject InfoCanvasTxt;
    float infoDealTxtSpan = 2.0f;
    static public float infoDealTxtdelta = 10;

    void Start()
    {
        InfoCanvasTxt = GameObject.Find("InfoCanvasTxt");
    }

    void Update()
    {
        InfoCanvasTxt.GetComponent<Text>().text = "거래 완료되었습니다.";
        infoDealTxtdelta += Time.deltaTime;

        if (infoDealTxtdelta > infoDealTxtSpan)
        {
            InfoCanvasTxt.GetComponent<Text>().text = "";
            infoDealTxtdelta = 10;
        }
    }
}
