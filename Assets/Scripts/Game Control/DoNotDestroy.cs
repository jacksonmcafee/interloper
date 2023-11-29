using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
  private void Awake()
  {
    // get list of music objects
    GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");

    // if multiple music objects exist, destory this one
    if (musicObj.Length > 1)
    {
      Destroy(this.gameObject);
    }
    
    // add to DontDestroyOnLoad
    DontDestroyOnLoad(this.gameObject);
  }

}
