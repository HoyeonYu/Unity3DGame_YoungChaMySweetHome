using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSignContoller : MonoBehaviour
{
    public int axisX, axisY, axisZ, angle;

    void Update()
    {
        transform.Rotate(new Vector3(angle * axisX, angle * axisY, angle * axisZ)
            * Time.deltaTime);
    }
}
