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
    public float GravForce = 10;
    public float radius = 5f;


    //talk to the particle system for VFX
    public ParticleSystem particalEffects;

    void Start()
    {
        particalEffects.
    }

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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Planet || Debris"))
        {
            Vector2 direction = GravPoint.position - other.transform.position;
            other.attachedRigidbody.AddForce(direction.normalized * attractionForce);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}