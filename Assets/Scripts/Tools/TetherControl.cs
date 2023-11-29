using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherControl : MonoBehaviour
{
    //prefab for tether, used in instantaiation
    public GameObject tetherPrefab;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireTether();
        }
    }

    public void FireTether()
    {
        //instantiate object tether
        GameObject newTether = Instantiate(tetherPrefab, transform.position, transform.rotation);
        Tether tether = newTether.GetComponent<Tether>();
        Rigidbody2D tetherRB = newTether.GetComponent<Rigidbody2D>();
 
        tether.speed = 15;

        tetherRB.velocity = transform.up * tether.speed;
    }
}
