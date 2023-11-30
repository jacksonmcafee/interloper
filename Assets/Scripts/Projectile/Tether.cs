using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : Projectile
{
    public float despawnTime = .5f;
    public float attractionForce = 100f;

    public GameObject FlagPrefab;

    // flag if the tether is attached to a single planet
    private bool isTethered = false;

    // keep track of attached planets
    private static GameObject firstBody;
    private static GameObject secondBody;
    private GameObject anchorFlag; //the flag that goes on the first tethered planet

    // line renderer
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

        Debug.Log("Despawning anchor and tether.");

        // if the flag exists, destroy it
        if (anchorFlag)
        {
            // NOTE: (J) THIS WILL NOT DESTROY A FLAG IN PLACE
            // YOU MUST STORE A REFERENCE TO EXISTING FLAGS FOR THIS
            // TO FUNCTION PROPERLY
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
                if (firstBody == null)
                {
                    firstBody = other.gameObject;
                    anchorFlag = Instantiate(FlagPrefab, other.transform.position, Quaternion.identity, other.transform);
                }
                else if (firstBody != other.gameObject && secondBody == null)
                {
                    secondBody = other.gameObject;
                    lr.SetPosition(0, firstBody.transform.position);
                    lr.SetPosition(1, secondBody.transform.position);

                    firstBody.GetComponent<PlanetController>().tetheredTo = secondBody;
                    secondBody.GetComponent<PlanetController>().tetheredTo = firstBody;

                    firstBody.GetComponent<PlanetController>().isTethered = true;
                    secondBody.GetComponent<PlanetController>().isTethered = true;

                    isTethered = true;
                }
                else
                {
                    firstBody = other.gameObject;
                    anchorFlag = Instantiate(FlagPrefab, other.transform.position, Quaternion.identity);
                    secondBody = null;
                }
            }
        }
        else
        {
            Destroy(gameObject); // Destroy the tether if it collides with other objects
        }
    }
}
