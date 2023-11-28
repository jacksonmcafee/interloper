using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// require rigidbody for collisions
[RequireComponent(typeof(Rigidbody2D))]

public class Pickup : MonoBehaviour
{

  // attached Unity fields
  public Rigidbody2D rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {

  }
}
