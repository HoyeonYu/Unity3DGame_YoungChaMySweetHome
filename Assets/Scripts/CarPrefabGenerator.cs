using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPrefabGenerator : MonoBehaviour
{
    public GameObject[] carPrefab;
    public float initPosX, initPosZ, endPosX, endPosZ, span;
    float initPosY;
    float delta;

    void Start()
    {
        delta = 0;
        initPosY = 17.83663f;

        for (int i = 0; i < 5; i++)
        {
            int randPrefabIdx = Random.Range(0, carPrefab.Length);
            GameObject gameObject = Instantiate(carPrefab[randPrefabIdx]);

            gameObject.transform.position 
                = new Vector3(Random.Range(Mathf.Min(initPosX, endPosX), Mathf.Max(initPosX, endPosX)),
                initPosY, initPosZ);
        }
    }

    void Update()
    {
        this.delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;
            
            GameObject gameObject = Instantiate(carPrefab[Random.Range(0, carPrefab.Length)]);
            gameObject.transform.position = new Vector3(initPosX, initPosY, initPosZ);
        }
    }
}
