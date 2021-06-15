using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalCureBtn : MonoBehaviour
{
    int cureIdx, cureHurtValue, curePrice;

    public void OnClick()
    {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().OnHospitalCanvasCureClick();

        cureIdx = int.Parse(gameObject.name.Split(new char[] { '_' })[1]);
        cureHurtValue = HospitalCureController.cureHurtValue[cureIdx];
        curePrice = HospitalCureController.curePrice[cureIdx];

        MyAssetsController.cash -= curePrice;
        MyHealthController.hurtValue -= cureHurtValue;
        HospitalCureController.isCured = true;

        InfoCanvasController.infoDealTxtdelta = 0;
    }
}
