using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Player_Stats stats;

    private Rigidbody playerRB;
    private float inputH;
    private float inputV;
    private float jumpSpeed;
    private float walkSpeed;
    private float runSpeed;
    private float rotationSpeed;

    private float deadzone;

    private bool changeSpeed;
    private bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Player_Stats>();

        playerRB = GetComponent<Rigidbody>();
        inputH = 0;
        inputV = 0;
        jumpSpeed = 6f;
        walkSpeed = 2f;
        runSpeed = 4f;
        rotationSpeed = 45;

        deadzone = 0.05f;

        changeSpeed = false;
        jumping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /**
         *  TODO: player forward ray 
         */
        Debug.DrawRay(transform.position, transform.forward, Color.blue);

        // if Ctrl is pressed
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        { changeSpeed = !changeSpeed; }

        if (Input.GetKeyDown(KeyCode.Space) && stats.IsGrounded())
        { jumping = true; }
        else
        { jumping = false; }

        if (jumping)
        { Jump(); }

        if (changeSpeed)
        {
            // grab input horizontal and vertical axis values, then multiply them by walkSpeed
            inputH = Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime;
            inputV = Input.GetAxisRaw("Vertical") * runSpeed * Time.deltaTime;
        }
        else
        {
            // grab input horizontal and vertical axis values, then multiply them by walkSpeed
            inputH = Input.GetAxisRaw("Horizontal") * walkSpeed * Time.deltaTime;
            inputV = Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime;
        }

        // if the value of the axises are greater than 0, then changed position
        if ((Mathf.Abs(inputH) + Mathf.Abs(inputV)) != 0)
        {
            // rotate player
            if (Mathf.Abs(inputH) > 0)
            {
                playerRB.rotation = Quaternion.AngleAxis(rotationSpeed * inputH, transform.up) * playerRB.rotation;
            }

            // move backwards
            if (Mathf.Abs(inputV) < 0)
            {

            }
            else // move at normal speed
            { playerRB.transform.Translate((Vector3.right * inputH) + (Vector3.forward * inputV)); }
        }
        
    }
    
    void Jump()
    {
        playerRB.velocity += Vector3.up * jumpSpeed;
        Debug.Log("velocity jump: " + playerRB.velocity);
    }
}
