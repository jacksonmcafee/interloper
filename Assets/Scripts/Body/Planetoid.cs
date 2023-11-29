using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must have a rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]

public class Planetoid : CelestialBody
{
    public GameObject debrisPrefab;
    public GameObject explosionPrefab;

    public bool destroyed;

    public float health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        //Debug.Log("collision:");
        //Debug.Log(collision.relativeVelocity.magnitude); //same for both sides
        //Debug.Log(collision.transform.position);         //flipped
        //Debug.Log(collision.otherRigidbody.position);    //flipped
        if (!destroyed)
        {
            //Debug.Log("not destroyed, hit check...");
            if(collision.gameObject.tag == "Planet")
            {
                Debug.Log("hit other planet...");
                Planetoid pscript = collision.gameObject.GetComponent<Planetoid>();
                Rigidbody2D prigbod = collision.gameObject.GetComponent<Rigidbody2D>();
                if (pscript != null) 
                {
                    if((pscript.destroyed == true) && (prigbod.mass < rigbod.mass))
                    {
                        Debug.Log("Bigger planet recieving mass, not deleting...");
                        Debug.Log("Planet is now:");
                        Debug.Log(prigbod.mass + rigbod.mass);
                    }
                    else
                    {
                        collision.gameObject.transform.localScale += new Vector3(rigbod.mass/5, rigbod.mass/5, 0);
                        prigbod.mass += rigbod.mass;
                        destroyed = true;
                        Destroy(gameObject);
                    }
                }
                /*Planetoid pscript = collision.gameObject.GetComponent<Planetoid>();
                if (pscript != null) 
                {
                    Debug.Log("breaking...");
                    destroyed = true;
                    pscript.destroyed = true;
                    Destroy(gameObject);
                    makeDebris(collision);
                }*/
            }
            else if(collision.gameObject.tag == "Singularity")
            {
                Debug.Log("hit THE SINGULARITY...");
                Rigidbody2D prigbod = collision.gameObject.GetComponent<Rigidbody2D>();
                Debug.Log("Singularity hit object of mass:");
                Debug.Log(rigbod.mass);
                Debug.Log("Singularity is now:");
                Debug.Log(prigbod.mass + rigbod.mass);
                prigbod.mass += rigbod.mass;
                collision.gameObject.transform.localScale += new Vector3(rigbod.mass/25, rigbod.mass/25, 0);
                destroyed = true;
                Destroy(gameObject);
            }
            else if(collision.gameObject.tag == "Projectile")
            {
                Projectile pscript = collision.gameObject.GetComponent<Projectile>();
                if (pscript != null) 
                {
                    health -= pscript.damage;
                    if(health <= 0)
                    {
                        Debug.Log("breaking...");
                        destroyed = true;
                        Destroy(gameObject);
                        makeDebris(collision);
                    }
                }
            }
        }
        else if (destroyed)
        {
            Debug.Log("i shouldn't exist...");
            Destroy(gameObject); //we shouldn't exist right now
        }
    }

    // j: upvote on that
    //I KNOW THIS IS DISGUSTING
    //PLEASE FORGIVE ME FOR WHAT I MUST DO
    private void makeDebris(Collision2D collision)
    {
        GameObject explosion = Instantiate(explosionPrefab, collision.otherRigidbody.position, Quaternion.identity);

        //Debug.Log("spawning updebris: ");
        //Debug.Log(collision.otherRigidbody.position + Vector2.up + collision.relativeVelocity);
        //Debug.Log("with velocity: ");
        //Debug.Log(collision.relativeVelocity - Vector2.up);

        Vector3 upposshift = collision.otherRigidbody.position + Vector2.up;
        Vector3 downposshift = collision.otherRigidbody.position + Vector2.down;
        GameObject updebris = Instantiate(debrisPrefab, upposshift, Quaternion.identity);
        GameObject downdebris = Instantiate(debrisPrefab, downposshift, Quaternion.identity);
        updebris.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity.normalized + Vector2.up, ForceMode2D.Impulse);
        downdebris.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity.normalized + Vector2.down, ForceMode2D.Impulse);

        if(rigbod.mass > 0.5) //add 2 debris w/ symmetry
        {
            Vector3 rightposshift = collision.otherRigidbody.position + Vector2.right;
            Vector3 leftposshift = collision.otherRigidbody.position + Vector2.left;
            GameObject rightdebris = Instantiate(debrisPrefab, rightposshift, Quaternion.identity);
            GameObject leftdebris = Instantiate(debrisPrefab, leftposshift, Quaternion.identity);
            rightdebris.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity.normalized + Vector2.right, ForceMode2D.Impulse);
            leftdebris.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity.normalized + Vector2.left, ForceMode2D.Impulse);
        }
        
        if(rigbod.mass > 1) //add 4 debris w/ symmetry
        {
            Vector3 uprightposshift = collision.otherRigidbody.position + (Vector2.up + Vector2.right).normalized;
            Vector3 downrightposshift = collision.otherRigidbody.position + (Vector2.down + Vector2.right).normalized;
            Vector3 upleftposshift = collision.otherRigidbody.position + (Vector2.up + Vector2.left).normalized;
            Vector3 downleftposshift = collision.otherRigidbody.position + (Vector2.down + Vector2.left).normalized;

            GameObject uprightdebris = Instantiate(debrisPrefab, uprightposshift, Quaternion.identity);
            GameObject downrightdebris = Instantiate(debrisPrefab, downrightposshift, Quaternion.identity);
            GameObject upleftdebris = Instantiate(debrisPrefab, upleftposshift, Quaternion.identity);
            GameObject downleftdebris = Instantiate(debrisPrefab, downleftposshift, Quaternion.identity);

            uprightdebris.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity.normalized + (Vector2.up + Vector2.right).normalized, ForceMode2D.Impulse);
            downrightdebris.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity.normalized + (Vector2.down + Vector2.right).normalized, ForceMode2D.Impulse);
            upleftdebris.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity.normalized + (Vector2.up + Vector2.left).normalized, ForceMode2D.Impulse);
            downleftdebris.GetComponent<Rigidbody2D>().AddForce(collision.relativeVelocity.normalized + (Vector2.down + Vector2.left).normalized, ForceMode2D.Impulse);
        }
    }
}
