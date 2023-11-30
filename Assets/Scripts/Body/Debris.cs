using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must have a rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]

public class Debris : CelestialBody
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("debris collision...");
        ContactPoint2D contact = collision.GetContact(0);
        // Debug.Log(contact.point);
        // Debug.DrawLine(contact.point,contact.otherCollider.ClosestPoint(contact.point),Color.red,1f);
        if(collision.gameObject.tag == "Planet")
        {
            //Debug.Log("hit planet...");
            // add mass to other rigidbody
            collision.otherRigidbody.mass += 1;
            // Debug.Log(collision.otherRigidbody.mass);
            // Debug.Log(collision.relativeVelocity.magnitude);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Singularity")
        {
            collision.otherRigidbody.mass += 1;
            collision.gameObject.transform.localScale += new Vector3(rigbod.mass/(10*Mathf.Sqrt(rigbod.mass)), rigbod.mass/(10*Mathf.Sqrt(rigbod.mass)), 0);
            //Debug.Log("hit THE SINGULARITY...");
            Destroy(gameObject);
        }
    }
}
