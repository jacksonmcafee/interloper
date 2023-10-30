using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must have a rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]

public class Planetoid : CelestialBody
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        Debug.Log(contact.point);
        Debug.DrawLine(contact.point,contact.otherCollider.ClosestPoint(contact.point),Color.red,1f);
        
        //add mass to other rigidbody
        collision.otherRigidbody.mass += 0.5f;
        Debug.Log(collision.otherRigidbody.mass);
        Debug.Log(collision.relativeVelocity.magnitude);

        if(collision.relativeVelocity.magnitude > 0)
        {
            makeDebris(1, collision);
        }
        Destroy(gameObject);
    }

    public void makeDebris(int quantity, Collision2D collision)
    {
        for(int i = 0; i < quantity; i++)
        {
            Instantiate(gameObject, collision.transform.position + new Vector3 (collision.relativeVelocity.x, collision.relativeVelocity.y, 0), Quaternion.identity);
        }
    }

}
