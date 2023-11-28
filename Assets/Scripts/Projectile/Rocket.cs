using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
  // create variable to control projectile despawning
  public float despawnTime = 5f;

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

  /*public override void HandleCollision(Collider2D other)
  {
    // handle Rocket collision behavior

  }*/
}
