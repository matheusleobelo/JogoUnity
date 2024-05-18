using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimentTest : MonoBehaviour
{
    private CharacterController characterController;
    private Transform myCamera;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0f, vertical);
        movimento = myCamera.TransformDirection(movimento);
        movimento.y = 0f;

        characterController.Move(movimento * Time.deltaTime * 5);
        characterController.Move(new Vector3(0, -9.81f, 0)* Time.deltaTime);

        //if (movimento != Vector3.zero)
        //{
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10);    
        //}
    }
}
