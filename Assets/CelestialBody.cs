using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must have a rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]


public class CelestialBody : MonoBehaviour
{
    //our body must be some rigidbody2d object
    Rigidbody2D celbod;

    //determine whether this body should be influenced by gravity
    public bool is_gravity_affected 
    {
        //get checkbox field from editor
        get
        {
            return is_gravity_affected_f;
        }
        //if we don't already have this body in the bodies list, add it
        set
        {
            if(value==true)
            {
                if(!BodyPhysics.bodies.Contains(this.GetComponent<Rigidbody2D>()))
                {
                    BodyPhysics.bodies.Add(celbod);
                }
                
            }
            else if(value==false)
            {
                BodyPhysics.bodies.Remove(celbod);
            }
            is_gravity_affected_f = value;
        }
    }

    //create gravity affected field
    [SerializeField] bool is_gravity_affected_f; 

    //declare initial velocity and enable boolean
    [SerializeField] Vector3 initial_velocity;
    [SerializeField] bool apply_initial_velocity;

    //handle script being loaded
    void Awake()
    {
        celbod = this.GetComponent<Rigidbody2D>();
    }

    //handle script being enabled
    void OnEnable()
    {
        is_gravity_affected = is_gravity_affected_f;
    }

    //handle start: on start apply initial velocity if enabled
    void Start()
    {
        if(apply_initial_velocity)
        {
            celbod.AddForce(initial_velocity,ForceMode2D.Impulse);
        }
            
    }

    //handle disabling: remove celbod from list
    void OnDisable()
    {
        BodyPhysics.bodies.Remove(celbod);
    }
}
