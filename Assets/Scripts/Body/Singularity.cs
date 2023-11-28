using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must have a rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]

public class Singularity : CelestialBody
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
