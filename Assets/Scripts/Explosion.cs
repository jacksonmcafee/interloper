using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
  public float despawnTime = 0.25f;

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
