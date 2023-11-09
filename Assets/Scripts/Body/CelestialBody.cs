using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must have a rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]


public class CelestialBody : MonoBehaviour
{
    //our body must be some rigidbody2d object
    public Rigidbody2D rigbod;
    //create gravity affected field
    [SerializeField] bool is_gravity_affected_f; 

    //create gravity biased field
    [SerializeField] bool is_gravity_biased_f; 

    //declare initial velocity and enable boolean
    [SerializeField] public Vector3 initial_velocity;
    [SerializeField] bool apply_initial_velocity;

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
                if(!BodyPhysics.celbodies.Contains(this))
                {
                    BodyPhysics.celbodies.Add(this);
                }
                
            }
            else if(value==false)
            {
                BodyPhysics.celbodies.Remove(this);
            }
            is_gravity_affected_f = value;
        }
    }

    //determine whether this body should be unequally influenced by gravity, not allowing other bodies to pull it
    public bool is_gravity_biased
    {
        //get checkbox field from editor
        get
        {
            return is_gravity_biased_f;
        }
        //if we don't already have this body in the bodies list, add it
        set
        {
            is_gravity_biased_f = value;
        }
    }


    //handle script being loaded
    void Awake()
    {
        rigbod = this.GetComponent<Rigidbody2D>();
    }

    //handle script being enabled
    void OnEnable()
    {
        is_gravity_affected = is_gravity_affected_f;
        is_gravity_biased = is_gravity_biased_f;
    }

    //handle start: on start apply initial velocity if enabled
    void Start()
    {
        if(apply_initial_velocity)
        {
            rigbod.AddForce(initial_velocity,ForceMode2D.Impulse);
        }
            
    }

    //handle disabling: remove celbody from list
    void OnDisable()
    {
        BodyPhysics.celbodies.Remove(this);
    }
}
