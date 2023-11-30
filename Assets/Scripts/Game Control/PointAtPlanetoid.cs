using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtPlanetoid : MonoBehaviour
{
    public string planetoidTag = "Planet";
    public float rotationSpeed = 10f;
    public GameObject ship;

    // Update is called once per frame
    void Update()
    {
      // locate nearest planet   
      GameObject nearestPlanetoid = FindNearbyPlanetoid();

      if (nearestPlanetoid != null)
      {
        // point arrow at the nearst planetoid we located
        PointAtTarget(nearestPlanetoid.transform.position);
      }
    }

    // find the nearest planetoid in the scene 
    GameObject FindNearbyPlanetoid()
    {
      // get list of all planetoids in the scene
      GameObject[] planetoids = GameObject.FindGameObjectsWithTag(planetoidTag);
      
      // select first and iterate through list to find shortest distance 
      GameObject nearestPlanetoid = planetoids[0];
      float nearestDistance = Vector3.Distance(ship.transform.position, nearestPlanetoid.transform.position);
      for (int i = 1; i < planetoids.Length; i++)
      {
        float distance = Vector3.Distance(ship.transform.position, planetoids[i].transform.position);

        // if a closer planet is found, select that instead
        if (distance < nearestDistance)
        {
          nearestDistance = distance;
          nearestPlanetoid = planetoids[i];
        }
      }

      return nearestPlanetoid;
    }

    void PointAtTarget(Vector3 targetPosition)
    {
      // point from current object to target object position
      Vector3 direction = targetPosition - ship.transform.position;

      // get angle in degrees
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

      // get a quarternion rotation and rotate the arrow
      Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
