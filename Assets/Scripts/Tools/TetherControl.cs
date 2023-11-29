using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherControl : MonoBehaviour
{
    //prefab for tether, used in instantaiation
    public GameObject tetherPrefab;
    public float cooldown = 2f;
    private bool isTetherActive = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTetherActive && Input.GetKeyDown(KeyCode.Space))
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

        StartCoroutine(TetherCooldown());
        isTetherActive = true; //set tether state to active
    }

    //handling the cool down for firing the tether
    IEnumerator TetherCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        isTetherActive = false;
    }
}
