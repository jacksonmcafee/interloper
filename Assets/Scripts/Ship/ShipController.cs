using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// require rigidbody for collisions
[RequireComponent(typeof(Rigidbody2D))]

public class ShipController : MonoBehaviour
{
  // define variables with gets/sets
  private float shields {get; set;}
  private float health {get; set;}
  private float speed {get; set;}
  private float fuel {get; set;}

  // attached Unity field
  public Rigidbody2D rb;
  public Transform tr;

  // prefabs for projectiles, used in instantiation
  public GameObject laserPrefab;
  public GameObject rocketPrefab;

  // get Transform and Rigidbody2D
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    tr = GetComponent<Transform>();

    // set initial values
    this.health = 100;
    this.shields = 50;
  }

  private void Update()
  {
    // check if health < 0
    if (health =< 0) {
      // destroy this object, change scene
      SceneManager.LoadSceneAsync("Lose");
    }
  }

  // handle different collisions
  private void OnCollisionEnter2D(Collision2D collision)
  {
    // determine what type of object we have collided with
    // figure out what script is attached to the collided object
    if (collision.gameObject.GetComponent<CelestialBody>())
    {
      // take damage based on speed and mass of both objects
      // DAMAGE NEEDS TO BE TUNED
      takeDamage(10f);
    }
    else if (collision.gameObject.GetComponent<Projectile>())
    {
      // take damage based on type of projectile
      
    }
  }

  // handle damage taken to shields + health
  private void takeDamage(float damage)
  {
    // track how much damage to deal after shields pop
    float updatedDamage = damage;
    // check current health and shields
    if (shields > 0)
    {
      // deal max damage to shields before dealing damage to health pool 
      shields -= updatedDamage;
      if (shields < 0)
      {
        updatedDamage = -shields;
        health -= updatedDamage;
      }
    }
    else
    {
      // deal direct phys damage
      health -= updatedDamage;
    }
    
    // post updated health and shields after damage is dealt
    Debug.Log("Shields: " + this.shields);
    Debug.Log("Health: " + this.health);
  }
}




