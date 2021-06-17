using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTargetPositionController : MonoBehaviour
{
    static public Vector3 targetPos; 
    RaycastHit hit;
    GameObject targetParticle;

    private void Start()
    {
        targetParticle = GameObject.Find("TargetParticle");
    }

    void Update() { 
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (GameDirector.MyAssetsCanvasFold.active || GameDirector.MyAssetsCanvasFull.active)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (GameDirector.isPlayerFixed)
                    {
                        targetPos = transform.position;
                    }

                    else
                    {
                        targetPos = new Vector3(hit.point.x, 18f, hit.point.z);

                        if (targetPos != transform.position)
                        {
                            transform.position = targetPos;
                            targetParticle.GetComponent<ParticleSystem>().Play();
                        }
                    }
                }
            }
        }
    }
}
