using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCanvasController : MonoBehaviour
{
    GameObject InfoCanvasTxt;
    float infoTxtSpan = 2.0f;
    static public float infoTxtdelta = 5;

    void Start()
    {
        InfoCanvasTxt = GameObject.Find("InfoCanvasTxt");
    }

    // Update is called once per frame
    void Update()
    {
        InfoCanvasTxt.GetComponent<Text>().text = "거래 완료되었습니다.";
        infoTxtdelta += Time.deltaTime;

        if (infoTxtdelta > infoTxtSpan)
        {
            InfoCanvasTxt.GetComponent<Text>().text = "";
        }
    }
}
