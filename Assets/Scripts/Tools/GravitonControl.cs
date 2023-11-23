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
    public Rigidbody2D rb;
    public Vector3 velocity;
    public float GravRadius = 15;


    //talk to the particle system for VFX
    public ParticleSystem particalEffects;

    // Update is called once per frame
    void Update()
    {
        //space bar to activate
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GravitonOn = !GravitonOn;
            if(GravitonOn)
                Debug.Log("Graviton Turned ON");
            else
                Debug.Log("Graviton Turned OFF");
        }

        //for spinning the VFX
        if(GravitonOn)
        {
            particalEffects.Play();
            transform.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));
        }
        
    }
    
    void FixedUpdate()
    {
        if(GravitonOn)
        {
            rb.AddForce(velocity, ForceMode2D.Impulse);
        }
    }

    //drawing the gravity circle in debug
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, GravRadius);
    }
}