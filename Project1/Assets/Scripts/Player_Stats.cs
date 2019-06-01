using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    private bool grounded;
    private float ground_RayLength;
    private int layerGround;

    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        ground_RayLength = 0.75f;
        layerGround = 8; // Ground
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray groundHit = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        //if (Physics.Raycast(groundHit, ground_RayLength))
        if (Physics.Raycast(groundHit, ground_RayLength))
        { Debug.Log("grounded"); grounded = true; }
        else
        { grounded = false; }
    }

    public bool IsGrounded()
    {
        return grounded;
    }
}
