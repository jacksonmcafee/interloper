using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public float attractionForce = 10f;
    // The other planet this one is tethered to.
    public GameObject tetheredTo;
    // A check if this planet is currently being tethered.
    public bool isTethered;

    private Rigidbody2D rb;

    void Start()
    {
        // Retrieve the rigidbody component.
        rb = GetComponent<Rigidbody2D>();
        isTethered = false;
    }

    void FixedUpdate()
    {
        // Only try to pull if the planet is tethered.
        if (isTethered)
            Attract();
    }

    private void Attract()
    {
        // Check if tetheredTo is still valid. If not, stop tethering.
        if (tetheredTo == null)
        {
            isTethered = false;
            return;
        }

        // Get the direction of the other planet.
        Vector2 direction = (tetheredTo.transform.position - transform.position).normalized;

        // Apply force towards the other planet.
        rb.AddForce(direction * attractionForce);
    }
}
