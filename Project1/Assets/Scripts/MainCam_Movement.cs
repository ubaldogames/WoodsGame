using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for Main Camera's movement, which the camera will follow the player.
/// </summary>
public class MainCam_Movement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRB;

    private Quaternion camRotation;
    private float camDistance;
    
    void Start()
    {
        camRotation = Quaternion.LookRotation(player.transform.forward, player.transform.up);
        camDistance = -5;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerRB = player.GetComponent<Rigidbody>();
            transform.position = player.transform.position + (Vector3.forward * camDistance);

            transform.SetPositionAndRotation(transform.position, camRotation);
        }
    }
    
    void FixedUpdate()
    {
        // if player movement changes, so does the Main Camera's movement
        
    }
}
