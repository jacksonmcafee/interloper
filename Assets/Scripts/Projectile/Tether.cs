using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : Projectile
{
    public float despawnTime = .5f;
    
    public GameObject FlagPrefab;

    //flag if the tether is attached to a single planet
    private bool isTethered = false;
    //keep track of attached planets
    private GameObject firstBody;
    private GameObject secondBody;
    private GameObject anchorFlag; //the flag that goes on the first tethered planet

    //line renderer
    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        StartCoroutine(DelayedDespawn());
    }

    IEnumerator DelayedDespawn()
    {
        yield return new WaitForSeconds(despawnTime);

        //if the flag exists, destroy it
        if (anchorFlag != null)
        {
            Destroy(anchorFlag);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.CompareTag("Planet"))
        {
            if (!isTethered)
            {
                Debug.Log("Tethered a Planet");

                if (firstBody == null)
                {
                    firstBody = other.gameObject;
                    Vector3 bodyPos = other.transform.position;
                    Instantiate(FlagPrefab, bodyPos, Quaternion.identity, other.transform);
                }
                else if (firstBody != other.gameObject)
                {
                    secondBody = other.gameObject;
                    Vector3 firstPos = firstBody.transform.position;
                    Vector3 secondPos = secondBody.transform.position;

                    //setting the line renderer positions
                    lr.SetPosition(0, firstPos);
                    lr.SetPosition(1, secondPos);

                    //tether logic goes here

                    isTethered = true;
                }
            }
        }
        else
        {
            Destroy(gameObject); // Destroy the tether if it collides with other objects
        }
    }
    
}