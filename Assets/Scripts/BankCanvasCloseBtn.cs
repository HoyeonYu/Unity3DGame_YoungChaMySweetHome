using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankCanvasCloseBtn : MonoBehaviour
{
    AudioSource audioSource; 
    public void OnClick()
    {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().OnBankCanvasCloseClick();
    }
}
