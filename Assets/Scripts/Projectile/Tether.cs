using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : Projectile
{
    public float despawnTime = 2f;

    void Start()
    {
        StartCoroutine(DelayedDespawn());
    }

    IEnumerator DelayedDespawn()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
    
}