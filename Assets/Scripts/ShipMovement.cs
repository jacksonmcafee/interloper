using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // rigidbody component
    private Rigidbody2D rb;

    // movement velocity cap
    public float velocityCap = 1f;

    // rotation speed (might need to add a cap)
    public float rotationSpeed = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // get movement input
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        // transform the ship
        Accelerate(yAxis);
        Rotate(-xAxis * rotationSpeed);
    }

    private void Accelerate(float accel)
    {
        // add force to the ship
        Vector2 force = transform.up * accel;
        rb.AddForce(force);
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -velocityCap, velocityCap);
        float y = Mathf.Clamp(rb.velocity.y, -velocityCap, velocityCap);

        rb.velocity = new Vector2(x, y);
    }

    private void Rotate(float rotation)
    {
        // rotate the ship
        transform.Rotate(0, 0, rotation);
    }

}
