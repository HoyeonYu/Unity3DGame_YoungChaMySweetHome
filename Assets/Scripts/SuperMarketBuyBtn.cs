using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMarketBuyBtn : MonoBehaviour
{
    int foodIdx, foodHungryValue, foodHappyValue, foodPrice;

    public void OnClick()
    {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().OnSuperMarketCanvasBuyClick();

        foodIdx = int.Parse(gameObject.name.Split(new char[] { '_' })[1]);
        foodHungryValue = SuperMarketController.foodHungryValue[foodIdx];
        foodHappyValue = SuperMarketController.foodHappyValue[foodIdx];
        foodPrice = SuperMarketController.foodPrice[foodIdx];

        MyAssetsController.cash -= foodPrice;
        MyHealthController.hungryValue += foodHungryValue;
        MyHealthController.tireValue -= foodHappyValue;

        InfoCanvasController.infoDealTxtdelta = 0;
    }
}
