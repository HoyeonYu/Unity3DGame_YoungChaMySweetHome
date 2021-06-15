using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPrefabController : MonoBehaviour
{
    void Update()
    {
        //transform.localScale = new Vector3(3, 3, 3);
        transform.Translate(10 * new Vector3(0, 0, 1) * Time.deltaTime);

        if (transform.position.x < 48)
        {
            Destroy(gameObject);
        }
    }
}
