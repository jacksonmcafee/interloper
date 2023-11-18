using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage { get; set; }
    public float speed { get; set; }
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitializeVelocity();
    }

    private void InitializeVelocity()
    {
        // This assumes the projectile's forward direction is aligned with its local up vector.
        // If your projectile's forward direction is different, adjust accordingly.
        rb.velocity = transform.up * speed;
    }

    public virtual void HandleCollision(Collider2D other)
    {
        // Collision handling logic
    }
}