using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset;
        movePosition.z = transform.position.z;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}