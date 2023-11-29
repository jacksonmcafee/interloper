using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public int currentScore = 0;
    public int targetScore = 5;
    private int scoreDiff;

    private float mass;
    private float newMass;
    private float massDiff;

    Rigidbody2D rb;
    public string targetScene;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>(); 
      mass = rb.mass;
    }

    void FixedUpdate()
    {
      // check if game has been won
      if (currentScore >= targetScore)
      {
        // win condition! swap to next scene and toast 
        Debug.Log("Target score reached or exceeded!"); 
        SceneManager.LoadSceneAsync(targetScene);
      }
    }

    void Update()
    {
      // get the mass of the rigidbody during this cycle  
      newMass = rb.mass;
      
      // calculate diff and then update mass value
      massDiff = newMass - mass;
      mass = newMass;

      // verify if mass has changed
      if (massDiff > 0)
      {
        // determine the amount the mass has changed by and add the correct amount to the score
        scoreDiff = Mathf.FloorToInt(massDiff);
        currentScore += scoreDiff;
        Debug.Log("Score is now " + currentScore);
      }
    }
}
