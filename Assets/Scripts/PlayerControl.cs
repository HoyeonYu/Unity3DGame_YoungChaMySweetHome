using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bank")
        {
            Debug.Log("Coll Bank");

            GameObject director = GameObject.Find("GameDirector");

            if (!(director.GetComponent<GameDirector>().RealEstateCanvas.active ||
                director.GetComponent<GameDirector>().CoinCanvas.active ||
                director.GetComponent<GameDirector>().CoinDealCanvas.active))
            {
                director.GetComponent<GameDirector>().BankCanvas.SetActive(true);
                GameDirector.isPlayerFixed = true;
            }
        }
    }
}
