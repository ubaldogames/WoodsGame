using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    private bool grounded;
    private float ground_RayLength;

    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        ground_RayLength = 0.75f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray groundHit = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, -transform.up, Color.green);
        
        //if (Physics.Raycast(groundHit, ground_RayLength))
        if (Physics.Raycast(groundHit, ground_RayLength))
        { grounded = true; }
        else
        { grounded = false; }
    }

    public bool IsGrounded()
    {
        return grounded;
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        { grounded = true; }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        { grounded = false; }
    }*/
}
