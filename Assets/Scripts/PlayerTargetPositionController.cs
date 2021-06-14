using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetPositionController : MonoBehaviour
{
    static public Vector3 targetPos; 
    RaycastHit hit;

    void Update() { 
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                targetPos = new Vector3(hit.point.x, 18f, hit.point.z);
                transform.position = targetPos;
            }
        }
    }
}
