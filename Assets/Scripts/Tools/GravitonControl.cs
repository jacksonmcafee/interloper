using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitonControl : MonoBehaviour
{
    //spot where the planets will be attracted to
    public Transform GravPoint; 
    //create state if being active
    private bool GravitonOn = false;
    //talk to the different components
    public float GravForce = 10;
    public float radius = 3.18f;


    //talk to the particle system for VFX
    public ParticleSystem particalEffects;

    //list for keeping track of bodies in the graviton field
    private List<CelestialBody> affectedBodies = new List<CelestialBody>();

    // Update is called once per frame
    void Update()
    {
        if(!GravitonOn)
            particalEffects.Stop();
        //space bar to activate
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GravitonOn = !GravitonOn;
            if(GravitonOn)
            {
                Debug.Log("Graviton Turned ON");
                particalEffects.Play();
            }
            else
            {
                Debug.Log("Graviton Turned OFF");
                particalEffects.Stop();
                ReactivateGravity();
            }
                
        }
        
        //what happens when the Graviton is turned on
        if(GravitonOn)
        {
            //for spinning VFX
            transform.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));

            //attraction logic
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D col in colliders)
            {
                if (col.CompareTag("Planet") || col.CompareTag("Debris"))
                {
                    CelestialBody celestialBody = col.GetComponent<CelestialBody>();
                    if (celestialBody != null)
                    {
                        if(!affectedBodies.Contains(celestialBody))
                        {
                            affectedBodies.Add(celestialBody);
                            celestialBody.is_gravity_affected = false;
                        }

                        Rigidbody2D body = celestialBody.rigbod;
                        if(body != null)
                        {
                            Vector2 direction = GravPoint.position - col.transform.position;
                            body.AddForce(direction.normalized * GravForce);
                        }
                    }
                }
            }
        }
        
    }

    //method for reactivating gravity upon exit or graviton field
    void ReactivateGravity()
    {
        foreach (CelestialBody body in affectedBodies)
        {
            body.is_gravity_affected = true;
        }
        affectedBodies.Clear();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}