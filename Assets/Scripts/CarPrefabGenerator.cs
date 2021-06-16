using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPrefabGenerator : MonoBehaviour
{
    public GameObject[] carPrefab;
    public float initPosX, initPosZ;
    public int generatorCode, carGenerateSpan;
    float initPosY, carGenerateDelta;
    static public int[] endPos;

    void Start()
    {
        carGenerateDelta = 0;
        initPosY = 17.83663f;
        endPos = new int[4] { 60, 450, 365, -34 };

        for (int i = 0; i < 5; i++)
        {
            int randPrefabIdx = Random.Range(0, carPrefab.Length);
            GameObject gameObject = Instantiate(carPrefab[randPrefabIdx]);

            if (generatorCode < 2)
            {
                gameObject.transform.position
                    = new Vector3(Random.Range(Mathf.Min(initPosX, endPos[generatorCode]),
                    Mathf.Max(initPosX, endPos[generatorCode])),
                    initPosY, initPosZ);
            }

            else
            {
                gameObject.transform.position
                    = new Vector3(initPosX, initPosY,
                    Random.Range(Mathf.Min(initPosZ, endPos[generatorCode]), 
                    Mathf.Max(initPosZ, endPos[generatorCode])));
            }
        }
    }

    void Update()
    {
        carGenerateDelta += Time.deltaTime;

        if (carGenerateDelta > carGenerateSpan)
        {
            carGenerateDelta = 0;

            int randPrefabIdx = Random.Range(0, carPrefab.Length);
            GameObject gameObject = Instantiate(carPrefab[randPrefabIdx]);

            gameObject.transform.position = new Vector3(initPosX, initPosY, initPosZ);
        }
    }
}
