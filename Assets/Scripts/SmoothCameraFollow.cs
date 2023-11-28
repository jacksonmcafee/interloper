using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float damping = 0.2f;

    private Vector3 cameraVelocity = Vector3.zero;

    void Start()
    {
        target = GameObject.Find("PlayerShip").transform;
        if (target == null)
        {
            Debug.LogError("PlayerShip GameObject not found!");
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Smoothly follow the target
            Vector3 movePosition = target.position + offset;
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, movePosition, ref cameraVelocity, damping);
            transform.position = smoothPosition;
        }
        else
        {
            Debug.LogError("Target is null!");
        }
    }
}

