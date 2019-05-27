using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray groundHit = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundHit, 2f))
        {
            grounded = true;
        }
        else { grounded = false; }

        Debug.Log("Grounded: " + IsGrounded());
    }

    public bool IsGrounded()
    {
        return grounded;
    }
}
