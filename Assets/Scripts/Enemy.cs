using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// require rigidbody for collisions
[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
  // define variables with gets/sets
  private float shields {get; set;}
  private float health {get; set;}
  private float speed {get; set;}
  
  // attached Unity fields
  public Rigidbody2D rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    // check if player is nearby
    
    // else, wander nearby area
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    //
  }
}
