using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    public float maxSpeed = 5f;
    public float accelerationForce = .1f;
    public float boostMultiplier = 2.5f; // Multiplier for boosted speed
    public float decelerationRate = 0.975f; // Adjusted for longer drift
    public float brakingRate = 0.9f; // Rate of deceleration when braking
    public float maxRotationSpeed = 200f;

    private float accelerationMultiplier = 1f;
    private float accelerationIncreaseRate = 0.1f;
    private float maxAccelerationMultiplier = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        bool isBoosting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Check for manual braking
        if (Input.GetKey(KeyCode.S))
        {
            ApplyManualBraking();
        }
        else
        {
            Accelerate(yAxis, isBoosting);
        }

        SmoothRotate(-xAxis);
        ClampVelocity();
    }

    private void Accelerate(float accel, bool isBoosting)
    {
        float currentAccelerationForce = accelerationForce;
        if (isBoosting)
        {
            currentAccelerationForce *= boostMultiplier;
        }

        if (accel != 0)
        {
            accelerationMultiplier = Mathf.Min(accelerationMultiplier + accelerationIncreaseRate * Time.deltaTime, maxAccelerationMultiplier);
        }
        else
        {
            accelerationMultiplier = 1f;
        }

        Vector2 force = transform.up * accel * currentAccelerationForce * accelerationMultiplier;
        rb.AddForce(force);
    }

    private void SmoothRotate(float rotationInput)
    {
        rb.angularVelocity = rotationInput * maxRotationSpeed;
    }

   private void ClampVelocity()
{
    if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed)
    {
        // Interpolating towards the clamped velocity
        Vector2 clampedVelocity = rb.velocity.normalized * maxSpeed;
        rb.velocity = Vector2.Lerp(rb.velocity, clampedVelocity, Time.deltaTime * 5f); // Adjust the factor 5f as needed
    }
}

    // Manual Braking Function
    private void ApplyManualBraking()
    {
        rb.velocity *= brakingRate;
    }
}
