using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalCanvasCloseBtn : MonoBehaviour
{
    public void OnClick()
    {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().OnHospitalCanvasCloseClick();
    }
}
