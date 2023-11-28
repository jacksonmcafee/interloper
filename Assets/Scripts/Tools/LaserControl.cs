using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    //prefab for laser, used in instantiation
    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //press space to fire laser
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    public void FireLaser()
    {
        //instantiate object missile
        GameObject newLaser = Instantiate(laserPrefab, transform.position, transform.rotation);
        Laser laser = newLaser.GetComponent<Laser>();
        Rigidbody2D laserRB = newLaser.GetComponent<Rigidbody2D>();

        laser.speed = 15;
        laser.damage = 10;

        laserRB.velocity = transform.up * laser.speed;
    }

}
