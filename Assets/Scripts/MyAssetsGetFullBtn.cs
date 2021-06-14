using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAssetsGetFullBtn : MonoBehaviour
{
    public void OnClick()
    {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().OnCoinGetFullAssetsCanvasClick();
    }
}
