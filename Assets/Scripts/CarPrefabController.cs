using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPrefabController : MonoBehaviour
{
    int generatorCode;
    int[] endPos;

    private void Start()
    {
        endPos = CarPrefabGenerator.endPos;
    }

    void Update()
    {
        generatorCode = int.Parse(gameObject.name.Split('_')[1]);

        if (generatorCode == 0)
        {
            transform.Translate(10 * new Vector3(0, 0, 1) * Time.deltaTime);

            if (transform.position.x < endPos[0])
            {
                Destroy(gameObject);
            }
        }

        else if (generatorCode == 1)
        {
            transform.Translate(10 * new Vector3(0, 0, 1) * Time.deltaTime);

            if (transform.position.x > endPos[1])
            {
                Destroy(gameObject);
            }
        }

        else if (generatorCode == 2)
        {
            transform.Translate(10 * new Vector3(0, 0, 1) * Time.deltaTime);

            if (transform.position.z > endPos[2])
            {
                Destroy(gameObject);
            }
        }

        else if (generatorCode == 3)
        {
            transform.Translate(10 * new Vector3(0, 0, 1) * Time.deltaTime);

            if (transform.position.z < endPos[3])
            {
                Destroy(gameObject);
            }
        }

    }
}
