using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Camera fpsCam;

    [SerializeField]
    float MoveSpeed;
    float rotSpeed;
    float currentRot;

    GameObject director;

    void Start()
    {
        MoveSpeed = 10.0f;
        rotSpeed = 3.0f;
        currentRot = 0f;
    }

    void Update()
    {
        if (!GameDirector.isPlayerFixed)
        {
            PlayerMove();
            RotationControl();
        }
    }

    void PlayerMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * MoveSpeed;
        float zSpeed = zInput * MoveSpeed;

        transform.Translate(Vector3.forward * zSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
    }

    void RotationControl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        currentRot -= rotX;
        currentRot = Mathf.Clamp(currentRot, -50f, 50f);

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bank")
        {
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
