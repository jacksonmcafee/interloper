using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
  // create variable to control projectile despawning
  public float despawnTime = 2f;

  void Start()
  {
    // start despawn routine
    StartCoroutine(DelayedDespawn());
  }

  IEnumerator DelayedDespawn()
  {
    // after despawnTime seconds, destroy this object
    yield return new WaitForSeconds(despawnTime);
    Destroy(gameObject);
  }
}
