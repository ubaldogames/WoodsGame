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
        ground_RayLength = 0.25f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray groundHit = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(groundHit, ground_RayLength))
        { grounded = true; }
        else
        { grounded = false; }
    }

    public bool IsGrounded()
    {
        return grounded;
    }
}
