using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody playerRB;
    private float inputH;
    private float inputV;
    private float jumpSpeed;
    private float walkSpeed;
    private float runSpeed;
    private float deadzone;

    private bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        inputH = 0;
        inputV = 0;
        jumpSpeed = 2f;
        walkSpeed = 2f;
        runSpeed = 4f;
        
        deadzone = 0.125f;

        jumping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // grab input horizontal and vertical axis values
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        if (Mathf.Abs(inputH) > deadzone)
        {
            playerRB.transform.Translate(Vector3.right * inputH * walkSpeed * Time.deltaTime);
        }

        if (Mathf.Abs(inputV) > deadzone)
        {
            playerRB.transform.Translate(Vector3.forward * inputV * walkSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }

        if (jumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        playerRB.transform.position = Vector3.Lerp(transform.position, transform.up * jumpSpeed, Time.deltaTime);
        //if (playerRB.)
    }
}
