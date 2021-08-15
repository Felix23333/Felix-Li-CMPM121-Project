using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 10;
    CharacterController controller;
    public float gravity = 9.8f;
    Camera currentCamera;
    Vector3 cameraDir;

    //temp var
    float dirY;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentCamera = Camera.main;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //handle jump and move
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        if(controller.isGrounded)
        {
            dirY = Input.GetAxis("Jump") * jumpHeight;
        }

        //move & jump
        dirY -= gravity * Time.deltaTime;
        dir.y = dirY;
        controller.Move(dir * Time.deltaTime * speed);
    }
}
