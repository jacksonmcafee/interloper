using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitonControl : MonoBehaviour
{
    public Transform GravPoint; //spot where the planets will be attracted to
    private bool GravitonOn = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GravitonOn = !GravitonOn;
            if(GravitonOn)
                Debug.Log("Graviton Turned ON");
            else
                Debug.Log("Graviton Turned OFF");
        }

        if(GravitonOn)
        {
            transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
        }
        
    }
}