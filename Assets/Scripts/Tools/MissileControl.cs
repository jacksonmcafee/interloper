using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    //prefab for rocket, used in instatiation
    public GameObject rocketPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //press space to fire rocket
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireRocket();
        }
    }

    public void FireRocket()
    {
        // intantiate object rocket
        GameObject newRocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
        Rocket rocket = newRocket.GetComponent<Rocket>();
        Rigidbody2D rocketRB = newRocket.GetComponent<Rigidbody2D>();

        rocket.speed = 10;
        rocket.damage = 15;
    
        rocketRB.velocity = transform.up * rocket.speed;
    }
}
