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

    private Vector3 newPosition;
    private Quaternion camRotation;
    private float camXDistance;
    private float camYDistance;
    private float camAngle;
    private float camSpeed;

    void Start()
    {
        camXDistance = -5;
        camYDistance = 3;
        camAngle = 30;
        camSpeed = 5f;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Debug.Log("entered Find Gameobject if-statement");
            player = GameObject.FindGameObjectWithTag("Player");
            playerRB = player.GetComponent<Rigidbody>();

            transform.position = player.transform.position + (Vector3.forward * camXDistance) + (Vector3.up * camYDistance);
            //camRotation = Quaternion.LookRotation(player.transform.forward, player.transform.up * -1);
            camRotation = Quaternion.AngleAxis(camAngle, Vector3.right) * Quaternion.LookRotation(player.transform.forward, player.transform.up);
            transform.SetPositionAndRotation(transform.position, camRotation);
        }
    }
    
    void FixedUpdate()
    {
        camRotation = Quaternion.AngleAxis(camAngle, Vector3.right) * Quaternion.LookRotation(player.transform.forward, player.transform.up);
        newPosition = player.transform.position + (Vector3.forward * camXDistance) + (Vector3.up * camYDistance);

        // if player movement changes, so does the Main Camera's movement
        if (transform.position != newPosition)
        {
            Debug.Log("entered transform if statement");
            //transform.position = newPosition;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * camSpeed);
            transform.SetPositionAndRotation(transform.position, camRotation);
        }
    }
}
