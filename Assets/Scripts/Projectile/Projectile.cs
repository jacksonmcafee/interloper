using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public float damage {get; set;}
  public float speed {get; set;}

  public virtual void HandleCollision(Collider2D other)
  {
    // do collision
  }
}
