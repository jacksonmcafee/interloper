using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public int level;
    public float ammount;
    public float range;
    public float strength;
    //the location that the tool fires from (unsure if this is how we will do it)
    public Transform FirePoint;

    public virtual void UseTool()
    {
        //This is a place holder that will be overridden by the individual tools
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            UseTool(); //what the tool does will be changed in the child classes
        }
    }



    
}
