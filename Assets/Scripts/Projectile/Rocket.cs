using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{ 
  public float despawnTime = 5f;

  void Start()
  {
    StartCoroutine(DelayedDespawn());
  }

  IEnumerator DelayedDespawn()
  {
    yield return new WaitForSeconds(despawnTime);
    Destroy(gameObject);
  }

  /*public override void HandleCollision(Collider2D other)
  {
    // handle Rocket collision behavior

  }*/
}
