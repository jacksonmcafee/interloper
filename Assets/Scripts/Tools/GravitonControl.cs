using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitonControl : MonoBehaviour
{
    // spot where the planets will be attracted to
    public Transform GravPoint; 
    
    // create state if being active
    private bool GravitonOn = false;
    
    // talk to the different components
    public float GravForce = 10;
    public float radius = 3.18f;

    // talk to the particle system for VFX
    public ParticleSystem particleEffects;

    // list for keeping track of bodies in the graviton field
    private List<CelestialBody> affectedBodies = new List<CelestialBody>();

    void Start()
    {
      // disable particles on start
      particleEffects.Stop();
    }

    // Update is called once per frame
    void Update()
    { 
        // toggle graviton when space is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // toggle graviton status
            GravitonOn = !GravitonOn;
            if(GravitonOn)
            {
                Debug.Log("Graviton Turned ON");
                particleEffects.Play();
            }
            else
            {
                Debug.Log("Graviton Turned OFF");
                particleEffects.Stop();
                ReactivateAllGravity();
            }
        }
        
        
        // behavior when Graviton is enabled
        if(GravitonOn)
        {
            // get colliders in radius
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        
            // for spinning VFX
            transform.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));

            // attraction logic
            foreach (Collider2D col in colliders)
            {
                if (col.CompareTag("Planet") || col.CompareTag("Debris"))
                {
                    CelestialBody celestialBody = col.GetComponent<CelestialBody>();
                    // if collider has Celestial Body component
                    if (celestialBody != null)
                    {
                        // if the body is not already within the affectedBodies list 
                        if(!affectedBodies.Contains(celestialBody))
                        {
                            affectedBodies.Add(celestialBody);
                            celestialBody.is_gravity_affected = false;
                        }

                        // try to get the body's rb
                        Rigidbody2D body = celestialBody.rigbod;
                        if(body != null)
                        {
                            // attract towards the GravPoint 
                            Vector2 direction = GravPoint.position - col.transform.position;
                            body.AddForce(direction.normalized * GravForce);
                        }
                    }
                }
            } 

            // TODO: Integrate this tightly with attraction logic?
            // make a copy so that we can remove bodies as needed
            List<CelestialBody> aBCopy = new List<CelestialBody>(affectedBodies);

            // check if any bodies have exited radius
            foreach (CelestialBody cb in aBCopy)
            {
              bool isMatch = false;

              // verify if that celestial body is still within colliders
              foreach (Collider2D col in colliders)
              {
                // get Celestial Body component to verify if cb is contained or not
                CelestialBody colBody = col.GetComponent<CelestialBody>();

                if (cb == colBody)
                {
                  isMatch = true;
                  break;
                }
              }

              if (!isMatch)
              {
                Debug.Log("Body has exited radius, reactivating gravity for that object.");
                // reactivate gravity for this body because it is no longer in range
                ReactivateGravity(cb);
              }
            }
        }
    }

    // method for reactivating gravity when graviton is toggled off
    void ReactivateAllGravity()
    {
        // iterate through affectedBodies and reactivate gravity 
        foreach (CelestialBody body in affectedBodies)
        {
            ReactivateGravity(body);
        }

        // clear list as no items should exist
        affectedBodies.Clear();
    }

    // method for reactivating gravity for a single body
    void ReactivateGravity(CelestialBody cb)
    {
      // reset gravity control
      cb.is_gravity_affected = true;
      
      // remove that body from the affectedBodies
      affectedBodies.Remove(cb);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}
